using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Domain
{
    public class EmpresaViewModel : MainEntityViewModel
    {
        public int CidadeId { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Descricao { get; set; }
        public string Logo { get; set; }

        // RELACIONAMENTO
        public CidadeViewModel Cidade { get; set; }
        public List<DesafioViewModel> Desafios { get; set; }
        public List<CargoViewModel> Cargos { get; set; }
        public List<FuncionarioViewModel> Funcionarios { get; set; }
    }
}
