using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Mamba.Domain.Services
{
    public class DesafioService : ServiceBase<Desafio>, IDesafioService
    {
        private readonly IDesafioRepository _desafioRepository;
        private readonly INotificator _notificator;

        public DesafioService(IDesafioRepository DesafioRepository, INotificator notificator) : base(DesafioRepository, notificator)
        {
            _desafioRepository = DesafioRepository;
            _notificator = notificator;
        }

        public async Task<IEnumerable<Desafio>> ObterDesafiosEmpresa(Guid idEmpresa)
        {
            return await _desafioRepository.ObterDesafiosEmpresa(idEmpresa);
        }
    }
}
