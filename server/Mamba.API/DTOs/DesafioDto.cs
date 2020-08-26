using Mamba.API.Extensions.Utilities;
using System;

namespace Mamba.API.DTOs
{
    public class DesafioDto
    {
        public Guid Id { get; set; }
        public Guid? CargoId { get; set; }
        public string Cargo { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int? LimiteInscricao { get; set; }

        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string StatusDesafio
        {
            get
            {
                if (!DataFechamento.HasValue)
                    return "Aberto";

                if (DataFechamento.Value > DateTime.Now.Date)
                    return "Aberto";

                return "Fechado";
            }
        }

        public int TotalInscricoes { get; set; }
        public int TotalInscricoesIniciadas { get; set; }
        public int TotalInscricoesFinalizadas { get; set; }

        public DateTime? DataUltimaInscricao { get; set; }
        public DateTime? DataUltimaInicializacao { get; set; }
        public DateTime? DataUltimaFinalizacao { get; set; }

        public string TempoAbertura
        {
            get
            {
                return DateTimeUtilities.ObterPeriodoTemporal(DataAbertura, prefixo: "Desafio aberto");
            }
        }

        public string TempoUltimaInscricao
        {
            get
            {
                if (!DataUltimaInscricao.HasValue)
                    return "Ainda não houveram inscrições";

                return DateTimeUtilities.ObterPeriodoTemporal(DataUltimaInscricao.Value, prefixo: "Última inscrição");
            }
        }

        public string TempoUltimaInicializacao
        {
            get
            {
                if (!DataUltimaInicializacao.HasValue)
                    return "Ainda não houveram desafios iniciados";

                return DateTimeUtilities.ObterPeriodoTemporal(DataUltimaInicializacao.Value, prefixo: "Último desafio iniciado");
            }
        }

        public string TempoUltimaFinalizacao
        {
            get
            {
                if (!DataUltimaFinalizacao.HasValue)
                    return "Ainda não houveram desafios finalizados";

                return DateTimeUtilities.ObterPeriodoTemporal(DataUltimaFinalizacao.Value, prefixo: "Último desafio finalizado");
            }
        }

        public int PorcentagemConclusao
        {
            get
            {
                if (TotalInscricoes == 0 || TotalInscricoesFinalizadas == 0)
                    return 0;

                return (TotalInscricoesFinalizadas * 100) / TotalInscricoes;
            }
        }

    }
}
