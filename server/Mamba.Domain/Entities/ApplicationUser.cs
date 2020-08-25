using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Bloqueado { get; set; }
        public string MotivoBloqueio { get; set; }
        public string LinkLinkedin { get; set; }
        public string LinkGithub { get; set; }
        public string Foto { get; set; }

        // RELACIONAMENTO
        public List<Candidato> Candidatos { get; set; }
        public List<Funcionario> Funcionarios { get; set; }

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
