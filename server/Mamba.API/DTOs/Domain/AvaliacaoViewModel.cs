using System;

namespace Mamba.API.DTOs.Domain
{
    public class AvaliacaoViewModel : MainEntityViewModel
    {
        public Guid FuncionarioId { get; set; }
        public Guid RespostaId { get; set; }

        public string Descricao { get; set; }
        public bool Aprovado { get; set; }
        public int Nota { get; set; }

        // RELACIONAMENTO
        public FuncionarioViewModel Funcionario { get; set; }
        public RespostaViewModel Resposta { get; set; }
    }
}
