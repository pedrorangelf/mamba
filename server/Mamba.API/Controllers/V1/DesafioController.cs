using AutoMapper;
using Mamba.API.Controllers.DTOs.Responses;
using Mamba.API.DTOs;
using Mamba.API.DTOs.Requests;
using Mamba.API.DTOs.Responses;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamba.API.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/desafio")]
    public class DesafioController : MainController
    {
        private readonly IQuestaoService _questaoService;
        private readonly ICargoService _cargoService;
        private readonly IInscricaoService _inscricaoService;
        private readonly IDesafioService _desafioService;
        private readonly IMapper _mapper;


        public DesafioController(INotificator notificator,
                                 IUser user,
                                 IDesafioService desafioService,
                                 IMapper mapper,
                                 ICargoService cargoService,
                                 IInscricaoService inscricaoService,
                                 IQuestaoService questaoService) : base(notificator, user)
        {
            _desafioService = desafioService;
            _mapper = mapper;
            _cargoService = cargoService;
            _inscricaoService = inscricaoService;
            _questaoService = questaoService;
        }

        [Authorize(Roles = "Empresa")]
        [HttpPost]
        [SwaggerOperation("Registra um novo desafio para a empresa do usuário")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o ID do desafio registrado", typeof(OkCustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cargo informado não foi encontrado", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erros de validação da ModelState", typeof(BadRequestCustomResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Você não tem permissão para cadastrar um desafio com o cargo informado",
                         typeof(BadRequestCustomResponse))]
        public async Task<IActionResult> Criar(DesafioCreateRequest desafioCreateRequest)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var cargo = await _cargoService.FindAsNoTracking(desafioCreateRequest.CargoId);
            if (cargo == null) return NotFound("Cargo informado não foi encontrado");

            if (cargo.EmpresaId != EmpresaId)
            {
                NotificarErro("Você não tem permissão para cadastrar um desafio com o cargo informado");
                return CustomResponse();
            }

            var desafio = _mapper.Map<Desafio>(desafioCreateRequest);
            desafio.EmpresaId = EmpresaId;

            await _desafioService.Add(desafio);

            return CustomResponse(desafio.Id);
        }

        [Authorize(Roles = "Empresa")]
        [HttpGet]
        [SwaggerOperation("Retorna todos os desafios cadastrados da empresa do usuário")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna os desafios cadastrados da empresa do usuário", typeof(OkCustomResponse<IEnumerable<DesafioListResponse>>))]
        public async Task<IActionResult> ObterTodos()
        {
            var desafios = await _desafioService.ObterDesafiosEmpresa(EmpresaId);

            var response = desafios.Select(d => new DesafioListResponse
            {
                Id = d.Id,
                Cargo = d.Cargo?.Nome ?? "Sem cargo",
                DataAbertura = d.DataAbertura,
                DataFechamento = d.DataFechamento,
                TotalCandidatos = d.Inscricoes.Count(),
                QuestionariosFinalizados = d.Inscricoes.Count(i => i.DataFinalizacao.HasValue),
                CorrecoesPendentes = d.Inscricoes.Sum(i => i.Respostas.Count(r => r.Avaliacao == null))
            });

            return CustomResponse(response);
        }

        [Authorize(Roles = "Empresa")]
        [HttpGet("{id:guid}")]
        [SwaggerOperation("Retorna os detalhes do desafio informado")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna os detalhes do desafio informado", typeof(OkCustomResponse<DesafioDetailResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Desafio não encontrado", typeof(string))]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var desafio = await _desafioService.ObterDesafioQuestoes(id);

            if (desafio == null) return NotFound("Desafio não encontrado");

            return CustomResponse(_mapper.Map<DesafioDetailResponse>(desafio));
        }

        [Authorize(Roles = "Empresa")]
        [HttpPut("{id:guid}")]
        [SwaggerOperation("Atualiza o desafio informado")]
        [SwaggerResponse(StatusCodes.Status200OK, "Desafio atualizado com sucesso!", typeof(OkCustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Desafio não encontrado", typeof(string))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cargo informado não foi encontrado", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Id informado na rota não é o mesmo informado no payload", typeof(BadRequestCustomResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Você não possui permissão para atualizar este desafio", typeof(string))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Você não tem permissão para cadastrar um desafio com o cargo informado", typeof(string))]
        public async Task<IActionResult> Atualizar(Guid id, DesafioUpdateRequest desafioUpdateRequest)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var desafio = await _desafioService.FindAsNoTracking(id);
            if (desafio == null) return NotFound("Desafio não encontrado");

            if (desafioUpdateRequest.Id != id)
            {
                NotificarErro("Id informado na rota não é o mesmo informado no payload");
                return CustomResponse();
            }

            if (desafio.EmpresaId != EmpresaId)
                return Unauthorized("Você não possui permissão para atualizar este desafio");

            var cargo = await _cargoService.FindAsNoTracking(desafioUpdateRequest.CargoId);
            if (cargo == null) return NotFound("Cargo informado não foi encontrado");

            if (cargo.EmpresaId != EmpresaId)
                return Unauthorized("Você não tem permissão para cadastrar um desafio com o cargo informado");

            var desafioUpdate = _mapper.Map<Desafio>(desafioUpdateRequest);
            desafioUpdate.EmpresaId = EmpresaId;

            await _desafioService.Update(desafioUpdate);

            return CustomResponse("Desafio atualizado com sucesso!");
        }

        [Authorize(Roles = "Empresa")]
        [HttpDelete("{id:guid}")]
        [SwaggerOperation("Deleta o desafio informado")]
        [SwaggerResponse(StatusCodes.Status200OK, "Desafio deletado com sucesso!", typeof(OkCustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Desafio não encontrado", typeof(string))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Você não possui permissão para deletar este desafio", typeof(string))]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var desafio = await _desafioService.GetById(id);
            if (desafio == null) return NotFound("Desafio não encontrado");

            if (desafio.EmpresaId != EmpresaId)
                return Unauthorized("Você não possui permissão para deletar este desafio.");

            await _desafioService.Remove(desafio);

            return CustomResponse("Desafio deletado com sucesso!");
        }

        [Authorize(Roles = "Empresa")]
        [HttpGet("{id:guid}/obter-inscricoes")]
        [SwaggerOperation("Lista todas as inscrições do desafio")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista os desafios", typeof(OkCustomResponse<InscricoesDesafioResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Desafio não encontrado", typeof(string))]
        public async Task<IActionResult> ObterInscricoesDesafio(Guid id)
        {
            var desafio = await _desafioService.ObterDesafioQuestoes(id);
            if (desafio == null) return NotFound("Desafio não encontrado");

            var inscricoes = await _inscricaoService.ObterInscricoesDesafioCandidato(id);
            var inscricoesResponse = inscricoes.Select(i => new InscricoesDesafioResponse
            {
                InscricaoId = i.Id,
                NomeCandidato = i.Candidato.ApplicationUser.Nome,
                Aprovado = i.Aprovado,
                TotalQuestoes = desafio.Questoes.Count(),
                TotalAcertos = i.Respostas.Count(r => r.Avaliacao?.Aprovado ?? false == true)
            });

            return CustomResponse(inscricoesResponse);
        }

        [Authorize(Roles = "Empresa")]
        [HttpGet("{id:guid}/obter-questoes")]
        [SwaggerOperation("Lista todas as questões do desafio")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista as questões", typeof(OkCustomResponse<QuestoesDesafioResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Desafio não encontrado", typeof(string))]
        public async Task<IActionResult> ObterQuestoesDesafio(Guid id)
        {
            var desafio = await _desafioService.ObterDesafioQuestoes(id);
            if (desafio == null) return NotFound("Desafio não encontrado");

            var inscricoesResponse = desafio.Questoes.Select(q => new QuestoesDesafioResponse
            {
                QuestaoId = q.Id,
                Descricao = q.Descricao
            });

            return CustomResponse(inscricoesResponse);
        }

        [Authorize(Roles = "Empresa")]
        [HttpPost("{id:guid}/fechar-desafio")]
        [SwaggerOperation("Fecha o desafio para novas vagas")]
        [SwaggerResponse(StatusCodes.Status200OK, "Desafio fechado com sucesso!", typeof(OkCustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Desafio não encontrado", typeof(string))]
        public async Task<IActionResult> FecharDesafio(Guid id)
        {
            var desafio = await _desafioService.GetById(id);
            if (desafio == null) return NotFound("Desafio não encontrado");

            desafio.DataFechamento = DateTime.Now;
            await _desafioService.Update(desafio);

            return CustomResponse("Desafio fechado com sucesso!");
        }

        // APP MOBILE
        [Authorize(Roles = "Empresa")]
        [HttpGet("desafios-abertos")]
        [SwaggerOperation("Endpoint dedicado ao app mobile")]
        public async Task<IActionResult> ObterDesafiosAbertos()
        {
            var desafios = await _desafioService.ObterDesafiosEmpresa(EmpresaId);

            var desafiosAbertos = desafios.Where(d => d.DataFechamento.HasValue == false || d.DataFechamento > DateTime.Now)
                .Select(d => ObterDetalhesDesafio(d));

            return CustomResponse(desafiosAbertos);
        }

        [Authorize(Roles = "Empresa")]
        [SwaggerOperation("Endpoint dedicado ao app mobile")]
        [HttpGet("desafios-fechados")]
        public async Task<IActionResult> ObterDesafiosFechados()
        {
            var desafios = await _desafioService.ObterDesafiosEmpresa(EmpresaId);

            var desafiosAbertos = desafios.Where(d => d.DataFechamento.HasValue && d.DataFechamento <= DateTime.Now)
                .Select(d => ObterDetalhesDesafio(d));

            return CustomResponse(desafiosAbertos);
        }

        private DetalheDesafioResponse ObterDetalhesDesafio(Desafio desafio)
        {
            return new DetalheDesafioResponse
            {
                Id = desafio.Id,
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

    public class QuestoesDesafioResponse
    {
        public Guid QuestaoId { get; set; }
        public string Descricao { get; set; }
    }
}
