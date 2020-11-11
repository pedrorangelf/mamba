using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Mamba.Domain.Services
{
    public class DesafioService : ServiceBase<Desafio>, IDesafioService
    {
        private readonly IQuestaoService _questaoService;
        private readonly IDesafioRepository _desafioRepository;
        private readonly INotificator _notificator;

        public DesafioService(IDesafioRepository DesafioRepository,
                              INotificator notificator,
                              IQuestaoService questaoService) : base(DesafioRepository, notificator)
        {
            _desafioRepository = DesafioRepository;
            _notificator = notificator;
            _questaoService = questaoService;
        }

        public async Task<Desafio> ObterDesafioCargoInscricoes(Guid id)
        {
            return await _desafioRepository.ObterDesafioCargoInscricoes(id);
        }


        public async Task<Desafio> ObterDesafioQuestoes(Guid id)
        {
            return await _desafioRepository.ObterDesafioQuestoes(id);
        }

        public async Task<IEnumerable<Desafio>> ObterDesafiosEmpresa(Guid idEmpresa)
        {
            return await _desafioRepository.ObterDesafiosEmpresa(idEmpresa);
        }

        public async Task<Desafio> ObterDesafioEmpresa(Guid idDesafio)
        {
            return await _desafioRepository.ObterDesafioEmpresa(idDesafio);
        }

        public override async Task Remove(Desafio obj)
        {
            var questoesDesafio = await _questaoService.ObterQuestoesDesafio(obj.Id);
            if (questoesDesafio.Count() > 0)
                await _questaoService.RemoveInScale(questoesDesafio);

            await base.Remove(obj);
        }
    }
}
