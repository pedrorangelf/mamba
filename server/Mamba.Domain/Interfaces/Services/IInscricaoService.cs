using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Services
{
    public interface IInscricaoService : IServiceBase<Inscricao>
    {
        Task<IEnumerable<Inscricao>> ObterInscricoesDesafioCandidato(Guid idDesafio);
        Task<Inscricao> ObterInscricaoDetalhada(Guid id);
    }
}
