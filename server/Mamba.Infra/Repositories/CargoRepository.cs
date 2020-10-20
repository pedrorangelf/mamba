using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamba.Infra.Repositories
{
    public class CargoRepository : RepositoryBase<Cargo>, ICargoRepository
    {
        public CargoRepository(ContextBase contextBase) : base(contextBase) { }

        public async Task<IEnumerable<Cargo>> ObterCargosEmpresa(Guid empresaId)
        {
            return await _contextBase.Cargo.AsNoTracking()
                    .Where(c => c.EmpresaId == empresaId)
                    .OrderBy(c => c.Nome).ToListAsync();
        }
    }
}
