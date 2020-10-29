using System;

namespace Mamba.API.Controllers.DTOs.Responses
{
    public class InscricoesDesafioResponse
    {
        public Guid InscricaoId { get; set; }
        public string NomeCandidato { get; set; }
        public bool? Aprovado { get; set; }
        public int TotalQuestoes { get; set; }
        public int TotalAcertos { get; set; }
        public string Desempenho
        {
            get
            {
                return $"{TotalAcertos}/{TotalQuestoes}";
            }
        }

        public StatusAprovacaoInscricao Status
        {
            get
            {
                if (!Aprovado.HasValue) return StatusAprovacaoInscricao.Pendente;

                if (Aprovado.Value) return StatusAprovacaoInscricao.Aprovado;

                return StatusAprovacaoInscricao.Reprovado;
            }
        }

        public string DescricaoStatus
        {
            get
            {
                if (!Aprovado.HasValue) return StatusAprovacaoInscricao.Pendente.ToString();

                if (Aprovado.Value) return StatusAprovacaoInscricao.Aprovado.ToString();

                return StatusAprovacaoInscricao.Reprovado.ToString();
            }
        }
    }

    public enum StatusAprovacaoInscricao
    {
        Pendente,
        Aprovado,
        Reprovado
    }
}
