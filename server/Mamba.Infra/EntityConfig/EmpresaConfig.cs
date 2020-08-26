using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class EmpresaConfig : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.SetMainEntityConfig("EMPRESA");
            //builder.HasOne(p => p.Endereco).WithOne(p => p.Empresa);

            // CAMPOS DA TABELA
            builder.Property(p => p.EnderecoId)
                .HasColumnName("ID_ENDERECO")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOM_EMPRESA")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.CNPJ)
                .HasColumnName("NUM_CNPJ")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_EMPRESA")
                .HasMaxLength(500);

            builder.Property(p => p.Logo)
                .HasColumnName("NOM_ARQUIVO_LOGO")
                .HasMaxLength(200);
        }
    }
}
