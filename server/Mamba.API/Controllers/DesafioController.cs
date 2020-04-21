using System;
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
        private readonly IDesafioAppService _desafioAppReposiory;
        private readonly IQuestaoAppService _questaoAppReposiory;
        private readonly IEmpresaAppService _empresaAppReposiory;

        public DesafioController(IDesafioAppService desafioAppReposiory, IQuestaoAppService questaoAppReposiory, IEmpresaAppService empresaAppReposiory)
        {
            _desafioAppReposiory = desafioAppReposiory;
            _questaoAppReposiory = questaoAppReposiory;
            _empresaAppReposiory = empresaAppReposiory;
        }

        [HttpGet]
        public async Task<IActionResult> ListarDesafios()
        {
            List<DesafioModel> model = new List<DesafioModel>();

            model = _desafioAppReposiory.GetAll().Select(s => new DesafioModel { IdDesafio = s.IdDesafio, Titulo = s.Titulo }).ToList();

            return Ok(model);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> BuscarDesafioPorId(int id)
        {

            Desafio desafio = _desafioAppReposiory.GetById(id);

            return Ok(new DesafioModel
            {
                IdDesafio = desafio.IdDesafio,
                Titulo = desafio.Titulo
            });
        }

        [HttpDelete]
        [Route("excluir/{id:int}")]
        public async Task<IActionResult> ExcluirDesafio(int id)
        {
            try
            {
                Desafio desafio = _desafioAppReposiory.GetById(id);
                if (desafio != null)
                {
                    IEnumerable<Questao> questoes = _questaoAppReposiory.GetAll().Where(q => q.CodigoDesafio == desafio.IdDesafio);
                    _questaoAppReposiory.RemoveInScale(questoes);

                    _desafioAppReposiory.Remove(desafio);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

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
                        Empresa = _empresaAppReposiory.GetById(3),
                        CodigoUsuarioCadastro = 0,
                        DataAbertura = DateTime.Now,
                        DataCadastro = DateTime.Now,
                        DataFechamento = null,
                        DataUltimaAlteracao = DateTime.Now,
                        Descricao = model.Descricao,
                        Titulo = model.Titulo,
                        ProcessoCadastro = "Cadastro Desafio"
                    };

                    _desafioAppReposiory.Add(desafio);

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

                    _questaoAppReposiory.Add(questao);
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
