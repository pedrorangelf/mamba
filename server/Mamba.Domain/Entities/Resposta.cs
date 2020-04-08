using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Resposta
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdResposta { get; set; }
        public int CodigoInscricao { get; set; }
        public int CodigoQuestao { get; set; }
        public string Descricao { get; set; }

        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

        // RELACIONAMENTO
        public Inscricao Inscricao { get; set; }
        public Questao Questao { get; set; }
        public Avaliacao Avaliacao { get; set; }

        // AUXILIARES

    }
}
