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
    public class DesafioRepository : RepositoryBase<Desafio>, IDesafioRepository
    {
        public DesafioRepository(ContextBase contextBase) : base(contextBase) { }

        public async Task<IEnumerable<Desafio>> ObterDesafiosEmpresa(Guid idEmpresa)
        {
            return await _contextBase.Desafio.AsNoTracking()
                            .Include(d => d.Cargo)
                            .Include(d => d.Inscricoes)
                            .Where(d => d.EmpresaId == idEmpresa)
                            .ToListAsync();
        }
    }
}
