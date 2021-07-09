using Esquirlas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esquirlas.Infrastructure.EntityConfigurations
{
    public class FaccionConfiguration : IEntityTypeConfiguration<Faccion>
    {
        public void Configure(EntityTypeBuilder<Faccion> builder)
        {
            builder.ToTable("Facciones");

            builder.Property(e => e.FaccionId)
                .HasAnnotation("Relational:ColumnName", "PersonajeId")
                .ValueGeneratedOnAdd();

            builder.HasKey(e => e.FaccionId);

            builder.Property(e => e.Name)
                .HasAnnotation("Relational:ColumnName", "Name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Status)
                .HasAnnotation("Relational:ColumnName", "Status")
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .HasAnnotation("Relational:ColumnName", "IsDeleted")
                .IsRequired();

        }
    }
}
