using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Interfaces;

namespace Mamba.Domain.Services
{
    public class QuestaoService : ServiceBase<Questao>, IQuestaoService
    {
        private readonly IQuestaoRepository _questaoRepository;
        private readonly INotificator _notificator;

        public QuestaoService(IQuestaoRepository QuestaoRepository, INotificator notificator) : base(QuestaoRepository, notificator)
        {
            _questaoRepository = QuestaoRepository;
            _notificator = notificator;
        }
    }
}
