using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;

namespace Mamba.Infra.Repositories
{
    public class AvaliacaoRepository : RepositoryBase<Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(ContextBase contextBase) : base(contextBase)
        {
        }
    }
}
