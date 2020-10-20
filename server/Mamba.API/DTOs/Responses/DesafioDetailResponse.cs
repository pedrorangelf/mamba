using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Responses
{
    public class DesafioDetailResponse
    {
        public Guid Id { get; set; }
        public Guid CargoId { get; set; }
        public int? LimiteInscricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }

        public List<QuestaoDetailResponse> Questoes { get; set; }
    }

    public class QuestaoDetailResponse
    {
        public Guid Id { get; set; }
        public Guid DesafioId { get; set; }
        public string Descricao { get; set; }
    }
}
