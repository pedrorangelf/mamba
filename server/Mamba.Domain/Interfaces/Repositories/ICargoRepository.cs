﻿using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Repositories
{
    public interface ICargoRepository : IRepositoryBase<Cargo>
    {
        Task<IEnumerable<Cargo>> ObterCargosEmpresa(Guid empresaId);
    }
}
