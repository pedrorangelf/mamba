using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Domain
{
    public class RespostaViewModel : MainEntityViewModel
    {
        public Guid InscricaoId { get; set; }
        public Guid QuestaoId { get; set; }
        public string Descricao { get; set; }

        // RELACIONAMENTO
        public InscricaoViewModel Inscricao { get; set; }
        public QuestaoViewModel Questao { get; set; }
        public AvaliacaoViewModel Avaliacao { get; set; }
    }
}
