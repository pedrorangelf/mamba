using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamba.API.Model
{
    public class UsuarioModel
    {
        public int? IdUsuario { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }
        public bool EmailConfirmado { get; set; }
        public bool Administrador { get; set; }
        public bool Bloqueado { get; set; }
        public string MotivoBloqueio { get; set; }
        public string LinkLinkedin { get; set; }
        public string LinkGithub { get; set; }
        public string Foto { get; set; }
    }
}
