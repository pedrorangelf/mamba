using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class RespostaService : ServiceBase<Resposta>, IRespostaService
    {
        private readonly IRespostaRepository _RespostaRepository;

        public RespostaService(IRespostaRepository RespostaRepository) : base(RespostaRepository)
        {
            _RespostaRepository = RespostaRepository;
        }
    }
}
