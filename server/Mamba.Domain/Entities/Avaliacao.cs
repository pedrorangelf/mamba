using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Avaliacao
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdAvaliacao { get; set; }
        public int CodigoFuncionario { get; set; }
        public int CodigoResposta { get; set; }
        public string Descricao { get; set; }
        public bool Aprovado { get; set; }
        public int Nota { get; set; }


        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

        // RELACIONAMENTO
        public Funcionario Funcionario { get; set; }
        public Resposta Resposta { get; set; }

        // AUXILIARES

    }
}
