using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Repositories
{
    public interface IRespostaRepository : IRepositoryBase<Resposta>
    {
        Task<IEnumerable<Resposta>> ObterRespostasQuestao(Guid questaoId);
    }
}
