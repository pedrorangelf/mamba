using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Domain
{
    public class RespostaViewModel : MainEntityViewModel
    {
        public int InscricaoId { get; set; }
        public int QuestaoId { get; set; }
        public string Descricao { get; set; }

        // RELACIONAMENTO
        public InscricaoViewModel Inscricao { get; set; }
        public QuestaoViewModel Questao { get; set; }
        public AvaliacaoViewModel Avaliacao { get; set; }
    }
}
