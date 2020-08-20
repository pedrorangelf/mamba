﻿using System;

namespace Mamba.API.DTOs
{
    public abstract class MainEntityViewModel
    {
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }
    }
}