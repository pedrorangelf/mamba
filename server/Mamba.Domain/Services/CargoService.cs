using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Services
{
    public class CargoService : ServiceBase<Cargo>, ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly INotificator _notificator;

        public CargoService(ICargoRepository CargoRepository, INotificator notificator) : base(CargoRepository, notificator)
        {
            _cargoRepository = CargoRepository;
            _notificator = notificator;
        }

        public async Task<IEnumerable<Cargo>> ObterCargosEmpresa(Guid empresaId)
        {
            return await _cargoRepository.ObterCargosEmpresa(empresaId);
        }
    }
}
