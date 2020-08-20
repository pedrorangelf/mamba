using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Candidato : MainEntity
    {
        public int UsuarioId { get; set; }
        public int CidadeId { get; set; }
        public string Profissao { get; set; }

        // RELACIONAMENTO
        public Usuario Usuario { get; set; }
        public Cidade Cidade { get; set; }
        public List<Inscricao> Inscricoes { get; set; }
    }
}
