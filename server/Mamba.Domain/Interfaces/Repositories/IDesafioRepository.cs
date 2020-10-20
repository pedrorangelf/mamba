using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Repositories
{
    public interface IDesafioRepository : IRepositoryBase<Desafio>
    {
        Task<Desafio> ObterDesafioQuestoes(Guid id);
        Task<IEnumerable<Desafio>> ObterDesafiosEmpresa(Guid idEmpresa);
        Task<Desafio> ObterDesafioCargoInscricoes(Guid id);
    }
}
