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
    public class QuestaoRepository : RepositoryBase<Questao>, IQuestaoRepository
    {
        public QuestaoRepository(ContextBase contextBase) : base(contextBase)
        {
        }

        public async Task<IEnumerable<Questao>> ObterQuestoesDesafio(Guid desafioId)
        {
            return await _contextBase.Questao.Where(q => q.DesafioId == desafioId).ToListAsync();
        }

        public async Task<IEnumerable<Questao>> ObterQuestoesDeletadas(Guid desafioId, Guid[] questoesAdicionadas)
        {
            return await _contextBase.Questao
                            .Where(q => q.DesafioId == desafioId && !questoesAdicionadas.Contains(q.Id))
                            .ToListAsync();
        }
    }
}
