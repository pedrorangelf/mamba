namespace Mamba.API.DTOs
{
    public class AvaliacaoViewModel : MainEntityViewModel
    {
        public int FuncionarioId { get; set; }
        public int RespostaId { get; set; }

        public string Descricao { get; set; }
        public bool Aprovado { get; set; }
        public int Nota { get; set; }

        // RELACIONAMENTO
        public FuncionarioViewModel Funcionario { get; set; }
        public RespostaViewModel Resposta { get; set; }
    }
}
