using AutoMapper;
using Mamba.API.DTOs;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamba.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountController : MainController
    {
        private readonly IEstadoService _estadoService;
        private readonly IMapper _mapper;

        public AccountController(INotificator notificator, IUser user, IEstadoService estadoService, IMapper mapper) : base(notificator, user)
        {
            _estadoService = estadoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<EstadoViewModel>> Get()
        {
            return _mapper.Map<IEnumerable<EstadoViewModel>>(await _estadoService.GetAll()).ToList();
        }
    }
}
