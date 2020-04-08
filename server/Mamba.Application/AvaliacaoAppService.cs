using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class AvaliacaoAppService : AppServiceBase<Avaliacao>, IAvaliacaoAppService
    {
        private readonly IAvaliacaoService _AvaliacaoService;

        public AvaliacaoAppService(IAvaliacaoService AvaliacaoService) : base(AvaliacaoService)
        {
            _AvaliacaoService = AvaliacaoService;
        }
    }
}
