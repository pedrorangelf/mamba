using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Services
{
    public class RespostaService : ServiceBase<Resposta>, IRespostaService
    {
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IRespostaRepository _respostaRepository;
        private readonly INotificator _notificator;

        public RespostaService(IRespostaRepository RespostaRepository, INotificator notificator) : base(RespostaRepository, notificator)
        {
            _respostaRepository = RespostaRepository;
            _notificator = notificator;
        }

        public async Task<IEnumerable<Resposta>> ObterRespostasQuestao(Guid questaoId)
        {
            return await _respostaRepository.ObterRespostasQuestao(questaoId);
        }

        public override async Task Remove(Resposta obj)
        {
            if (PossuiNotificacao())
                return;

            var avaliacoesResposta = await _avaliacaoService.ObterAvaliacoesResposta(obj.Id);
            if (avaliacoesResposta.Count > 0) await _avaliacaoService.RemoveInScale(avaliacoesResposta);

            await base.Remove(obj);
        }
    }
}
