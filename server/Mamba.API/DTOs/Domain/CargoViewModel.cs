using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Domain
{
    public class CargoViewModel : MainEntityViewModel
    {
        public int EmpresaId { get; set; }
        public int AreaAtuacaoId { get; set; }
        public string Nome { get; set; }

        // RELACIONAMENTO
        public EmpresaViewModel Empresa { get; set; }
        public AreaAtuacaoViewModel AreaAtuacao { get; set; }
        public List<FuncionarioViewModel> Funcionarios { get; set; }
        public List<DesafioViewModel> Desafios { get; set; }
    }
}
