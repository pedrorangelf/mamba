using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs
{
    public class QuestaoViewModel : MainEntityViewModel
    {
        public int DesafioId { get; set; }
        public string Descricao { get; set; }

        // RELACIONAMENTO
        public DesafioViewModel Desafio { get; set; }
        public List<RespostaViewModel> Respostas { get; set; }
    }
}
