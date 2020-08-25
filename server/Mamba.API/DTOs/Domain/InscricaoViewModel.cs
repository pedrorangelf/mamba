using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Domain
{
    public class InscricaoViewModel : MainEntityViewModel
    {
        public Guid DesafioId { get; set; }
        public Guid CandidatoId { get; set; }
        public DateTime DataInscricao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public string Resultado { get; set; }
        public bool? Aprovado { get; set; }

        // RELACIONAMENTO
        public DesafioViewModel Desafio { get; set; }
        public CandidatoViewModel Candidato { get; set; }
        public List<RespostaViewModel> Respostas { get; set; }
    }
}
