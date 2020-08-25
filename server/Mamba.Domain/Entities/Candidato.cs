using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Candidato : MainEntity
    {
        public Guid ApplicationUserId { get; set; }
        public Guid EnderecoId { get; set; }
        public string Profissao { get; set; }

        // RELACIONAMENTO
        public ApplicationUser ApplicationUser { get; set; }
        public Endereco Endereco { get; set; }
        public List<Inscricao> Inscricoes { get; set; }
    }
}
