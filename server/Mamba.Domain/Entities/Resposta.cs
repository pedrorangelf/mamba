using System;

namespace Mamba.Domain.Entities
{
    public class Resposta : MainEntity
    {
        public Guid InscricaoId { get; set; }
        public Guid QuestaoId { get; set; }
        public string Descricao { get; set; }

        // RELACIONAMENTO
        public Inscricao Inscricao { get; set; }
        public Questao Questao { get; set; }
        public Avaliacao Avaliacao { get; set; }
    }
}
