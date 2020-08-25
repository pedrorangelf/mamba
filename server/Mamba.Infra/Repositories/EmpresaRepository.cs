using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace Mamba.Infra.Repositories
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ContextBase contextBase) : base(contextBase) { }
    }
}
