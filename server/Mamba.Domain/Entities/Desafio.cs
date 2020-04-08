using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Desafio
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdDesafio { get; set; }
        public int CodigoEmpresa { get; set; }
        public int? CodigoCargo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int? LimiteInscricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }

        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

        // RELACIONAMENTO
        public Empresa Empresa { get; set; }
        public Cargo Cargo { get; set; }
        public List<Questao> Questoes { get; set; }
        public List<Inscricao> Inscricoes { get; set; }

        // AUXILIARES

    }
}
