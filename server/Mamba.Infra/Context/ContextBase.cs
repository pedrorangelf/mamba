using Mamba.Domain.Entities;
using Mamba.Infra.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Mamba.Infra.Context
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        public DbSet<AreaAtuacao> AreaAtuacao { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Desafio> Desafio { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Inscricao> Inscricao { get; set; }
        public DbSet<Questao> Questao { get; set; }
        public DbSet<Resposta> Resposta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AreaAtuacaoConfig());
            modelBuilder.ApplyConfiguration(new AvaliacaoConfig());
            modelBuilder.ApplyConfiguration(new CandidatoConfig());
            modelBuilder.ApplyConfiguration(new CargoConfig());
            modelBuilder.ApplyConfiguration(new CidadeConfig());
            modelBuilder.ApplyConfiguration(new DesafioConfig());
            modelBuilder.ApplyConfiguration(new EmpresaConfig());
            modelBuilder.ApplyConfiguration(new EstadoConfig());
            modelBuilder.ApplyConfiguration(new FuncionarioConfig());
            modelBuilder.ApplyConfiguration(new InscricaoConfig());
            modelBuilder.ApplyConfiguration(new QuestaoConfig());
            modelBuilder.ApplyConfiguration(new RespostaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());

            var cascadeFKs = modelBuilder
                          .Model
                          .GetEntityTypes()
                          .SelectMany(t => t.GetForeignKeys())
                          .Where(fk => !fk.IsOwnership)
                          .ToList();

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Cascade;
            }

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("DataUltimaAlteracao").IsModified = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("ProcessoCadastro").IsModified = false;
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("CodigoUsuarioCadastro").IsModified = false;
                    entry.Property("DataUltimaAlteracao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }
}
