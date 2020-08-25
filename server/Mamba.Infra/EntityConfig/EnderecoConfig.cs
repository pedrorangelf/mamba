using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.SetMainEntityConfig("ENDERECO");

            builder.Property(p => p.Logradouro)
                .HasColumnName("DSC_LOGRADOURO")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasColumnName("NUM_ENDERECO")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(p => p.Complemento)
                .HasColumnName("DSC_COMPLEMENTO")
                .HasMaxLength(10);

            builder.Property(p => p.Bairro)
                .HasColumnName("NOM_BAIRRO")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.Cidade)
                .HasColumnName("NOM_CIDADE")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.Estado)
                .HasColumnName("SGL_ESTADO")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(p => p.CEP)
                .HasColumnName("NUM_CEP")
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}
