using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

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

        public async Task<IEnumerable<Questao>> ObterQuestoesDesafio(Guid desafioId)
        {
            return await _questaoRepository.ObterQuestoesDesafio(desafioId);
        }
    }
}
