using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Questao
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdQuestao { get; set; }
        public int CodigoDesafio { get; set; }
        public string Descricao { get; set; }

        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

        // RELACIONAMENTO
        public Desafio Desafio { get; set; }
        public List<Resposta> Respostas { get; set; }

        // AUXILIARES

    }
}
