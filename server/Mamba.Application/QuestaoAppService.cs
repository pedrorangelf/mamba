using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class QuestaoAppService : AppServiceBase<Questao>, IQuestaoAppService
    {
        private readonly IQuestaoService _QuestaoService;

        public QuestaoAppService(IQuestaoService QuestaoService) : base(QuestaoService)
        {
            _QuestaoService = QuestaoService;
        }
    }
}
