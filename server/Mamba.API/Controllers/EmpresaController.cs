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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;

        }

        [HttpPost]
        public async Task<IActionResult> Incluir(EmpresaModel model)
        {
            try
            {
               
                   
                    _empresaService.Salvar(new Empresa
                  {    
                       CNPJ = model.CNPJ,
                       CodigoCidade = model.CodigoCidade,
                       CodigoUsuarioCadastro = model.CodigoUsuarioCadastro,
                       DataCadastro = DateTime.Now,
                       DataUltimaAlteracao = DateTime.Now,
                       Descricao = model.Descricao,
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
    }
}
