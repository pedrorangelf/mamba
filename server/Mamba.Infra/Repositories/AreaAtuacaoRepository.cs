using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;

namespace Mamba.Infra.Repositories
{
    public class AreaAtuacaoRepository : RepositoryBase<AreaAtuacao>, IAreaAtuacaoRepository
    {
        public AreaAtuacaoRepository(ContextBase contextBase) : base(contextBase)
        {
        }
    }
}
