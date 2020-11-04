using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Mamba.Domain.Services
{
    public class QuestaoService : ServiceBase<Questao>, IQuestaoService
    {
        private readonly IRespostaService _respostaService;
        private readonly IQuestaoRepository _questaoRepository;
        private readonly INotificator _notificator;

        public QuestaoService(IQuestaoRepository QuestaoRepository,
                              INotificator notificator,
                              IRespostaService respostaService) : base(QuestaoRepository, notificator)
        {
            _questaoRepository = QuestaoRepository;
            _notificator = notificator;
            _respostaService = respostaService;
        }

        public async Task<IEnumerable<Questao>> ObterQuestoesDeletadas(Guid desafioId, Guid[] questoesAdicionadas)
        {
            return await _questaoRepository.ObterQuestoesDeletadas(desafioId, questoesAdicionadas);
        }

        public async Task<IEnumerable<Questao>> ObterQuestoesDesafio(Guid desafioId)
        {
            return await _questaoRepository.ObterQuestoesDesafio(desafioId);
        }

        public override async Task Remove(Questao obj)
        {
            if (PossuiNotificacao())
                return;

            var respostasQuestao = await _respostaService.ObterRespostasQuestao(obj.Id);
            if(respostasQuestao.Count() > 0) await _respostaService.RemoveInScale(respostasQuestao);

            await base.Remove(obj);
        }
    }
}
