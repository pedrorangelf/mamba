﻿using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Cargo : MainEntity
    {
        public int EmpresaId { get; set; }
        public int AreaAtuacaoId { get; set; }
        public string Nome { get; set; }

        // RELACIONAMENTO
        public Empresa Empresa { get; set; }
        public AreaAtuacao AreaAtuacao { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        public List<Desafio> Desafios { get; set; }
    }
}
