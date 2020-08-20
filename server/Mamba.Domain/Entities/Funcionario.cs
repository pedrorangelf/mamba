using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Funcionario : MainEntity
    {
        public int EmpresaId { get; set; }
        public int? CargoId { get; set; }
        public int UsuarioId { get; set; }

        // RELACIONAMENTO
        public Empresa Empresa { get; set; }
        public Cargo Cargo { get; set; }
        public Usuario Usuario { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }
    }
}
