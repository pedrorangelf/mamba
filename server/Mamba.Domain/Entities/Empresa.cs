using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Empresa : MainEntity
    {
        public Guid EnderecoId { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Descricao { get; set; }
        public string Logo { get; set; }

        // RELACIONAMENTO
        public Endereco Endereco { get; set; }
        public List<Desafio> Desafios { get; set; }
        public List<Cargo> Cargos { get; set; }
    }
}
