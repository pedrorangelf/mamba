using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class CandidatoAppService : AppServiceBase<Candidato>, ICandidatoAppService
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatoAppService(ICandidatoService CandidatoService) : base(CandidatoService)
        {
            _candidatoService = CandidatoService;
        }
    }
}
