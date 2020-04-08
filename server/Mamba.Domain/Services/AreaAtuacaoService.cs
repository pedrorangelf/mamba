using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class AreaAtuacaoService : ServiceBase<AreaAtuacao>, IAreaAtuacaoService
    {
        private readonly IAreaAtuacaoRepository _areaAtuacaoRepository;

        public AreaAtuacaoService(IAreaAtuacaoRepository areaAtuacaoRepository) :base(areaAtuacaoRepository)
        {
            _areaAtuacaoRepository = areaAtuacaoRepository;
        }
    }
}
