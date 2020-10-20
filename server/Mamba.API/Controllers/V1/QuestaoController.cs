using Mamba.API.DTOs.Responses;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace Mamba.API.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/questao")]
    public class QuestaoController : MainController
    {
        private readonly IQuestaoService _questaoService;
        private readonly IDesafioService _desafioService;

        public QuestaoController(INotificator notificator,
                                 IUser user,
                                 IQuestaoService questaoService,
                                 IDesafioService desafioService) : base(notificator, user)
        {
            _questaoService = questaoService;
            _desafioService = desafioService;
        }

        [HttpDelete("{id:guid}")]
        [SwaggerOperation("Deleta a questão informada")]
        [SwaggerResponse(StatusCodes.Status200OK, "Questão deletada com sucesso!", typeof(OkCustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Questão não encontrada", typeof(string))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Você não possui permissão para deletar essa questão", typeof(string))]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var questao = await _questaoService.GetById(id);

            if (questao == null) return NotFound("Questão não encontrada");

            var desafio = await _desafioService.FindAsNoTracking(questao.DesafioId);

            if (desafio.EmpresaId != EmpresaId)
            {
                NotificarErro("Você não possui permissão para deletar essa questão");
                return CustomResponse();
            }

            await _questaoService.Remove(questao);

            return CustomResponse("Questão deletada com sucesso!");
        }
    }
}
