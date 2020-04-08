using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class EstadoService : ServiceBase<Estado>, IEstadoService
    {
        private readonly IEstadoRepository _EstadoRepository;

        public EstadoService(IEstadoRepository EstadoRepository) : base(EstadoRepository)
        {
            _EstadoRepository = EstadoRepository;
        }
    }
}
