using System;
using System.ComponentModel.DataAnnotations;

namespace Mamba.API.DTOs
{
    public class NovoCandidatoDto
    {
        [StringLength(500, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Profissao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Email { get; set; }

        [StringLength(14, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(500, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Senha { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string LinkLinkedin { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string LinkGithub { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public EnderecoDto Endereco { get; set; }
    }
}
