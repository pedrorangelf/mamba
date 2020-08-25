using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Domain
{
    public class FuncionarioViewModel : MainEntityViewModel
    {
        public Guid EmpresaId { get; set; }
        public Guid ApplicationUserId { get; set; }
        public Guid? CargoId { get; set; }

        // RELACIONAMENTO
        public EmpresaViewModel Empresa { get; set; }
        public ApplicationUserViewModel ApplicationUser { get; set; }
        public CargoViewModel Cargo { get; set; }
        public List<AvaliacaoViewModel> Avaliacoes { get; set; }
    }
}
