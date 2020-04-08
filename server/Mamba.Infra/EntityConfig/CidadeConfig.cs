using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class CidadeConfig : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("CIDADE");
            builder.HasKey(p => p.IdCidade).HasName("COD_CIDADE");
            builder.HasOne(p => p.Estado).WithMany(p => p.Cidades).HasForeignKey(p => p.CodigoEstado).OnDelete(DeleteBehavior.Restrict);

            // CAMPOS DA TABELA
            builder.Property(p => p.IdCidade)
                .HasColumnName("COD_CIDADE")
                .IsRequired();

            builder.Property(p => p.CodigoEstado)
                .HasColumnName("COD_ESTADO")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOM_CIDADE")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Sigla)
                .HasColumnName("SGL_CIDADE")
                .HasMaxLength(3)
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
