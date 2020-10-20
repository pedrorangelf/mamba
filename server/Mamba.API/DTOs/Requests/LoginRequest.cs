using System.ComponentModel.DataAnnotations;

namespace Mamba.API.DTOs.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O {0} informado é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
    }
}
