using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Services
{
    public interface IDesafioService : IServiceBase<Desafio>
    {
        Task<IEnumerable<Desafio>> ObterDesafiosEmpresa(Guid idEmpresa);
    }
}
