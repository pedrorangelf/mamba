using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Desafio : MainEntity
    {
        public Guid EmpresaId { get; set; }
        public Guid? CargoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int? LimiteInscricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }

        // RELACIONAMENTO
        public Empresa Empresa { get; set; }
        public Cargo Cargo { get; set; }
        public List<Questao> Questoes { get; set; }
        public List<Inscricao> Inscricoes { get; set; }
    }
}
