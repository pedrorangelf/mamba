using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class CargoService : ServiceBase<Cargo>, ICargoService
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoService(ICargoRepository CargoRepository) : base(CargoRepository)
        {
            _cargoRepository = CargoRepository;
        }
    }
}
