using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Services
{
    public interface ICargoService : IServiceBase<Cargo>
    {
        Task<IEnumerable<Cargo>> ObterCargosEmpresa(Guid empresaId);
    }
}
