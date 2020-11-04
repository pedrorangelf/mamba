using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Services
{
    public interface IAvaliacaoService : IServiceBase<Avaliacao>
    {
        Task<List<Avaliacao>> ObterAvaliacoesResposta(Guid respostaId);
    }
}
