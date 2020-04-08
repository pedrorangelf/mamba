using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class FuncionarioAppService : AppServiceBase<Funcionario>, IFuncionarioAppService
    {
        private readonly IFuncionarioService _FuncionarioService;

        public FuncionarioAppService(IFuncionarioService FuncionarioService) : base(FuncionarioService)
        {
            _FuncionarioService = FuncionarioService;
        }
    }
}
