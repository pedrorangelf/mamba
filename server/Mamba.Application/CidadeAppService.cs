using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class CidadeAppService : AppServiceBase<Cidade>, ICidadeAppService
    {
        private readonly ICidadeService _CidadeService;

        public CidadeAppService(ICidadeService CidadeService) : base(CidadeService)
        {
            _CidadeService = CidadeService;
        }
    }
}
