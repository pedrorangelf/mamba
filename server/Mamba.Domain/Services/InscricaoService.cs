using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Domain.Services
{
    public class InscricaoService : ServiceBase<Inscricao>, IInscricaoService
    {
        private readonly IInscricaoRepository _inscricaoRepository;

        public InscricaoService(IInscricaoRepository InscricaoRepository) : base(InscricaoRepository)
        {
            _inscricaoRepository = InscricaoRepository;
        }
    }
}
