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
                                     .Include(i => i.Respostas).ThenInclude(r => r.Avaliacao)
                                     .Where(i => i.DesafioId == idDesafio)
                                     .ToListAsync();
        }

        public async Task<Inscricao> ObterInscricaoDetalhada(Guid id)
        {
            return await _contextBase.Inscricao.AsNoTracking()
                            .Include(i => i.Candidato).ThenInclude(c => c.ApplicationUser)
                            .Include(i => i.Desafio).ThenInclude(d => d.Cargo)
                            .Include(i => i.Desafio)
                                .ThenInclude(d => d.Questoes)
                                .ThenInclude(q => q.Respostas)
                                .ThenInclude(r => r.Avaliacao)
                                .ThenInclude(a => a.Funcionario)
                                .ThenInclude(f => f.ApplicationUser)
                            .Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}
