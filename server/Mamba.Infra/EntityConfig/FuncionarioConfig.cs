using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class FuncionarioConfig : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.SetMainEntityConfig("FUNCIONARIO");
            builder.HasOne(p => p.Cargo).WithMany(p => p.Funcionarios).HasForeignKey(p => p.CargoId);
            builder.HasOne(p => p.ApplicationUser).WithMany(p => p.Funcionarios).HasForeignKey(p => p.ApplicationUserId);

            // CAMPOS DA TABELA
            builder.Property(p => p.CargoId)
                .HasColumnName("ID_CARGO");

            builder.Property(p => p.ApplicationUserId)
                .HasColumnName("ID_USUARIO")
                .IsRequired();
        }
    }
}
