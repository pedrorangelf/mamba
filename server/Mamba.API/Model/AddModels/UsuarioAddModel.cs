using System;

namespace Mamba.API.Model
{
    public class UsuarioAddModel
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public bool EmailConfirmado { get; set; }
        public bool Administrador { get; set; }
        public bool Bloqueado { get; set; }
        public string MotivoBloqueio { get; set; }
        public string LinkLinkedin { get; set; }
        public string LinkGithub { get; set; }
    }
}
