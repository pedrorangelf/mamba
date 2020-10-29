using System;
using System.Collections.Generic;

namespace Mamba.API.Controllers.DTOs.Responses
{
    public class InscricaoDetalhadaResponse
    {
        public Guid DesafioId { get; set; }
        public string VagaDesafio { get; set; }
        public string NomeCandidato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        public bool? Aprovado { get; set; }
        public string ParecerFinal { get; set; }
        public int TotalQuestoes { get; set; }
        public int TotalAcertos { get; set; }
        public string Nota
        {
            get
            {
                return $"{TotalAcertos}/{TotalQuestoes}";
            }
        }

        public List<InscricaoDetalhadaQuestaoResponse> Questoes { get; set; }
    }

    public class InscricaoDetalhadaQuestaoResponse
    {
        public Guid QuestaoId { get; set; }
        public string Descricao { get; set; }
        public InscricaoDetalhadaQuestaoRespostaResponse Resposta { get; set; }
        public InscricaoDetalhadaQuestaoAvaliacaoResponse Avaliacao { get; set; }
    }

    public class InscricaoDetalhadaQuestaoRespostaResponse
    {
        public Guid RespostaId { get; set; }
        public string Descricao { get; set; }
    }

    public class InscricaoDetalhadaQuestaoAvaliacaoResponse
    {
        public string Avaliador { get; set; }
        public string Descricao { get; set; }
        public bool? Aprovado { get; set; }
    }
}
