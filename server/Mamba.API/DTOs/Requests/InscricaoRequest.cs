using System;
using System.Collections.Generic;

namespace Mamba.API.Controllers.DTOs.Requests
{
    public class InscricaoRequest
    {
        public Guid DesafioId { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string LinkLinkedin { get; set; }
        public string LinkGithub { get; set; }
        public string Profissao { get; set; }

        public EnderecoInscricaoRequest Endereco { get; set; }
        public List<RespostasInscricaoRequest> Respostas { get; set; }
    }

    public class EnderecoInscricaoRequest
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }

    public class RespostasInscricaoRequest
    {
        public Guid QuestaoId { get; set; }
        public string Descricao { get; set; }
    }
}
