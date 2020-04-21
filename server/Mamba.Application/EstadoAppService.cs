using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class EstadoAppService : AppServiceBase<Estado>, IEstadoAppService
    {
        private readonly IEstadoService _estadoService;

        public EstadoAppService(IEstadoService EstadoService) : base(EstadoService)
        {
            _estadoService = EstadoService;
        }
    }
}
