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
    public class AvaliacaoRepository : RepositoryBase<Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(ContextBase contextBase) : base(contextBase)
        {
        }

        public async Task<List<Avaliacao>> ObterAvaliacoesResposta(Guid respostaId)
        {
            return await _contextBase.Avaliacao
                            .Where(a => a.RespostaId == respostaId)
                            .ToListAsync();
        }
    }
}
