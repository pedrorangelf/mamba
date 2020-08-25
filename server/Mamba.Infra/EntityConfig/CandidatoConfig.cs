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
            builder.HasOne(p => p.ApplicationUser).WithMany(p => p.Candidatos).HasForeignKey(p => p.ApplicationUserId);
            //builder.HasOne(p => p.Endereco).WithOne(p => p.Candidato);

            builder.Property(p => p.EnderecoId)
                .HasColumnName("ID_ENDERECO")
                .IsRequired();

            builder.Property(p => p.ApplicationUserId)
                .HasColumnName("ID_USUARIO")
                .IsRequired();

            builder.Property(p => p.Profissao)
                .HasColumnName("DSC_PROFISSAO")
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
