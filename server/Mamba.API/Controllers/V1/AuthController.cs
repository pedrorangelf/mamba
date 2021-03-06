﻿using AutoMapper;
using Mamba.API.DTOs;
using Mamba.API.DTOs.Requests;
using Mamba.API.DTOs.Responses;
using Mamba.API.Extensions;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mamba.API.Controllers.V1
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/")]
    public class AuthController : MainController
    {
        private readonly IEnderecoService _enderecoService;
        private readonly ICandidatoService _candidatoService;
        private readonly ICargoService _cargoService;
        private readonly IFuncionarioService _funcionarioService;
        private readonly IEmpresaService _empresaService;
        private readonly IMapper _mapper;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public AuthController(INotificator notificator,
                              IUser user,
                              IEmpresaService empresaService,
                              IMapper mapper,
                              SignInManager<ApplicationUser> signInManager,
                              UserManager<ApplicationUser> userManager,
                              IOptions<JwtSettings> jwtSettings,
                              IFuncionarioService funcionarioService,
                              ICargoService cargoService,
                              ICandidatoService candidatoService,
                              IEnderecoService enderecoService)
            : base(notificator, user)
        {
            _empresaService = empresaService;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _funcionarioService = funcionarioService;
            _cargoService = cargoService;
            _candidatoService = candidatoService;
            _enderecoService = enderecoService;
        }

        [HttpPost("registrar-empresa")]
        [SwaggerOperation("Registra um novo usuário e empresa")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o token de acesso e os dados do usuário cadastrado", typeof(OkCustomResponse<AuthResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erros de validação da ModelState", typeof(BadRequestCustomResponse))]
        public async Task<IActionResult> RegistrarEmpresa(NovoFuncionarioRequest novoFuncionarioDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var empresa = _mapper.Map<Empresa>(novoFuncionarioDto.Empresa);
            await _empresaService.Add(empresa);

            if (!OperacaoValida()) return CustomResponse();

            var identityUser = new ApplicationUser
            {
                DataNascimento = novoFuncionarioDto.DataNascimento,
                Email = novoFuncionarioDto.Email,
                EmailConfirmed = true,
                LinkGithub = novoFuncionarioDto.LinkGithub,
                LinkLinkedin = novoFuncionarioDto.LinkLinkedin,
                Nome = novoFuncionarioDto.Nome,
                PhoneNumber = novoFuncionarioDto.Celular,
                PhoneNumberConfirmed = true,
                UserName = novoFuncionarioDto.Email
            };

            var result = await _userManager.CreateAsync(identityUser, novoFuncionarioDto.Senha);
            if (result.Succeeded)
            {
                var cargo = new Cargo
                {
                    EmpresaId = empresa.Id,
                    Nome = novoFuncionarioDto.Cargo
                };
                await _cargoService.Add(cargo);

                await _funcionarioService.Add(new Funcionario
                {
                    ApplicationUserId = identityUser.Id,
                    CargoId = cargo.Id
                });

                await _userManager.AddToRoleAsync(identityUser, "Empresa");

                return CustomResponse(await GeraJWT(identityUser.Email));
            }

            await _empresaService.Remove(empresa);
            await _enderecoService.Remove(empresa.Endereco);

            foreach (var erro in result.Errors)
            {
                NotificarErro(erro.Description);
            }

            return CustomResponse();
        }

        [HttpPost("registrar-candidato")]
        [SwaggerOperation("Registra um novo candidato")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o token de acesso e os dados do usuário cadastrado", typeof(OkCustomResponse<AuthResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erros de validação da ModelState", typeof(BadRequestCustomResponse))]
        public async Task<IActionResult> RegistrarCandidato(NovoCandidatoRequest novoCandidatoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new ApplicationUser
            {
                DataNascimento = novoCandidatoDto.DataNascimento,
                Email = novoCandidatoDto.Email,
                EmailConfirmed = true,
                LinkGithub = novoCandidatoDto.LinkGithub,
                LinkLinkedin = novoCandidatoDto.LinkLinkedin,
                Nome = novoCandidatoDto.Nome,
                PhoneNumber = novoCandidatoDto.Celular,
                PhoneNumberConfirmed = true,
                UserName = novoCandidatoDto.Email
            };

            var result = await _userManager.CreateAsync(user, novoCandidatoDto.Senha);
            if (result.Succeeded)
            {
                await _candidatoService.Add(new Candidato
                {
                    ApplicationUserId = user.Id,
                    Profissao = novoCandidatoDto.Profissao,
                    Endereco = _mapper.Map<Endereco>(novoCandidatoDto.Endereco)
                });

                await _userManager.AddToRoleAsync(user, "Candidato");

                return CustomResponse(await GeraJWT(user.Email));
            }

            foreach (var erro in result.Errors)
            {
                NotificarErro(erro.Description);
            }

            return CustomResponse();
        }

        [HttpPost("login")]
        [SwaggerOperation("Efetua a autenticação do usuário")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o token de acesso e os dados do usuário cadastrado", typeof(OkCustomResponse<AuthResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erros de validação da ModelState", typeof(BadRequestCustomResponse))]
        public async Task<IActionResult> Login(LoginRequest loginViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Senha, false, true);
            if (result.Succeeded)
            {
                return CustomResponse(await GeraJWT(loginViewModel.Email));
            }
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário bloqueado temporariamente por várias tentativas de login.");
                return CustomResponse();
            }

            NotificarErro("E-mail e/ou senha incorretos. Usuário não encontrado.");
            return CustomResponse();
        }

        private async Task<AuthResponse> GeraJWT(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Empresa"))
            {
                var empresa = await _empresaService.ObterEmpresaUsuario(user.Id);

                if (empresa != null)
                    claims.Add(new Claim("EmpresaId", empresa.Id.ToString()));
            }

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaims(claims);

            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Emissor,
                Audience = _jwtSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiraEmHoras),
                Subject = claimsIdentity,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new AuthResponse
            {
                AcessToken = encodedToken,
                ExpiresIn = TimeSpan.FromDays(365).TotalSeconds,
                //ExpiresIn = TimeSpan.FromHours(_jwtSettings.ExpiraEmHoras).TotalSeconds,
                User = new UserTokenViewModel
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    Nome = user.Nome,
                    Foto = user.Foto,
                    Claims = claims.Select(c => new ClaimTokenViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
