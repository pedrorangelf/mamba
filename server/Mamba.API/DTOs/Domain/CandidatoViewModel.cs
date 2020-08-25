using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Domain
{
    public class CandidatoViewModel : MainEntityViewModel
    {
        public Guid ApplicationUserId { get; set; }
        public Guid EnderecoId { get; set; }
        public string Profissao { get; set; }

        // RELACIONAMENTO
        public ApplicationUserViewModel ApplicationUser { get; set; }
        public EnderecoViewModel EnderecoViewModel { get; set; }
        public List<InscricaoViewModel> Inscricoes { get; set; }
    }
}
