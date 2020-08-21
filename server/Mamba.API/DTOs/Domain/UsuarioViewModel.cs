using System;
using System.Collections.Generic;

namespace Mamba.API.DTOs.Domain
{
    public class UsuarioViewModel : MainEntityViewModel
    {
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

        // RELACIONAMENTO
        public List<CandidatoViewModel> Candidatos { get; set; }
        public List<FuncionarioViewModel> Funcionarios { get; set; }

        // AUXILIARES
        public string Idade
        {
            get
            {
                if (this.DataNascimento == DateTime.MinValue)
                {
                    return "Não informado";
                }
                else
                {
                    int idade = DateTime.Now.Year - this.DataNascimento.Year;
                    if (DateTime.Now.DayOfYear < this.DataNascimento.DayOfYear)
                    {
                        idade -= 1;
                    }

                    return idade.ToString();
                }
            }
        }
    }
}
