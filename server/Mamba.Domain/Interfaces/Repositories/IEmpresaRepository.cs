using Mamba.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {
        Task<Empresa> ObterEmpresaUsuario(Guid idUsuario);
    }
}
