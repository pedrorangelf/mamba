using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Domain
{
    public class EmpresaViewModel : MainEntityViewModel
    {
        public Guid EnderecoId { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Descricao { get; set; }
        public string Logo { get; set; }

        // RELACIONAMENTO
        public EnderecoViewModel Endereco { get; set; }
        public List<DesafioViewModel> Desafios { get; set; }
        public List<CargoViewModel> Cargos { get; set; }
        public List<FuncionarioViewModel> Funcionarios { get; set; }
    }
}
