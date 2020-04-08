using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Cidade
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdCidade { get; set; }
        public int CodigoEstado { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

        // RELACIONAMENTO
        public Estado Estado { get; set; }
        public List<Empresa> Empresas { get; set; }
        public List<Candidato> Candidatos { get; set; }

        // AUXILIARES

    }
}
