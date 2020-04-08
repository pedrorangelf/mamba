using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;

namespace Mamba.Infra.Repositories
{
    public class InscricaoRepository : RepositoryBase<Inscricao>, IInscricaoRepository
    {
        public InscricaoRepository(ContextBase contextBase) : base(contextBase)
        {
        }
    }
}
