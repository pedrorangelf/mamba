using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Domain
{
    public class CargoViewModel : MainEntityViewModel
    {
        public Guid EmpresaId { get; set; }
        public string Nome { get; set; }

        // RELACIONAMENTO
        public EmpresaViewModel Empresa { get; set; }
        public List<FuncionarioViewModel> Funcionarios { get; set; }
        public List<DesafioViewModel> Desafios { get; set; }
    }
}
