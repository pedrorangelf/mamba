﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamba.API.Model
{
    public class EmpresaModel
    {
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Descricao { get; set; }
    }
}
