using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class QuestaoAppService : AppServiceBase<Questao>, IQuestaoAppService
    {
        private readonly IQuestaoService _questaoService;

        public QuestaoAppService(IQuestaoService QuestaoService) : base(QuestaoService)
        {
            _questaoService = QuestaoService;
        }
    }
}
