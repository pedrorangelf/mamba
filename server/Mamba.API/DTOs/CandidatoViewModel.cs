using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs
{
    public class CandidatoViewModel : MainEntityViewModel
    {
        public int UsuarioId { get; set; }
        public int CidadeId { get; set; }
        public string Profissao { get; set; }

        // RELACIONAMENTO
        public UsuarioViewModel Usuario { get; set; }
        public CidadeViewModel Cidade { get; set; }
        public List<InscricaoViewModel> Inscricoes { get; set; }
    }
}
