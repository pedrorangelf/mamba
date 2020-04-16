using Mamba.Domain.Entities;

namespace Mamba.Domain.Interfaces.Services
{
    public interface IEmpresaService : IServiceBase<Empresa>
    {
        void Salvar(Empresa empresa);
    }
}
