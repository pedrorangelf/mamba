using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mamba.API.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/")]
    public class DesafioController : MainController
    {
        private readonly IDesafioService _desafioService;
        public DesafioController(INotificator notificator,
                                 IUser user,
                                 IDesafioService desafioService) : base(notificator, user)
        {
            _desafioService = desafioService;
        }

        [Authorize(Roles = "Empresa")]
        [HttpGet("desafios-abertos")]
        public async Task<IActionResult> ObterDesafiosAbertos()
        {
            var desafiosAbertos = await _desafioService.ObterDesafiosEmpresa(EmpresaId);

            return CustomResponse(desafiosAbertos.Select(d => new
            {
                Titulo = d.Titulo,
                Descricao = d.Descricao,
                Cargo = d.Cargo.Nome,
                Candidatos = d.Inscricoes.Count
            }));
        }
    }
}
