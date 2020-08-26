using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mamba.Domain.Services
{
    public class EmpresaService : ServiceBase<Empresa>, IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly INotificator _notificator;

        public EmpresaService(IEmpresaRepository EmpresaRepository, INotificator notificator) : base(EmpresaRepository, notificator)
        {
            _empresaRepository = EmpresaRepository;
            _notificator = notificator;
        }

        public override Task Add(Empresa obj)
        {
            if (_empresaRepository.FindBy(e => e.CNPJ == obj.CNPJ).Any())
                Notificar("Já existe uma empresa registrada com o CNPJ informado.");

            return base.Add(obj);
        }

        public async Task<Empresa> ObterEmpresaUsuario(Guid idUsuario)
        {
            return await _empresaRepository.ObterEmpresaUsuario(idUsuario);
        }

        public override Task Update(Empresa obj)
        {
            if (_empresaRepository.FindBy(e => e.CNPJ == obj.CNPJ && e.Id != obj.Id).Any())
                Notificar("Já existe uma empresa registrada com o CNPJ informado.");

            return base.Update(obj);
        }

    }
}
