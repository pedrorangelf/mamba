using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Inscricao
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdInscricao { get; set; }
        public int CodigoDesafio { get; set; }
        public int CodigoCandidato { get; set; }
        public DateTime DataInscricao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public string Resultado { get; set; }
        public bool? Aprovado { get; set; }

        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

        // RELACIONAMENTO
        public Desafio Desafio { get; set; }
        public Candidato Candidato { get; set; }
        public List<Resposta> Respostas { get; set; }

        // AUXILIARES

    }
}
