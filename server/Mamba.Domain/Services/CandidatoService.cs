using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Interfaces;

namespace Mamba.Domain.Services
{
    public class CandidatoService : ServiceBase<Candidato>, ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly INotificator _notificator;

        public CandidatoService(ICandidatoRepository CandidatoRepository, INotificator notificator) : base(CandidatoRepository, notificator)
        {
            _candidatoRepository = CandidatoRepository;
            _notificator = notificator;
        }
    }
}
