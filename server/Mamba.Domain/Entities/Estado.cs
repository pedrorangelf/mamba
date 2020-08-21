using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Estado : MainEntity
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }

        // RELACIONAMENTO
        public List<Cidade> Cidades { get; set; }
    }
}
