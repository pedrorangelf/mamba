using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs
{
    public class CidadeViewModel : MainEntityViewModel
    {
        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        // RELACIONAMENTO
        public EstadoViewModel Estado { get; set; }
        public List<EmpresaViewModel> Empresas { get; set; }
        public List<CandidatoViewModel> Candidatos { get; set; }
    }
}
