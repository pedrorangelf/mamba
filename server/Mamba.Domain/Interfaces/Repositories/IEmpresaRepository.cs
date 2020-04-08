using Mamba.Domain.Entities;
using System.Collections.Generic;

namespace Mamba.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {
        Empresa BuscarEmpresaPorId(int id);
    }
}
