using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository _CidadeRepository;

        public CidadeService(ICidadeRepository CidadeRepository) : base(CidadeRepository)
        {
            _CidadeRepository = CidadeRepository;
        }
    }
}
