using Mamba.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository : IRepositoryBase<Funcionario>
    {
        Task<Funcionario> ObterFuncionarioUsuario(Guid idUsuario);
    }
}
