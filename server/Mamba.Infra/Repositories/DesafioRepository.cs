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

        public async Task<Desafio> ObterDesafioQuestoes(Guid id)
        {
            return await _contextBase.Desafio.AsNoTracking()
                    .Include(d => d.Questoes)
                    .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Desafio> ObterDesafioCargoInscricoes(Guid id)
        {
            return await _contextBase.Desafio.AsNoTracking()
                    .Include(d => d.Cargo)
                    .Include(d => d.Inscricoes)
                    .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Desafio>> ObterDesafiosEmpresa(Guid idEmpresa)
        {
            return await _contextBase.Desafio.AsNoTracking()
                            .Include(d => d.Cargo)
                            .Include(d => d.Inscricoes).ThenInclude(i => i.Respostas).ThenInclude(r => r.Avaliacao)
                            .Where(d => d.EmpresaId == idEmpresa)
                            .ToListAsync();
        }

        public async Task<Desafio> ObterDesafioEmpresa(Guid idDesafio)
        {
            return await _contextBase.Desafio.AsNoTracking()
                            .Include(d => d.Cargo)
                            .Include(d => d.Inscricoes).ThenInclude(i => i.Respostas).ThenInclude(r => r.Avaliacao)
                            .FirstOrDefaultAsync(d => d.Id == idDesafio);
        }
    }
}
