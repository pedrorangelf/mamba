using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class DesafioService : ServiceBase<Desafio>, IDesafioService
    {
        private readonly IDesafioRepository _DesafioRepository;

        public DesafioService(IDesafioRepository DesafioRepository) : base(DesafioRepository)
        {
            _DesafioRepository = DesafioRepository;
        }
    }
}
