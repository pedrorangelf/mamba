namespace Mamba.API.DTOs.Domain
{
    public class EnderecoViewModel : MainEntityViewModel
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        // RELACIONAMENTOS
        public CandidatoViewModel Candidato { get; set; }
        public EmpresaViewModel Empresa { get; set; }
    }
}
