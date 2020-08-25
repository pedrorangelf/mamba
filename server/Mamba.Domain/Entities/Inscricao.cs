using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Inscricao : MainEntity
    {
        public Guid DesafioId { get; set; }
        public Guid CandidatoId { get; set; }
        public DateTime DataInscricao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public string Resultado { get; set; }
        public bool? Aprovado { get; set; }

        // RELACIONAMENTO
        public Desafio Desafio { get; set; }
        public Candidato Candidato { get; set; }
        public List<Resposta> Respostas { get; set; }
    }
}
