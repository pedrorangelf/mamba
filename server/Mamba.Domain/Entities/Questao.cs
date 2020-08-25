using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Questao : MainEntity
    {
        public Guid DesafioId { get; set; }
        public string Descricao { get; set; }

        // RELACIONAMENTO
        public Desafio Desafio { get; set; }
        public List<Resposta> Respostas { get; set; }
    }
}
