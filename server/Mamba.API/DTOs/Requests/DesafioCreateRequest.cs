using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mamba.API.DTOs.Requests
{
    public class DesafioCreateRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CargoId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser nulo ou maior que 0")]
        public int? LimiteInscricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataAbertura { get; set; }

        public DateTime? DataFechamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public List<QuestaoCreateRequest> Questoes { get; set; }
    }

    public class QuestaoCreateRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Descricao { get; set; }
    }
}
