using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Services
{
    public interface IQuestaoService : IServiceBase<Questao>
    {
        Task<IEnumerable<Questao>> ObterQuestoesDesafio(Guid desafioId);
    }
}
