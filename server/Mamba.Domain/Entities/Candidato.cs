using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Candidato
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdCandidato { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoCidade { get; set; }
        public string Profissao { get; set; }

        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

        // RELACIONAMENTO
        public Usuario Usuario { get; set; }
        public Cidade Cidade { get; set; }
        public List<Inscricao> Inscricoes { get; set; }

        // AUXILIARES
    }
}
