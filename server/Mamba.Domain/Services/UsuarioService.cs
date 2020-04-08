using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public UsuarioService(IUsuarioRepository UsuarioRepository) : base(UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }
    }
}
