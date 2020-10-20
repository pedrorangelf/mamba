using Mamba.API.DTOs;
using Mamba.API.DTOs.Responses;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mamba.API.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    public class InscricaoController : MainController
    {
        private readonly IInscricaoService _inscricaoService;

        public InscricaoController(INotificator notificator,
                                   IUser user,
                                   IInscricaoService inscricaoService) : base(notificator, user)
        {
            _inscricaoService = inscricaoService;
        }

        [Authorize(Roles = "Empresa")]
        [HttpGet("candidatos-desafio/{idDesafio:guid}")]
        public async Task<IActionResult> ObterCandidatosDesafio(Guid idDesafio)
        {
            var inscricoes = await _inscricaoService.ObterInscricoesDesafioCandidato(idDesafio);

            return CustomResponse(inscricoes.Select(i => ObterInscricaoDto(i)));
        }


        private InscricaoResponse ObterInscricaoDto(Inscricao inscricao)
        {
            return new InscricaoResponse
            {
                CandidatoId = inscricao.CandidatoId,
                NomeCandidato = inscricao.Candidato.ApplicationUser.Nome,
                DataInscricao = inscricao.DataInscricao,
                DataInicializacao = inscricao.DataInicializacao,
                DataFinalizacao = inscricao.DataFinalizacao,
                Resultado = inscricao.Resultado,
                Aprovado = inscricao.Aprovado
            };
        }
    }
}
