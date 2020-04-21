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

        [HttpGet]
        public async Task<IActionResult> BuscarEmpresas()
        {
            try
            {

                List<EmpresaModel> model = new List<EmpresaModel>();

                model = _empresaService.GetAll().Select(s => _mapper.Map<EmpresaModel>(s)).ToList();

                return Ok(model);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(EmpresaModel model)
        {
            try
            {
                _empresaService.Add(new Empresa
                {
                    CNPJ = model.CNPJ,
                    CodigoCidade = model.CodigoCidade,
                    CodigoUsuarioCadastro = model.CodigoUsuarioCadastro,
                    DataCadastro = DateTime.Now,
                    DataUltimaAlteracao = DateTime.Now,
                    Descricao = model.Descricao,
                    Cidade = _cidadeService.GetById(model.CodigoCidade),
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

        [HttpPut]
        public async Task<IActionResult> Editar(EmpresaModel model)
        {
            try
            {
                if (model.IdEmpresa > 0)
                {
                    var empresa = _empresaService.GetById(model.IdEmpresa.Value);

                    empresa.DataUltimaAlteracao = DateTime.Now;

                    empresa.ProcessoCadastro = "EmpresaController.Editar";

                    empresa = _mapper.Map<Empresa>(model);

                    _empresaService.Update(empresa);

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

        [HttpDelete]
        [Route("exlcuir/{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
               var empresa =  _empresaService.GetById(id);

                _empresaService.Remove(empresa);

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
