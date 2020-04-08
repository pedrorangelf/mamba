using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mamba.API.Model;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mamba.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DesafioController : ControllerBase
    {
        private readonly IDesafioRepository _desafioReposiory;
        private readonly IQuestaoRepository _questaoReposiory;
        private readonly IEmpresaRepository _empresaReposiory;

        public DesafioController(IDesafioRepository desafioReposiory, IQuestaoRepository questaoRepository, IEmpresaRepository empresaRepository)
        {
            _desafioReposiory = desafioReposiory;
            _questaoReposiory = questaoRepository;
            _empresaReposiory = empresaRepository;
            
        }

        [HttpGet]
        public async Task<IActionResult> ListarDesafios()
        {
            List<DesafioModel> model = new List<DesafioModel>();

            model = _desafioReposiory.ListarDesafios().Select(s => new DesafioModel { IdDesafio = s.IdDesafio, Titulo = s.Titulo }).ToList();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(DesafioAddModel model)
        {
            try
            {
                if (model.IdDesafio == 0)
                {
                   
                  Desafio desafio = _desafioReposiory.Salvar(new Desafio
                    {    
                        CodigoEmpresa = 2,
                        Empresa = _empresaReposiory.GetById(2),
                        CodigoUsuarioCadastro = 0,
                        DataAbertura = DateTime.Now,
                        DataCadastro = DateTime.Now,
                        DataFechamento = null,
                        DataUltimaAlteracao = DateTime.Now,
                        Descricao = model.Descricao,
                        Titulo = model.Titulo,
                        ProcessoCadastro = "Cadastro Desafio"


                  });

                    _questaoReposiory.Add(new Questao
                    {
                        IdQuestao = 0,
                        Descricao = model.Questoes.FirstOrDefault().Descricao,
                        Desafio = desafio,
                        CodigoDesafio = desafio.IdDesafio,
                        CodigoUsuarioCadastro = 0,
                        DataCadastro = DateTime.Now,
                        ProcessoCadastro = "Cadastro Desafio",

                    });

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
