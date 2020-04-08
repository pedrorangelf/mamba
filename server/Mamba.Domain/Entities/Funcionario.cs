using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Funcionario
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdFuncionario { get; set; }
        public int CodigoEmpresa { get; set; }
        public int? CodigoCargo { get; set; }
        public int CodigoUsuario { get; set; }

        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

        // RELACIONAMENTO
        public Empresa Empresa { get; set; }
        public Cargo Cargo { get; set; }
        public Usuario Usuario { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }

        // AUXILIARES

    }
}
