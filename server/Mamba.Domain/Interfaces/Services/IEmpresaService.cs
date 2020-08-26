using Mamba.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Services
{
    public interface IEmpresaService : IServiceBase<Empresa>
    {
        Task<Empresa> ObterEmpresaUsuario(Guid idUsuario);
    }
}
