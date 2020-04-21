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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioAppService usuarioAppService, IMapper mapper)
        {
            _usuarioAppService = usuarioAppService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos os usuários registrados
        /// </summary>
        /// <returns>Lista de todos os usuários registros</returns>
        /// <response code="200">Retorna a lista dos usuários registrados</response>
        /// <response code="400">Erro ao buscar usuários</response>
        [HttpGet]
        public async Task<IActionResult> BuscarUsuarios()
        {
            try
            {

                List<UsuarioModel> model = new List<UsuarioModel>();

                model = _usuarioAppService.GetAll().Select(s => _mapper.Map<UsuarioModel>(s)).ToList();

                return Ok(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Retorna um usuário registrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O usuário registrado</returns>
        /// <response code="200">Retorna o usuário encontrado</response>
        /// <response code="400">Erro ao buscar usuário</response>
        /// <response code="404">Nenhum usuário encontrado</response>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> BuscarUsuarioPorId(int id)
        {
            UsuarioModel usuarioModel = _mapper.Map<UsuarioModel>(_usuarioAppService.GetById(id));

            if (usuarioModel != null)
            {
                return Ok(usuarioModel);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Usuário registrado com sucesso</response>
        /// <response code="400">Erro ao registrar usuário</response>
        [HttpPost]
        public async Task<IActionResult> Incluir(UsuarioModel model)
        {
            try
            {
                _usuarioAppService.Add(_mapper.Map<Usuario>(model));

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza um usuário registrado
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Usuário atualizado com sucesso</response>
        /// <response code="400">Erro ao atualizar usuário</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpPut]
        public async Task<IActionResult> Editar(UsuarioModel model)
        {
            try
            {
                if (model.IdUsuario > 0)
                {
                    var usuario = _usuarioAppService.GetById(model.IdUsuario.Value);

                    usuario.DataUltimaAlteracao = DateTime.Now;

                    usuario.ProcessoCadastro = "UsuarioController.Editar";

                    usuario = _mapper.Map<Usuario>(model);

                    _usuarioAppService.Update(usuario);

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

        /// <summary>
        /// Exclui um usuário registrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Usuário excluído com sucesso</response>
        /// <response code="400">Erro ao excluir usuário</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpDelete]
        [Route("excluir/{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var usuario = _usuarioAppService.GetById(id);

                _usuarioAppService.Remove(usuario);

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
