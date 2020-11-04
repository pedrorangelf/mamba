using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Mamba.Domain.Services
{
    public class AvaliacaoService : ServiceBase<Avaliacao>, IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly INotificator _notificator;

        public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository, INotificator notificator) : base(avaliacaoRepository, notificator)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _notificator = notificator;
        }

        public async Task<List<Avaliacao>> ObterAvaliacoesResposta(Guid respostaId)
        {
            return await _avaliacaoRepository.ObterAvaliacoesResposta(respostaId);
        }
    }
}
