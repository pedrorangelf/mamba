using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs
{
    public class EstadoViewModel : MainEntityViewModel
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }

        // RELACIONAMENTO
        public List<CidadeViewModel> Cidades { get; set; }
    }
}
