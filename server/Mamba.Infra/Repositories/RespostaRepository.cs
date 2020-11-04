using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamba.Infra.Repositories
{
    public class RespostaRepository : RepositoryBase<Resposta>, IRespostaRepository
    {
        public RespostaRepository(ContextBase contextBase) : base(contextBase)
        {
        }


        public async Task<IEnumerable<Resposta>> ObterRespostasQuestao(Guid questaoId)
        {
            return await _contextBase.Resposta
                            .Where(r => r.QuestaoId == questaoId)
                            .ToListAsync();
        }
    }
}
