using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class InscricaoConfig : IEntityTypeConfiguration<Inscricao>
    {
        public void Configure(EntityTypeBuilder<Inscricao> builder)
        {
            builder.SetMainEntityConfig("INSCRICAO");
            builder.HasOne(p => p.Desafio).WithMany(p => p.Inscricoes).HasForeignKey(p => p.DesafioId);
            builder.HasOne(p => p.Candidato).WithMany(p => p.Inscricoes).HasForeignKey(p => p.CandidatoId);

            // CAMPOS DA TABELA
            builder.Property(p => p.DesafioId)
                .HasColumnName("ID_DESAFIO")
                .IsRequired();

            builder.Property(p => p.CandidatoId)
                .HasColumnName("ID_CANDIDATO")
                .IsRequired();

            builder.Property(p => p.DataInscricao)
                .HasColumnName("DAT_INSCRICAO")
                .IsRequired();

            builder.Property(p => p.DataFinalizacao)
                .HasColumnName("DAT_FINALIZACAO");

            builder.Property(p => p.Resultado)
                .HasColumnName("DSC_RESULTADO")
                .HasMaxLength(500);

            builder.Property(p => p.Aprovado)
                .HasColumnName("IND_APROVADO");
        }
    }
}
