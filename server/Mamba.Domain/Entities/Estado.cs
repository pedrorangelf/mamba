using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Estado
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdEstado { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

        // RELACIONAMENTO
        public List<Cidade> Cidades { get; set; }

        // AUXILIARES

    }
}
