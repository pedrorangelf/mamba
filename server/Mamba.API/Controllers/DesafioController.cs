using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mamba.API.Model;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mamba.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DesafioController : ControllerBase
    {
        private readonly IDesafioService _desafioService;
        private readonly IQuestaoService _questaoService;
        private readonly IEmpresaService _empresaService;
        private readonly IMapper _mapper;

        public DesafioController(IDesafioService desafioService, IQuestaoService questaoService, IEmpresaService empresaService, IMapper mapper)
        {
            _desafioService = desafioService;
            _questaoService = questaoService;
            _empresaService = empresaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos os desafios registrados
        /// </summary>
        /// <returns>Lista dos desafios registrados</returns>
        /// <response code="200">Retorna os desafios registrados</response>
        /// <response code="400">Erro ao buscar os desafios</response>
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo e depois no botão "Execute" que será exibido para testar o serviço.
        ///     
        ///     Dica: Utilize este serviço para ver os Id's disponíveis para os próximos testes. Caso não encontre nenhum registro na lista, utilize o serviço de cadastro para registrar um novo desafio.
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> ListarDesafios()
        {
            List<DesafioModel> model = new List<DesafioModel>();

            model = _desafioService
                        .FindBy(null, d => d.Questoes)
                        .Select(d => new DesafioModel
                        {
                            IdDesafio = d.Id.ToString(),
                            Titulo = d.Titulo,
                            Descricao = d.Descricao,
                            Questoes = d.Questoes.Select(q => new QuestaoModel { IdQuestao = q.Id, Descricao = q.Descricao }).ToList()
                        }).ToList();

            return Ok(model);
        }

        /// <summary>
        /// Retorna um desafio registrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O desafio encontrado</returns>
        /// <response code="200">Retorna o desafio encontrado</response>
        /// <response code="400">Erro ao buscar um desafio</response>
        /// <response code="404">Desafio não encontrado</response>
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo, informe o id de um desafio cadastrado e depois no botão "Execute" para testar o serviço.
        /// 
        ///     Dica: Utilize o serviço de listagem para encontrar um id para o teste.
        /// </remarks>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> BuscarDesafioPorId(int id)
        {
            Desafio desafio = _desafioService.FindBy(d => d.Id == id, d => d.Questoes).FirstOrDefault();
            if (desafio == null) return NotFound();

            return Ok(new DesafioModel
            {
                IdDesafio = desafio.Id.ToString(),
                Titulo = desafio.Titulo,
                Descricao = desafio.Descricao,
                Questoes = _mapper.Map<List<QuestaoModel>>(desafio.Questoes)
            }); ;
        }

        /// <summary>
        /// Exclui um desafio registrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Desafio excluído com sucesso</response>
        /// <response code="400">Erro ao excluir o desafio</response>
        /// <response code="404">Desafio não encontrado</response>
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo, informe o id de um desafio cadastrado e depois no botão "Execute" para testar o serviço.
        /// 
        ///     Dica: Utilize o serviço de listagem para encontrar um id para o teste.
        /// </remarks>
        [HttpDelete]
        [Route("excluir/{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var desafio = await _desafioService.GetById(id);
                if (desafio != null)
                {
                    IEnumerable<Questao> questoes = _questaoService.GetAll().Result.Where(q => q.DesafioId == desafio.Id);
                    await _questaoService.RemoveInScale(questoes);

                    await _desafioService.Remove(desafio);
                }
                else
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Registra um novo desafio
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Desafio registrado com sucesso</response>
        /// <response code="400">Erro ao registrar novo desafio</response>
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo, informe todos os campos exigidos e depois no botão "Execute" para testar o serviço.
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Incluir(DesafioAddModel model)
        {
            try
            {
                int codigoEmpresa = _empresaService.GetAll().Result.Select(e => e.Id).FirstOrDefault();
                if (codigoEmpresa == 0)
                {
                    throw new Exception("Cadastre uma empresa para prosseguir.");
                }

                Desafio desafio = new Desafio
                {
                    EmpresaId = codigoEmpresa,
                    Empresa = await _empresaService.GetById(3),
                    CodigoUsuarioCadastro = 0,
                    DataAbertura = DateTime.Now,
                    DataCadastro = DateTime.Now,
                    DataFechamento = null,
                    DataUltimaAlteracao = DateTime.Now,
                    Descricao = model.Descricao,
                    Titulo = model.Titulo,
                    ProcessoCadastro = "Cadastro Desafio"
                };

                await _desafioService.Add(desafio);

                foreach (QuestaoAddModel questaoAddModel in model.Questoes)
                {
                    Questao questao = new Questao
                    {
                        Descricao = questaoAddModel.Descricao,
                        Desafio = desafio,
                        DesafioId = desafio.Id,
                        CodigoUsuarioCadastro = 0,
                        DataCadastro = DateTime.Now,
                        ProcessoCadastro = "Cadastro Desafio"
                    };
                    await _questaoService.Add(questao);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza um desafio registrado
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Desafio atualizado com sucesso</response>
        /// <response code="400">Erro ao atualizar desafio</response>
        /// <response code="404">Desafio não encontrado</response>
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo, informe todos os campos exigidos e depois no botão "Execute" para testar o serviço.
        /// 
        ///     Dica: Utilize o serviço de listagem para encontrar um id para o teste.
        /// </remarks>
        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar(DesafioModel model)
        {
            try
            {
                Desafio desafio = await _desafioService.FindAsNoTracking(Convert.ToInt32(model.IdDesafio));

                if (desafio != null)
                {
                    int codigoEmpresa = _empresaService.GetAll().Result.Select(e => e.Id).FirstOrDefault();
                    if (codigoEmpresa == 0)
                    {
                        throw new Exception("Cadastre uma empresa para prosseguir.");
                    }

                    desafio = _mapper.Map<DesafioModel, Desafio>(model);
                    desafio.EmpresaId = codigoEmpresa;
                    desafio.DataUltimaAlteracao = DateTime.Now;
                    desafio.ProcessoCadastro = "EmpresaController.Editar";

                    await _desafioService.Update(desafio);

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
