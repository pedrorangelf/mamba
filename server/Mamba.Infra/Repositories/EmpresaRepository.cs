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
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ContextBase contextBase) : base(contextBase) { }

        public async Task<Empresa> ObterEmpresaUsuario(Guid idUsuario)
        {
            return await _contextBase.Empresa.AsNoTracking()
                            .Include(e => e.Cargos).ThenInclude(c => c.Funcionarios)
                            .FirstOrDefaultAsync(e => e.Cargos.Any(c => c.Funcionarios.Any(f => f.ApplicationUserId == idUsuario)));
        }
    }
}
