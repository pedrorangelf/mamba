using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class EstadoConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("ESTADO");
            builder.HasKey(p => p.IdEstado).HasName("COD_ESTADO");

            // CAMPOS DA TABELA
            builder.Property(p => p.IdEstado)
                .HasColumnName("COD_ESTADO")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOM_ESTADO")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Sigla)
                .HasColumnName("SGL_ESTADO")
                .HasMaxLength(2)
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
