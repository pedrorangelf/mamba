using Mamba.API.DTOs.Domain;
using Mamba.API.Extensions.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mamba.API.DTOs
{
    public class EmpresaDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(500, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [CnpjValidation(ErrorMessage = "O campo {0} informado é inválido.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo {0} deve conter {1} caracteres")]
        public string CNPJ { get; set; }

        [StringLength(500, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Descricao { get; set; }

        [StringLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Logo { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public EnderecoDto Endereco { get; set; }
    }

}
