using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class QuestaoService : ServiceBase<Questao>, IQuestaoService
    {
        private readonly IQuestaoRepository _questaoRepository;

        public QuestaoService(IQuestaoRepository QuestaoRepository) : base(QuestaoRepository)
        {
            _questaoRepository = QuestaoRepository;
        }
    }
}
