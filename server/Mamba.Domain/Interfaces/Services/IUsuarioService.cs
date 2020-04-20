using Mamba.Domain.Entities;

namespace Mamba.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        void Salvar(Usuario usuario);
    }
}
