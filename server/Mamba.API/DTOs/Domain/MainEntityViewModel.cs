using System;
using System.ComponentModel.DataAnnotations;

namespace Mamba.API.DTOs.Domain
{
    public abstract class MainEntityViewModel
    {
        [Key]
        public int Id { get; set; }

        //public DateTime DataCadastro { get; set; }
        //public int? CodigoUsuarioCadastro { get; set; }
        //public string ProcessoCadastro { get; set; }
        //public DateTime? DataUltimaAlteracao { get; set; }
    }
}
