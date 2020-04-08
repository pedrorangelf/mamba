using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;

namespace Mamba.Infra.Repositories
{
    public class QuestaoRepository : RepositoryBase<Questao>, IQuestaoRepository
    {
        public QuestaoRepository(ContextBase contextBase) : base(contextBase)
        {
        }
    }
}
