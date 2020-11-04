using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Repositories
{
    public interface IQuestaoRepository : IRepositoryBase<Questao>
    {
        Task<IEnumerable<Questao>> ObterQuestoesDesafio(Guid desafioId);
        Task<IEnumerable<Questao>> ObterQuestoesDeletadas(Guid desafioId, Guid[] questoesAdicionadas);
    }
}
