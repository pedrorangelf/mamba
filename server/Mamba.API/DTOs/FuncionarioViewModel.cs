using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs
{
    public class FuncionarioViewModel : MainEntityViewModel
    {
        public int EmpresaId { get; set; }
        public int? CargoId { get; set; }
        public int UsuarioId { get; set; }

        // RELACIONAMENTO
        public EmpresaViewModel Empresa { get; set; }
        public CargoViewModel Cargo { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public List<AvaliacaoViewModel> Avaliacoes { get; set; }
    }
}
