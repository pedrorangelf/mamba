using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Empresa : MainEntity
    {
        public int CidadeId { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Descricao { get; set; }
        public string Logo { get; set; }

        // RELACIONAMENTO
        public Cidade Cidade { get; set; }
        public List<Desafio> Desafios { get; set; }
        public List<Cargo> Cargos { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
    }
}
