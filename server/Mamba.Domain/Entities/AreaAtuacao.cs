using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class AreaAtuacao
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdAreaAtuacao { get; set; }
        public string Descricao { get; set; }

        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

        // RELACIONAMENTO
        public List<Cargo> Cargos { get; set; }

        // AUXILIARES

    }
}
