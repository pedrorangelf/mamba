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
    public class InscricaoRepository : RepositoryBase<Inscricao>, IInscricaoRepository
    {
        public InscricaoRepository(ContextBase contextBase) : base(contextBase)
        {
        }

        public async Task<IEnumerable<Inscricao>> ObterInscricoesDesafioCandidato(Guid idDesafio)
        {
            return await _contextBase.Inscricao.AsNoTracking()
                                     .Include(i => i.Candidato).ThenInclude(c => c.ApplicationUser)
                                     .Where(i => i.DesafioId == idDesafio)
                                     .ToListAsync();
        }
    }
}
