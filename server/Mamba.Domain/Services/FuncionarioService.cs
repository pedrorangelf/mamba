using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class FuncionarioService : ServiceBase<Funcionario>, IFuncionarioService
    {
        private readonly IFuncionarioRepository _FuncionarioRepository;

        public FuncionarioService(IFuncionarioRepository FuncionarioRepository) : base(FuncionarioRepository)
        {
            _FuncionarioRepository = FuncionarioRepository;
        }
    }
}
