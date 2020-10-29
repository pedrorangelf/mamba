using AutoMapper;
using Mamba.API.DTOs.Responses;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamba.API.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/cargo")]
    public class CargoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ICargoService _cargoService;

        public CargoController(INotificator notificator,
                                  IUser user,
                                  ICargoService cargoService,
                                  IMapper mapper) : base(notificator, user)
        {
            _cargoService = cargoService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Empresa")]
        [HttpGet]
        [SwaggerOperation("Retorna todos os cargos cadastrados da empresa do usuário")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna os cargos cadastrados da empresa do usuário", typeof(OkCustomResponse<IEnumerable<CargoResponse>>))]
        public async Task<IActionResult> ObterTodos()
        {
            var cargos = await _cargoService.ObterCargosEmpresa(EmpresaId);

            return CustomResponse(_mapper.Map<IEnumerable<CargoResponse>>(cargos));
        }
    }
}
