using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mamba.Infra.Context
{
    public class ContextBase : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly IUser _user;
        public ContextBase(DbContextOptions<ContextBase> options, IUser user) : base(options)
        {
            _user = user;
        }

        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Desafio> Desafio { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Inscricao> Inscricao { get; set; }
        public DbSet<Questao> Questao { get; set; }
        public DbSet<Resposta> Resposta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextBase).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("ProcessoCadastro").CurrentValue = _user.GetCurrentPath();

                    if (_user.IsAuthenticated())
                        entry.Property("CodigoUsuarioCadastro").CurrentValue = _user.GetUserId();

                    entry.Property("DataUltimaAlteracao").IsModified = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataUltimaAlteracao").CurrentValue = DateTime.Now;

                    entry.Property("ProcessoCadastro").IsModified = false;
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("CodigoUsuarioCadastro").IsModified = false;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
