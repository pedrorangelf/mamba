using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Cargo
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdCargo { get; set; }
        public int CodigoEmpresa { get; set; }
        public int CodigoAreaAtuacao { get; set; }
        public string Nome { get; set; }

        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

        // RELACIONAMENTO
        public Empresa Empresa { get; set; }
        public AreaAtuacao AreaAtuacao { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        public List<Desafio> Desafios { get; set; }

        // AUXILIARES

    }
}
