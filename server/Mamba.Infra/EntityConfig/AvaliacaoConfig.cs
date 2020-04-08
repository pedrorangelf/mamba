using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class AvaliacaoConfig : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("AVALIACAO");
            builder.HasKey(p => p.IdAvaliacao).HasName("COD_AVALIACAO");
            builder.HasOne(p => p.Funcionario).WithMany(p => p.Avaliacoes).HasForeignKey(p => p.CodigoFuncionario).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Resposta).WithOne(p => p.Avaliacao).HasForeignKey<Avaliacao>(p => p.CodigoResposta).OnDelete(DeleteBehavior.Restrict);

            // CAMPOS DA TABELA
            builder.Property(p => p.IdAvaliacao)
                .HasColumnName("COD_AVALIACAO")
                .IsRequired();

            builder.Property(p => p.CodigoFuncionario)
                .HasColumnName("COD_FUNCIONARIO")
                .IsRequired();

            builder.Property(p => p.CodigoResposta)
                .HasColumnName("COD_RESPOSTA")
                .IsRequired();

            builder.Property(p => p.Aprovado)
                .HasColumnName("IND_APROVADO")
                .IsRequired();

            builder.Property(p => p.Nota)
                .HasColumnName("NUM_NOTA")
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
