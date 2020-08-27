using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Repositories
{
    public interface IInscricaoRepository : IRepositoryBase<Inscricao>
    {
        Task<IEnumerable<Inscricao>> ObterInscricoesDesafioCandidato(Guid idDesafio);
    }
}
