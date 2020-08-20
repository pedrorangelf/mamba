using System;
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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;
        private readonly ICidadeService _cidadeService;
        private readonly IMapper _mapper;

        public EmpresaController(IEmpresaService empresaService, ICidadeService cidadeService, IMapper mapper)
        {
            _empresaService = empresaService;
            _cidadeService = cidadeService;
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
        ///     Dica: Utilize este serviço para ver os Id's disponíveis para os próximos testes. Caso não encontre nenhum registro na lista, utilize o serviço de cadastro para registrar uma nova empresa.
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> ListarEmpresas()
        {
            try
            {
                var model = _empresaService.GetAll().Result.Select(s => _mapper.Map<EmpresaModel>(s)).ToList();

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
            var empresaModel = _mapper.Map<EmpresaModel>(await _empresaService.GetById(id));

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
                var empresa = await _empresaService.GetById(id);

                if (empresa == null) return NotFound();

                await _empresaService.Remove(empresa);

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
        public async Task<IActionResult> Incluir(EmpresaAddModel model)
        {
            try
            {
                await _empresaService.Add(new Empresa
                {
                    CNPJ = model.CNPJ,
                    CidadeId = 1,
                    CodigoUsuarioCadastro = 0,
                    DataCadastro = DateTime.Now,
                    DataUltimaAlteracao = DateTime.Now,
                    Descricao = model.Descricao,
                    Nome = model.Nome,
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
                var empresa = await _empresaService.FindAsNoTracking(model.IdEmpresa);

                if (empresa != null)
                {
                    empresa = _mapper.Map<Empresa>(model);
                    empresa.ProcessoCadastro = "EmpresaController.Editar";
                    empresa.CidadeId = 1;

                    await _empresaService.Update(empresa);

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
