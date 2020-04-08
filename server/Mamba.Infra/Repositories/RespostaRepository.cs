using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;

namespace Mamba.Infra.Repositories
{
    public class RespostaRepository : RepositoryBase<Resposta>, IRespostaRepository
    {
        public RespostaRepository(ContextBase contextBase) : base(contextBase)
        {
        }
    }
}
