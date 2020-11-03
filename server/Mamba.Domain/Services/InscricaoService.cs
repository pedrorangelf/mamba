using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Mamba.Domain.Services
{
    public class InscricaoService : ServiceBase<Inscricao>, IInscricaoService
    {
        private readonly IInscricaoRepository _inscricaoRepository;
        private readonly INotificator _notificator;

        public InscricaoService(IInscricaoRepository InscricaoRepository, INotificator notificator) : base(InscricaoRepository, notificator)
        {
            _inscricaoRepository = InscricaoRepository;
            _notificator = notificator;
        }

        public async Task<Inscricao> ObterInscricaoDetalhada(Guid id)
        {
            return await _inscricaoRepository.ObterInscricaoDetalhada(id);
        }

        public async Task<IEnumerable<Inscricao>> ObterInscricoesDesafioCandidato(Guid idDesafio)
        {
            return await _inscricaoRepository.ObterInscricoesDesafioCandidato(idDesafio);
        }
    }
}
