using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Funcionario : MainEntity
    {
        public Guid CargoId { get; set; }
        public Guid ApplicationUserId { get; set; }

        // RELACIONAMENTO
        public Cargo Cargo { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }
    }
}
