using AutoMapper;
using Mamba.API.DTOs;
using Mamba.API.Extensions;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mamba.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/")]
    public class AuthController : MainController
    {
        private readonly ICargoService _cargoService;
        private readonly IFuncionarioService _funcionarioService;
        private readonly IEmpresaService _empresaService;
        private readonly IMapper _mapper;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public AuthController(INotificator notificator, IUser user, IEmpresaService empresaService, IMapper mapper,
                                SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
                                IOptions<JwtSettings> jwtSettings, IFuncionarioService funcionarioService, ICargoService cargoService)
            : base(notificator, user)
        {
            _empresaService = empresaService;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _funcionarioService = funcionarioService;
            _cargoService = cargoService;
        }

        [HttpPost("registrar-empresa")]
        public async Task<IActionResult> RegistrarEmpresa(RegistrarEmpresaViewModel registrarViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var identityUser = new ApplicationUser
            {
                Nome = registrarViewModel.Nome,
                Email = registrarViewModel.Email,
                UserName = registrarViewModel.Email,
                DataNascimento = registrarViewModel.DataNascimento,
                PhoneNumber = registrarViewModel.Celular,
                LinkLinkedin = registrarViewModel.LinkLinkedin,
                LinkGithub = registrarViewModel.LinkGithub,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(identityUser, registrarViewModel.Senha);
            if (result.Succeeded)
            {
                var empresa = _mapper.Map<Empresa>(registrarViewModel.Empresa);

                await _empresaService.Add(empresa);

                var cargo = new Cargo
                {
                    EmpresaId = empresa.Id,
                    Nome = registrarViewModel.Cargo
                };
                await _cargoService.Add(cargo);

                await _funcionarioService.Add(new Funcionario
                {
                    ApplicationUserId = identityUser.Id,
                    CargoId = cargo.Id
                });

                await _userManager.AddToRoleAsync(identityUser, "Empresa");

                await _signInManager.SignInAsync(identityUser, false);
                return CustomResponse(await GeraJWT(identityUser.Email));
            }

            foreach (var erro in result.Errors)
            {
                NotificarErro(erro.Description);
            }

            return CustomResponse();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
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


        private async Task<AuthResponseViewModel> GeraJWT(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

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

            var response = new AuthResponseViewModel
            {
                AcessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_jwtSettings.ExpiraEmHoras).TotalSeconds,
                User = new UserTokenViewModel
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimTokenViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
