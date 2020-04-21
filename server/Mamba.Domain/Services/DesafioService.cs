using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Mamba.Domain.Services
{
    public class DesafioService : ServiceBase<Desafio>, IDesafioService
    {
        private readonly IDesafioRepository _desafioRepository;

        public DesafioService(IDesafioRepository DesafioRepository) : base(DesafioRepository)
        {
            _desafioRepository = DesafioRepository;
        }

    }
}
