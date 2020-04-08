using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class EmpresaService : ServiceBase<Empresa>, IEmpresaService
    {
        private readonly IEmpresaRepository _EmpresaRepository;

        public EmpresaService(IEmpresaRepository EmpresaRepository) : base(EmpresaRepository)
        {
            _EmpresaRepository = EmpresaRepository;
        }
    }
}
