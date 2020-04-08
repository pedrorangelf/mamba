using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _UsuarioService;

        public UsuarioAppService(IUsuarioService UsuarioService) : base(UsuarioService)
        {
            _UsuarioService = UsuarioService;
        }
    }
}
