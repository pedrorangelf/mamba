﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using Mamba.API.Model;
using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mamba.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DesafioController : ControllerBase
    {
        private readonly IDesafioAppService _desafioAppService;
        private readonly IQuestaoAppService _questaoAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly IMapper _mapper;

        public DesafioController(IDesafioAppService desafioAppService, IQuestaoAppService questaoAppService, IEmpresaAppService empresaAppService, IMapper mapper)
        {
            _desafioAppService = desafioAppService;
            _questaoAppService = questaoAppService;
            _empresaAppService = empresaAppService;
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

            model = _desafioAppService
                        .FindBy(null, d => d.Questoes)
                        .Select(d => new DesafioModel
                        {
                            IdDesafio = d.IdDesafio.ToString(),
                            Titulo = d.Titulo,
                            Descricao = d.Descricao,
                            Questoes = d.Questoes.Select(q => new QuestaoModel { IdQuestao = q.IdQuestao, Descricao = q.Descricao }).ToList()
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
            Desafio desafio = _desafioAppService.FindBy(d => d.IdDesafio == id, d => d.Questoes).FirstOrDefault();
            if (desafio == null) return NotFound();

            return Ok(new DesafioModel
            {
                IdDesafio = desafio.IdDesafio.ToString(),
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
                Desafio desafio = _desafioAppService.GetById(id);
                if (desafio != null)
                {
                    IEnumerable<Questao> questoes = _questaoAppService.GetAll().Where(q => q.CodigoDesafio == desafio.IdDesafio);
                    _questaoAppService.RemoveInScale(questoes);

                    _desafioAppService.Remove(desafio);
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
                int codigoEmpresa = _empresaAppService.GetAll().Select(e => e.IdEmpresa).FirstOrDefault();
                if (codigoEmpresa == 0)
                {
                    throw new Exception("Cadastre uma empresa para prosseguir.");
                }

                Desafio desafio = new Desafio
                {
                    CodigoEmpresa = codigoEmpresa,
                    Empresa = _empresaAppService.GetById(3),
                    CodigoUsuarioCadastro = 0,
                    DataAbertura = DateTime.Now,
                    DataCadastro = DateTime.Now,
                    DataFechamento = null,
                    DataUltimaAlteracao = DateTime.Now,
                    Descricao = model.Descricao,
                    Titulo = model.Titulo,
                    ProcessoCadastro = "Cadastro Desafio"
                };

                _desafioAppService.Add(desafio);

                foreach (QuestaoAddModel questaoAddModel in model.Questoes)
                {
                    Questao questao = new Questao
                    {
                        Descricao = questaoAddModel.Descricao,
                        Desafio = desafio,
                        CodigoDesafio = desafio.IdDesafio,
                        CodigoUsuarioCadastro = 0,
                        DataCadastro = DateTime.Now,
                        ProcessoCadastro = "Cadastro Desafio"
                    };
                    _questaoAppService.Add(questao);
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
                Desafio desafio = _desafioAppService.FindAsNoTracking(Convert.ToInt32(model.IdDesafio));

                if (desafio != null)
                {
                    int codigoEmpresa = _empresaAppService.GetAll().Select(e => e.IdEmpresa).FirstOrDefault();
                    if (codigoEmpresa == 0)
                    {
                        throw new Exception("Cadastre uma empresa para prosseguir.");
                    }

                    desafio = _mapper.Map<DesafioModel, Desafio>(model);
                    desafio.CodigoEmpresa = codigoEmpresa;
                    desafio.DataUltimaAlteracao = DateTime.Now;
                    desafio.ProcessoCadastro = "EmpresaController.Editar";

                    _desafioAppService.Update(desafio);

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
