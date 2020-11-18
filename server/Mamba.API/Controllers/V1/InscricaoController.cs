using AutoMapper;
using Mamba.API.Controllers.DTOs.Requests;
using Mamba.API.Controllers.DTOs.Responses;
using Mamba.API.DTOs.Responses;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        private readonly IMapper _mapper;
        private readonly IInscricaoService _inscricaoService;
        private readonly IDesafioService _desafioService;
        private readonly ICandidatoService _candidatoService;
        private readonly IRespostaService _respostaService;
        private readonly UserManager<ApplicationUser> _userManager;

        public InscricaoController(INotificator notificator,
                                   IUser user,
                                   IInscricaoService inscricaoService,
                                   IDesafioService desafioService,
                                   UserManager<ApplicationUser> userManager,
                                   ICandidatoService candidatoService,
                                   IMapper mapper,
                                   IRespostaService respostaService) : base(notificator, user)
        {
            _inscricaoService = inscricaoService;
            _desafioService = desafioService;
            _userManager = userManager;
            _candidatoService = candidatoService;
            _mapper = mapper;
            _respostaService = respostaService;
        }

        [Authorize(Roles = "Empresa")]
        [HttpGet("candidatos-desafio/{idDesafio:guid}")]
        [SwaggerOperation("Endpoint dedicado ao app mobile")]
        public async Task<IActionResult> ObterCandidatosDesafio(Guid idDesafio)
        {
            var inscricoes = await _inscricaoService.ObterInscricoesDesafioCandidato(idDesafio);

            return CustomResponse(inscricoes.Select(i => ObterInscricaoDto(i)));
        }

        [AllowAnonymous]
        [HttpPost("{idDesafio:guid}")]
        [SwaggerOperation("Grava a inscrição de um novo candidato, junto com suas respostas")]
        [SwaggerResponse(StatusCodes.Status200OK, "Inscrição realizada com sucesso!", typeof(OkCustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "O id do desafio informado no payload é diferende do informado na rota", typeof(string))]
        public async Task<IActionResult> Criar(Guid idDesafio, InscricaoRequest inscricaoRequest)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var desafio = await _desafioService.FindAsNoTracking(idDesafio);
            if (desafio == null) return NotFound("Desafio não encontrado.");

            if (desafio.Id != inscricaoRequest.DesafioId)
                return BadRequest("O id do desafio informado no payload é diferende do informado na rota.");

            if (desafio.LimiteInscricao.HasValue)
            {
                var inscricoes = await _inscricaoService.ObterInscricoesDesafioCandidato(idDesafio);
                if (inscricoes.Count() >= desafio.LimiteInscricao)
                    return BadRequest("Este desafio já atingiu seu limite de inscrições.");
            }

            if (desafio.DataFechamento.HasValue)
            {
                if (desafio.DataFechamento.Value <= DateTime.Now)
                    return BadRequest("Este desafio já foi fechado e não permite novas inscrições.");
            }

            var user = new ApplicationUser
            {
                DataNascimento = inscricaoRequest.DataNascimento,
                Email = inscricaoRequest.Email,
                LinkGithub = inscricaoRequest.LinkGithub,
                LinkLinkedin = inscricaoRequest.LinkLinkedin,
                Nome = inscricaoRequest.Nome,
                PhoneNumber = inscricaoRequest.Celular,
                UserName = inscricaoRequest.Email
            };

            var result = await _userManager.CreateAsync(user, "Senhapadrao#1234");
            if (!result.Succeeded)
            {
                foreach (var erro in result.Errors)
                    NotificarErro(erro.Description);

                return CustomResponse();
            }

            var candidato = new Candidato
            {
                ApplicationUserId = user.Id,
                Profissao = inscricaoRequest.Profissao,
                Endereco = _mapper.Map<Endereco>(inscricaoRequest.Endereco)
            };
            await _candidatoService.Add(candidato);
            await _userManager.AddToRoleAsync(user, "Candidato");

            var inscricao = new Inscricao
            {
                DesafioId = idDesafio,
                CandidatoId = candidato.Id,
                DataInscricao = DateTime.Now,
                DataInicializacao = DateTime.Now,
                DataFinalizacao = DateTime.Now
            };
            await _inscricaoService.Add(inscricao);

            foreach (var resposta in inscricaoRequest.Respostas)
            {
                await _respostaService.Add(new Resposta
                {
                    InscricaoId = inscricao.Id,
                    QuestaoId = resposta.QuestaoId,
                    Descricao = resposta.Descricao
                });
            }

            return CustomResponse(new InscricaoCreateResponse
            {
                IdInscricao = inscricao.Id,
                Message = "Inscrição realizada com sucesso!"
            });
        }

        [Authorize(Roles = "Empresa")]
        [HttpGet("{id:guid}")]
        [SwaggerOperation("Retorna os detalhes da inscrição")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a inscrição detalhada", typeof(OkCustomResponse<InscricaoDetalhadaResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Inscrição não encontrada", typeof(string))]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var inscricao = await _inscricaoService.ObterInscricaoDetalhada(id);
            if (inscricao == null) return NotFound("Inscrição não encontrada");

            var inscricaoResponse = new InscricaoDetalhadaResponse
            {
                DesafioId = inscricao.DesafioId,
                VagaDesafio = inscricao.Desafio.Cargo.Nome,
                NomeCandidato = inscricao.Candidato.ApplicationUser.Nome,
                Telefone = inscricao.Candidato.ApplicationUser.PhoneNumber,
                Email = inscricao.Candidato.ApplicationUser.Email,
                LinkedIn = inscricao.Candidato.ApplicationUser.LinkLinkedin,
                GitHub = inscricao.Candidato.ApplicationUser.LinkGithub,
                Aprovado = inscricao.Aprovado,
                ParecerFinal = inscricao.Resultado,
                TotalQuestoes = inscricao.Desafio.Questoes.Count(),
                TotalAcertos = inscricao.Desafio.Questoes.Select(q => q.Respostas.Count(r => r.Avaliacao?.Aprovado ?? false == true && r.InscricaoId == id)).Sum(),
                Questoes = inscricao.Desafio.Questoes.Select(q => new InscricaoDetalhadaQuestaoResponse
                {
                    QuestaoId = q.Id,
                    Descricao = q.Descricao,
                    Resposta = q.Respostas.Where(r => r.InscricaoId == id && r.QuestaoId == q.Id)
                        .Select(r => new InscricaoDetalhadaQuestaoRespostaResponse
                        {
                            RespostaId = r.Id,
                            Descricao = r.Descricao,
                        }).FirstOrDefault(),
                    Avaliacao = q.Respostas.Where(r => r.InscricaoId == id && r.QuestaoId == q.Id && r.Avaliacao != null)
                        .Select(r => new InscricaoDetalhadaQuestaoAvaliacaoResponse
                        {
                            Aprovado = r.Avaliacao.Aprovado,
                            Descricao = r.Avaliacao.Descricao,
                            Avaliador = r.Avaliacao.Funcionario.ApplicationUser.Nome
                        }).FirstOrDefault() ?? new InscricaoDetalhadaQuestaoAvaliacaoResponse()
                }).ToList()
            };

            return CustomResponse(inscricaoResponse);
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
