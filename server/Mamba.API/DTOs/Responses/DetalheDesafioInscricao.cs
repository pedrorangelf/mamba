using Mamba.API.Extensions.Utilities;
using System;

namespace Mamba.API.DTOs.Responses
{
    public class DetalheDesafioInscricao
    {
        public string Cargo { get; set; }
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

        public string TempoStatus
        {
            get
            {
                if (DataFechamento.HasValue)
                {
                    if (DataFechamento.Value <= DateTime.Now)
                        return DateTimeUtilities.ObterPeriodoTemporal(DataFechamento.Value, prefixo: "Fechado");
                }

                return DateTimeUtilities.ObterPeriodoTemporal(DataAbertura, prefixo: "Aberto");
            }
        }
    }
}
