using Mamba.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Services
{
    public interface IFuncionarioService : IServiceBase<Funcionario>
    {
        Task<Funcionario> ObterFuncionarioUsuario(Guid idUsuario);
    }
}
