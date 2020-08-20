using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs
{
    public class AreaAtuacaoViewModel : MainEntityViewModel
    {
        public string Descricao { get; set; }

        // RELACIONAMENTO
        public List<CargoViewModel> Cargos { get; set; }
    }
}
