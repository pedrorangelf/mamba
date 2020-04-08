using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class InscricaoAppService : AppServiceBase<Inscricao>, IInscricaoAppService
    {
        private readonly IInscricaoService _InscricaoService;

        public InscricaoAppService(IInscricaoService InscricaoService) : base(InscricaoService)
        {
            _InscricaoService = InscricaoService;
        }
    }
}
