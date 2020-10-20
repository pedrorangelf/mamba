using System.ComponentModel.DataAnnotations;

namespace Mamba.API.DTOs.Requests
{
    public class EnderecoRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(5, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Numero { get; set; }

        [StringLength(10, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter {1} caracteres")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, MinimumLength = 8, ErrorMessage = "O campo {0} deve ter de {2} a {1} caracteres")]
        public string CEP { get; set; }
    }
}
