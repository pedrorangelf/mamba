using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class AreaAtuacao : MainEntity
    {
        public string Descricao { get; set; }

        // RELACIONAMENTO
        public List<Cargo> Cargos { get; set; }
    }
}
