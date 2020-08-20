﻿using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Cidade : MainEntity
    {
        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        // RELACIONAMENTO
        public Estado Estado { get; set; }
        public List<Empresa> Empresas { get; set; }
        public List<Candidato> Candidatos { get; set; }
    }
}
