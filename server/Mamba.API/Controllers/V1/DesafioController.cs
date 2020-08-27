using Mamba.API.DTOs;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mamba.API.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/")]
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
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterDesafio(Guid id)
        {
            var desafio = await _desafioService.ObterDesafioCargoInscricoes(id);

            if (desafio == null) return CustomResponse();

            return CustomResponse(ObterDesafioDto(desafio));
        }

        [Authorize(Roles = "Empresa")]
        [HttpGet("desafios-abertos")]
        public async Task<IActionResult> ObterDesafiosAbertos()
        {
            var desafios = await _desafioService.ObterDesafiosEmpresa(EmpresaId);

            var desafiosAbertos = desafios.Where(d => d.DataFechamento.HasValue == false || d.DataFechamento > DateTime.Now)
                .Select(d => ObterDesafioDto(d));

            return CustomResponse(desafiosAbertos);
        }

        [Authorize(Roles = "Empresa")]
        [HttpGet("desafios-fechados")]
        public async Task<IActionResult> ObterDesafiosFechados()
        {
            var desafios = await _desafioService.ObterDesafiosEmpresa(EmpresaId);
            
            var desafiosAbertos = desafios.Where(d => d.DataFechamento.HasValue && d.DataFechamento <= DateTime.Now)
                .Select(d => ObterDesafioDto(d));

            return CustomResponse(desafiosAbertos);
        }


        private DesafioDto ObterDesafioDto(Desafio desafio)
        {
            return new DesafioDto
            {
                Id = desafio.Id,
                Titulo = desafio.Titulo,
                Descricao = desafio.Descricao,
                LimiteInscricao = desafio.LimiteInscricao,
                DataAbertura = desafio.DataAbertura,
                DataFechamento = desafio.DataFechamento,
                CargoId = desafio.CargoId,
                Cargo = desafio.Cargo?.Nome ?? "Nenhum cargo informado",
                TotalInscricoes = desafio.Inscricoes.Count,
                DataUltimaInscricao = desafio.Inscricoes.OrderByDescending(i => i.DataInscricao)
                                             .FirstOrDefault()?.DataInscricao,
                TotalInscricoesIniciadas = desafio.Inscricoes.Count(d => d.DataInicializacao.HasValue),
                DataUltimaInicializacao = desafio.Inscricoes.Where(i => i.DataInicializacao.HasValue)
                                                 .OrderByDescending(i => i.DataInicializacao)
                                                 .FirstOrDefault()?.DataInicializacao,
                TotalInscricoesFinalizadas = desafio.Inscricoes.Count(d => d.DataFinalizacao.HasValue),
                DataUltimaFinalizacao = desafio.Inscricoes.Where(i => i.DataFinalizacao.HasValue)
                                               .OrderByDescending(i => i.DataFinalizacao)
                                               .FirstOrDefault()?.DataFinalizacao
            };
        }
    }
}
