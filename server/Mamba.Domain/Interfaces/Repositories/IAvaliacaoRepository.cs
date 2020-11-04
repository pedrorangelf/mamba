using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Repositories
{
    public interface IAvaliacaoRepository : IRepositoryBase<Avaliacao>
    {
        Task<List<Avaliacao>> ObterAvaliacoesResposta(Guid respostaId);
    }
}
