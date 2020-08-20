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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos os usuários registrados
        /// </summary>
        /// <returns>Lista de todos os usuários registros</returns>
        /// <response code="200">Retorna a lista dos usuários registrados</response>
        /// <response code="400">Erro ao buscar usuários</response>
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo e depois no botão "Execute" que será exibido para testar o serviço.
        ///     
        ///     Dica: Utilize este serviço para ver os Id's disponíveis para os próximos testes. Caso não encontre nenhum registro na lista, utilize o serviço de cadastro para registrar um novo usuário.
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            try
            {

                var model = _usuarioService.GetAll().Result.Select(s => _mapper.Map<UsuarioModel>(s)).ToList();

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
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo, informe o id de um desafio cadastrado e depois no botão "Execute" para testar o serviço.
        /// 
        ///     Dica: Utilize o serviço de listagem para encontrar um id para o teste.
        /// </remarks>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> BuscarUsuarioPorId(int id)
        {
            var usuarioModel = _mapper.Map<UsuarioModel>(await _usuarioService.GetById(id));

            if (usuarioModel == null) return NotFound();

            return Ok(usuarioModel);
        }

        /// <summary>
        /// Exclui um usuário registrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Usuário excluído com sucesso</response>
        /// <response code="400">Erro ao excluir usuário</response>
        /// <response code="404">Usuário não encontrado</response>
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
                var usuario = await _usuarioService.GetById(id);

                if (usuario == null) return NotFound();

                await _usuarioService.Remove(usuario);

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Usuário registrado com sucesso</response>
        /// <response code="400">Erro ao registrar usuário</response>
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo, informe todos os campos exigidos e depois no botão "Execute" para testar o serviço.
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Incluir(UsuarioAddModel model)
        {
            try
            {
                await _usuarioService.Add(new Usuario
                {
                    Nome = model.Nome,
                    DataNascimento = model.DataNascimento,
                    Email = model.Email,
                    Celular = model.Celular,
                    EmailConfirmado = model.EmailConfirmado,
                    Administrador = model.Administrador,
                    Bloqueado = model.Bloqueado,
                    MotivoBloqueio = model.MotivoBloqueio,
                    LinkLinkedin = model.LinkLinkedin,
                    LinkGithub = model.LinkGithub,
                    Senha = "",
                    CodigoUsuarioCadastro = 0,
                    ProcessoCadastro = "UsuarioController.Incluir"
                });

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
        /// <remarks>
        /// Orientações de testes:
        /// 
        ///     Clique no botão "Try it out" abaixo, informe todos os campos exigidos e depois no botão "Execute" para testar o serviço.
        /// 
        ///     Dica: Utilize o serviço de listagem para encontrar um id para o teste.
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Editar(UsuarioModel model)
        {
            try
            {
                var usuario = await _usuarioService.FindAsNoTracking(model.IdUsuario);

                if (usuario == null) return NotFound();

                usuario = _mapper.Map<Usuario>(model);
                usuario.Senha = "";

                await _usuarioService.Update(usuario);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
