﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DesafioController(IDesafioAppService desafioAppService, IQuestaoAppService questaoAppService, IEmpresaAppService empresaAppService)
        {
            _desafioAppService = desafioAppService;
            _questaoAppService = questaoAppService;
            _empresaAppService = empresaAppService;
        }


        /// <summary>
        /// Lista todos os desafios registrados
        /// </summary>
        /// <returns>Lista dos desafios registrados</returns>
        /// <response code="200">Retorna os desafios registrados</response>
        /// <response code="400">Erro ao buscar os desafios</response>
        [HttpGet]
        public async Task<IActionResult> ListarDesafios()
        {
            List<DesafioModel> model = new List<DesafioModel>();

            model = _desafioAppService.GetAll().Select(s => new DesafioModel { IdDesafio = s.IdDesafio, Titulo = s.Titulo }).ToList();

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
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> BuscarDesafioPorId(int id)
        {
            Desafio desafio = _desafioAppService.GetById(id);

            return Ok(new DesafioModel
            {
                IdDesafio = desafio.IdDesafio,
                Titulo = desafio.Titulo
            });
        }

        /// <summary>
        /// Exclui um desafio registrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Desafio excluído com sucesso</response>
        /// <response code="400">Erro ao excluir o desafio</response>
        /// <response code="404">Desafio não encontrado</response>
        [HttpDelete]
        [Route("excluir/{id:int}")]
        public async Task<IActionResult> ExcluirDesafio(int id)
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

                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Registra/Atualiza um desafio
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Desafio registrado/atualizado com sucesso</response>
        /// <response code="400">Erro ao registrar/atualizado novo desafio</response>
        /// <response code="404">Desafio não encontrado</response>
        [HttpPost]
        public async Task<IActionResult> Salvar(DesafioAddModel model)
        {
            try
            {
                if (model.IdDesafio == 0)
                {
                    Desafio desafio = new Desafio
                    {
                        CodigoEmpresa = 2,
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

                    Questao questao = new Questao
                    {
                        IdQuestao = 0,
                        Descricao = model.Questoes.FirstOrDefault().Descricao,
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
    }
}
