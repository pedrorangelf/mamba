﻿using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs
{
    public class DesafioViewModel : MainEntityViewModel

    {
        public int EmpresaId { get; set; }
        public int? CargoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int? LimiteInscricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }

        // RELACIONAMENTO
        public EmpresaViewModel Empresa { get; set; }
        public CargoViewModel Cargo { get; set; }
        public List<QuestaoViewModel> Questoes { get; set; }
        public List<InscricaoViewModel> Inscricoes { get; set; }
    }
}
