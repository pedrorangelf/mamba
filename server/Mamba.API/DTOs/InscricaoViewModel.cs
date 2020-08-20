using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs
{
    public class InscricaoViewModel : MainEntityViewModel
    {
        public int DesafioId { get; set; }
        public int CandidatoId { get; set; }
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
