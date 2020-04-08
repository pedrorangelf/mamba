using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class CandidatoConfig : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("CANDIDATO");
            builder.HasKey(p => p.IdCandidato).HasName("COD_CANDIDATO");
            builder.HasOne(p => p.Usuario).WithMany(p => p.Candidatos).HasForeignKey(p => p.CodigoUsuario).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Cidade).WithMany(p => p.Candidatos).HasForeignKey(p => p.CodigoCidade).OnDelete(DeleteBehavior.Restrict);

            // CAMPOS DA TABELA
            builder.Property(p => p.IdCandidato)
                .HasColumnName("COD_CANDIDATO")
                .IsRequired();

            builder.Property(p => p.CodigoCidade)
                .HasColumnName("COD_CIDADE")
                .IsRequired();

            builder.Property(p => p.CodigoUsuario)
                .HasColumnName("COD_USUARIO")
                .IsRequired();

            builder.Property(p => p.Profissao)
                .HasColumnName("DSC_PROFISSAO")
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
