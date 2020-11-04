using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Services
{
    public interface IRespostaService : IServiceBase<Resposta>
    {
        Task<IEnumerable<Resposta>> ObterRespostasQuestao(Guid questaoId);
    }
}
