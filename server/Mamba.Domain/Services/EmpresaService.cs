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

        public void Salvar(Empresa empresa)
        {
            try
            {
                if (empresa.IdEmpresa > 0)
                {
                    _EmpresaRepository.Update(empresa);
                }
                else
                {
                    _EmpresaRepository.Add(empresa);
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
