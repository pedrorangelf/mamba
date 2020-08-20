using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Resposta : MainEntity
    {
        public int InscricaoId { get; set; }
        public int QuestaoId { get; set; }
        public string Descricao { get; set; }

        // RELACIONAMENTO
        public Inscricao Inscricao { get; set; }
        public Questao Questao { get; set; }
        public Avaliacao Avaliacao { get; set; }
    }
}
