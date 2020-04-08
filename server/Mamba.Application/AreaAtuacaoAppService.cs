using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class AreaAtuacaoAppService : AppServiceBase<AreaAtuacao>, IAreaAtuacaoAppService
    {
        private readonly IAreaAtuacaoService _areaAtuacaoService;

        public AreaAtuacaoAppService(IAreaAtuacaoService areaAtuacaoService) : base(areaAtuacaoService)
        {
            _areaAtuacaoService = areaAtuacaoService;
        }
    }
}
