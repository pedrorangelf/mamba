using System;
using System.Collections.Generic;

namespace Mamba.Domain.Entities
{
    public class Usuario
    {
        // ATRIBUTOS DA ENTIDADE
        public int IdUsuario { get; set; }
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

        // ATRIBUTOS PADRÕES DE CONTROLE
        public DateTime DataCadastro { get; set; }
        public int? CodigoUsuarioCadastro { get; set; }
        public string ProcessoCadastro { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }

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
