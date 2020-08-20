using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class CandidatoConfig : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.SetMainEntityConfig("CANDIDATO");
            builder.HasOne(p => p.Usuario).WithMany(p => p.Candidatos).HasForeignKey(p => p.UsuarioId);
            builder.HasOne(p => p.Cidade).WithMany(p => p.Candidatos).HasForeignKey(p => p.CidadeId);

            builder.Property(p => p.CidadeId)
                .HasColumnName("ID_CIDADE")
                .IsRequired();

            builder.Property(p => p.UsuarioId)
                .HasColumnName("ID_USUARIO")
                .IsRequired();

            builder.Property(p => p.Profissao)
                .HasColumnName("DSC_PROFISSAO")
                .IsRequired();
        }
    }
}
