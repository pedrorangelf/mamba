using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class CargoConfig : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("CARGO");
            builder.HasKey(p => p.IdCargo).HasName("COD_CARGO");
            builder.HasOne(p => p.Empresa).WithMany(p => p.Cargos).HasForeignKey(p => p.CodigoEmpresa).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.AreaAtuacao).WithMany(p => p.Cargos).HasForeignKey(p => p.CodigoAreaAtuacao).OnDelete(DeleteBehavior.Restrict);

            // CAMPOS DA TABELA
            builder.Property(p => p.IdCargo)
                .HasColumnName("COD_CARGO")
                .IsRequired();

            builder.Property(p => p.CodigoEmpresa)
                .HasColumnName("COD_EMPRESA")
                .IsRequired();

            builder.Property(p => p.CodigoAreaAtuacao)
                .HasColumnName("COD_AREA_ATUACAO")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOM_CARGO")
                .IsRequired();

            // CAMPOS DE CONTROLE DE CADASTRO
            builder.Property(p => p.DataCadastro)
                .HasColumnName("DAT_CADASTRO")
                .IsRequired();

            builder.Property(p => p.CodigoUsuarioCadastro)
                .HasColumnName("COD_USUARIO_CADASTRO")
                .IsRequired();

            builder.Property(p => p.ProcessoCadastro)
                .HasColumnName("NOM_PROCESSO_CADASTRO")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.DataUltimaAlteracao)
                .HasColumnName("DAT_ULTIMA_ALTERACAO");
        }
    }
}
