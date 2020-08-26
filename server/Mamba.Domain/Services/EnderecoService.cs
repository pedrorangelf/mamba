using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Interfaces;

namespace Mamba.Domain.Services
{
    public class EnderecoService : ServiceBase<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly INotificator _notificator;

        public EnderecoService(IEnderecoRepository enderecoRepository, INotificator notificator)
            : base(enderecoRepository, notificator)
        {
            _enderecoRepository = enderecoRepository;
            _notificator = notificator;
        }
    }
}
