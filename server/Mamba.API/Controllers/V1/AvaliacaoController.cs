using Mamba.API.Controllers.DTOs.Requests;
using Mamba.API.DTOs.Responses;
using Mamba.Domain.Entities;
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
    [Route("api/v{version:apiVersion}/avaliacao")]
    public class AvaliacaoController : MainController
    {
        private readonly IDesafioService _desafioService;
        private readonly IInscricaoService _inscricaoService;
        private readonly IFuncionarioService _funcionarioService;
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(INotificator notificator,
                                      IUser user,
                                      IDesafioService desafioService,
                                      IInscricaoService inscricaoService,
                                      IFuncionarioService funcionarioService,
                                      IAvaliacaoService avaliacaoService) : base(notificator, user)
        {
            _desafioService = desafioService;
            _inscricaoService = inscricaoService;
            _funcionarioService = funcionarioService;
            _avaliacaoService = avaliacaoService;
        }

        [Authorize(Roles = "Empresa")]
        [HttpPost("salvar-avaliacao-desafio/{idDesafio:guid}")]
        [SwaggerOperation("Grava a avaliação do desafio de um candidato")]
        [SwaggerResponse(StatusCodes.Status200OK, "Avaliação salva com sucesso!", typeof(OkCustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Desafio não encontrado", typeof(string))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Inscrição não encontrada", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "O id do desafio informado no payload é diferente do informado na rota", typeof(string))]
        public async Task<IActionResult> SalvarAvaliacaoDesafio(Guid idDesafio, AvaliacaoRequest avaliacaoRequest)
        {
            var desafio = await _desafioService.FindAsNoTracking(idDesafio);
            if (desafio == null) return NotFound("Desafio não encontrado");

            if (desafio.Id != avaliacaoRequest.DesafioId)
                return BadRequest("O id do desafio informado no payload é diferente do informado na rota");

            var inscricao = await _inscricaoService.GetById(avaliacaoRequest.InscricaoId);
            if (inscricao == null) return NotFound("Inscrição não encontrada");

            if (inscricao.DesafioId != desafio.Id) return NotFound("Inscrição não encontrada");

            var funcionario = await _funcionarioService.ObterFuncionarioUsuario(UsuarioId);

            foreach (var avaliacao in avaliacaoRequest.Avaliacoes)
            {
                await _avaliacaoService.Add(new Avaliacao
                {
                    FuncionarioId = funcionario.Id,
                    Aprovado = avaliacao.Correta,
                    Descricao = avaliacao.Descricao,
                    RespostaId = avaliacao.RespostaId
                });
            }

            inscricao.Aprovado = avaliacaoRequest.CandidatoAprovado;
            inscricao.Resultado = avaliacaoRequest.ParecerFinal;
            await _inscricaoService.Update(inscricao);

            return CustomResponse("Avaliação salva com sucesso!");
        }
    }
}
