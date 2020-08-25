using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(p => p.Nome)
                .HasColumnName("NOM_USUARIO")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("DAT_NASCIMENTO")
                .IsRequired();

            builder.Property(p => p.Bloqueado)
                .HasColumnName("IND_BLOQUEADO")
                .IsRequired();

            builder.Property(p => p.MotivoBloqueio)
                .HasColumnName("DSC_MOTIVO_BLOQUEIO")
                .HasMaxLength(500);

            builder.Property(p => p.LinkLinkedin)
                .HasColumnName("DSC_LINK_LINKEDIN")
                .HasMaxLength(100);

            builder.Property(p => p.LinkGithub)
                .HasColumnName("DSC_LINK_GITHUB")
                .HasMaxLength(100);

            builder.Property(p => p.Foto)
                .HasColumnName("NOM_ARQUIVO_FOTO")
                .HasMaxLength(200);
        }
    }
}
