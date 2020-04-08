using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;

namespace Mamba.Infra.Repositories
{
    public class CidadeRepository : RepositoryBase<Cidade>, ICidadeRepository
    {
        public CidadeRepository(ContextBase contextBase) : base(contextBase)
        {
        }
    }
}
