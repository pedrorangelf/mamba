using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class RespostaService : ServiceBase<Resposta>, IRespostaService
    {
        private readonly IRespostaRepository _respostaRepository;
        private readonly INotificator _notificator;

        public RespostaService(IRespostaRepository RespostaRepository, INotificator notificator) : base(RespostaRepository, notificator)
        {
            _respostaRepository = RespostaRepository;
            _notificator = notificator;
        }
    }
}
