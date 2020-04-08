using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;

namespace Mamba.Infra.Repositories
{
    public class CandidatoRepository : RepositoryBase<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(ContextBase contextBase) : base(contextBase)
        {
        }
    }
}
