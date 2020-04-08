using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class CandidatoService : ServiceBase<Candidato>, ICandidatoService
    {
        private readonly ICandidatoRepository _CandidatoRepository;

        public CandidatoService(ICandidatoRepository CandidatoRepository) : base(CandidatoRepository)
        {
            _CandidatoRepository = CandidatoRepository;
        }
    }
}
