using System;

namespace Mamba.Domain.Entities
{
    public class Avaliacao : MainEntity
    {
        public Guid FuncionarioId { get; set; }
        public Guid RespostaId { get; set; }

        public string Descricao { get; set; }
        public bool Aprovado { get; set; }
        public int Nota { get; set; }

        // RELACIONAMENTO
        public Funcionario Funcionario { get; set; }
        public Resposta Resposta { get; set; }
    }
}
