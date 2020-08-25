using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Domain
{
    public class DesafioViewModel : MainEntityViewModel

    {
        public Guid EmpresaId { get; set; }
        public Guid? CargoId { get; set; }
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
