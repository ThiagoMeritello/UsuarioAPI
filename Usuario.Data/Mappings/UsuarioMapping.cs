using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuario.Business.Models;

namespace Usuario.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Sobrenome)
                .HasColumnType("varchar(200)");

            builder.ToTable("Usuarios");
        }
    }
}