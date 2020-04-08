using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class CargoAppService : AppServiceBase<Cargo>, ICargoAppService
    {
        private readonly ICargoService _CargoService;

        public CargoAppService(ICargoService CargoService) : base(CargoService)
        {
            _CargoService = CargoService;
        }
    }
}
