using System;

namespace Mamba.Domain.Entities
{
    public abstract class MainEntity
    {
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }
        public Guid? UsuarioCadastroId { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }
    }
}
