using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class EmpresaAppService : AppServiceBase<Empresa>, IEmpresaAppService
    {
        private readonly IEmpresaService _EmpresaService;

        public EmpresaAppService(IEmpresaService EmpresaService) : base(EmpresaService)
        {
            _EmpresaService = EmpresaService;
        }
    }
}
