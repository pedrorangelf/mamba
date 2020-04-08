using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class AreaAtuacaoConfig : IEntityTypeConfiguration<AreaAtuacao>
    {
        public void Configure(EntityTypeBuilder<AreaAtuacao> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("AREA_ATUACAO");
            builder.HasKey(p => p.IdAreaAtuacao).HasName("COD_AREA_ATUACAO");

            // CAMPOS DA TABELA
            builder.Property(p => p.IdAreaAtuacao)
                .HasColumnName("COD_AREA_ATUACAO")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_AREA_ATUACAO")
                .HasMaxLength(300)
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
