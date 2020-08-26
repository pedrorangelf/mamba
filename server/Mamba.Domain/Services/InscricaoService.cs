using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Interfaces;

namespace Mamba.Domain.Services
{
    public class InscricaoService : ServiceBase<Inscricao>, IInscricaoService
    {
        private readonly IInscricaoRepository _inscricaoRepository;
        private readonly INotificator _notificator;

        public InscricaoService(IInscricaoRepository InscricaoRepository, INotificator notificator) : base(InscricaoRepository, notificator)
        {
            _inscricaoRepository = InscricaoRepository;
            _notificator = notificator;
        }
    }
}
