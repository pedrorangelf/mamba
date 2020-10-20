using System;

namespace Mamba.API.DTOs.Responses
{
    public class InscricaoResponse
    {
        public Guid CandidatoId { get; set; }
        public string NomeCandidato { get; set; }

        public DateTime DataInscricao { get; set; }
        public DateTime? DataInicializacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }

        public string Resultado { get; set; }
        public bool? Aprovado { get; set; }

        public string StatusAvaliacao
        {
            get
            {
                if (Aprovado.HasValue)
                    return "Avaliado";

                return "Avaliação Pendente";
            }
        }
    }
}
