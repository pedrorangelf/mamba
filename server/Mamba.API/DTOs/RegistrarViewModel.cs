using System;
using System.ComponentModel.DataAnnotations;

namespace Mamba.API.DTOs
{
    public class RegistrarViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(300, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Email { get; set; }

        [MaxLength(14, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(500, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Senha { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string LinkLinkedin { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string LinkGithub { get; set; }

        [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Foto { get; set; }
    }
}
