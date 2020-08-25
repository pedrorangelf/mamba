using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mamba.API.DTOs
{
    public class RegistrarEmpresaViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(500, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Cargo { get; set; }

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
        public EmpresaRegistrarEmpresaViewModel Empresa { get; set; }
    }

    public class EmpresaRegistrarEmpresaViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(500, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "O campo {0} deve conter {1} caracteres")]
        public string CNPJ { get; set; }

        [StringLength(500, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Descricao { get; set; }

        [StringLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        public string Logo { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public EnderecoRegistrarEmpresaViewModel Endereco { get; set; }
    }

    public class EnderecoRegistrarEmpresaViewModel
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
