using System;
using System.Collections.Generic;
using System.Linq;
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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaAppService _empresaAppService;
        private readonly ICidadeAppService _cidadeAppService;
        private readonly IMapper _mapper;

        public EmpresaController(IEmpresaAppService empresaAppService, ICidadeAppService cidadeAppService, IMapper mapper)
        {
            _empresaAppService = empresaAppService;
            _cidadeAppService = cidadeAppService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todas as empresas registradas
        /// </summary>
        /// <returns>Lista das empresas registradas</returns>
        /// <response code="200">Retorna a lista das empresas registradas</response>
        /// <response code="400">Erro ao buscar as empresas</response>
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo e depois no botão "Execute" que será exibido para testar o serviço.
        ///     
        ///     Dica: Utilize este serviço para ver os Id's disponíveis para os próximos testes.
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> ListarEmpresas()
        {
            try
            {
                List<EmpresaModel> model = new List<EmpresaModel>();

                model = _empresaAppService.GetAll().Select(s => _mapper.Map<EmpresaModel>(s)).ToList();

                return Ok(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Retorna uma empresa registrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Empresa registrada</returns>
        /// <response code="200">Retorna a empresa encontrada</response>
        /// <response code="400">Erro ao buscar a empresa</response>
        /// <response code="404">Empresa não encontrada</response>
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo, informe o id de um desafio cadastrado e depois no botão "Execute" para testar o serviço.
        /// 
        ///     Dica: Utilize o serviço de listagem para encontrar um id para o teste.
        /// </remarks>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> BuscaEmpresaPorId(int id)
        {
            EmpresaModel empresaModel = _mapper.Map<Empresa, EmpresaModel>(_empresaAppService.GetById(id));

            return Ok(empresaModel);
        }

        /// <summary>
        /// Exclui uma empresa registrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Empresa excluída com sucesso</response>
        /// <response code="400">Erro ao excluir a empresa</response>
        /// <response code="404">Empresa não encontrada</response>
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
                var empresa = _empresaAppService.GetById(id);

                _empresaAppService.Remove(empresa);

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Registra uma nova empresa
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Empresa registrada com sucesso</response>
        /// <response code="400">Erro ao registrar empresa</response>
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo, informe todos os campos exigidos e depois no botão "Execute" para testar o serviço.
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Incluir(EmpresaModel model)
        {
            try
            {
                _empresaAppService.Add(new Empresa
                {
                    CNPJ = model.CNPJ,
                    CodigoCidade = model.CodigoCidade,
                    CodigoUsuarioCadastro = model.CodigoUsuarioCadastro,
                    DataCadastro = DateTime.Now,
                    DataUltimaAlteracao = DateTime.Now,
                    Descricao = model.Descricao,
                    Cidade = _cidadeAppService.GetById(model.CodigoCidade),
                    Nome = model.Nome,
                    //Logo =
                    ProcessoCadastro = "EmpresaController.Incluir"
                });

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza uma empresa registrada
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Empresa atualizada com sucesso</response>
        /// <response code="400">Erro ao atualizar empresa</response>
        /// <response code="404">Empresa não encontrada</response>
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo, informe todos os campos exigidos e depois no botão "Execute" para testar o serviço.
        /// 
        ///     Dica: Utilize o serviço de listagem para encontrar um id para o teste.
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Editar(EmpresaModel model)
        {
            try
            {
                if (model.IdEmpresa > 0)
                {
                    var empresa = _empresaAppService.GetById(model.IdEmpresa.Value);

                    empresa.DataUltimaAlteracao = DateTime.Now;

                    empresa.ProcessoCadastro = "EmpresaController.Editar";

                    empresa = _mapper.Map<Empresa>(model);

                    _empresaAppService.Update(empresa);

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
