using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Interfaces;

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
    }
}
