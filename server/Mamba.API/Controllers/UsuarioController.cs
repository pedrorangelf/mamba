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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> BuscarUsuarios()
        {
            try
            {

                List<UsuarioModel> model = new List<UsuarioModel>();

                model = _usuarioService.GetAll().Select(s => _mapper.Map<UsuarioModel>(s)).ToList();

                return Ok(model);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(UsuarioModel model)
        {
            try
            {
                _usuarioService.Add(_mapper.Map<Usuario>(model));

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Editar(UsuarioModel model)
        {
            try
            {
                if (model.IdUsuario > 0)
                {
                    var usuario = _usuarioService.GetById(model.IdUsuario.Value);

                    usuario.DataUltimaAlteracao = DateTime.Now;

                    usuario.ProcessoCadastro = "UsuarioController.Editar";

                    usuario = _mapper.Map<Usuario>(model);

                    _usuarioService.Update(usuario);

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
               var usuario =  _usuarioService.GetById(id);

                _usuarioService.Remove(usuario);

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
