using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Empresa
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdEmpresa { get; set; }
        public int CodigoCidade { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Descricao { get; set; }
        public string Logo { get; set; }

        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

        // RELACIONAMENTO
        public Cidade Cidade { get; set; }
        public List<Desafio> Desafios { get; set; }
        public List<Cargo> Cargos { get; set; }
        public List<Funcionario> Funcionarios { get; set; }

        // AUXILIARES

    }
}
