using System;
using System.Collections.Generic;

namespace Mamba.API.Controllers.DTOs.Requests
{
    public class AvaliacaoRequest
    {
        public Guid DesafioId { get; set; }
        public Guid InscricaoId { get; set; }
        public bool CandidatoAprovado { get; set; }
        public string ParecerFinal { get; set; }
        public List<AvaliacaoQuestaoRequest> Avaliacoes { get; set; }
    }

    public class AvaliacaoQuestaoRequest
    {
        public Guid RespostaId { get; set; }
        public bool Correta { get; set; }
        public string Descricao { get; set; }
    }
}
