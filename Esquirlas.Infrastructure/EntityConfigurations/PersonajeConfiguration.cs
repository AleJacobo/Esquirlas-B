using Esquirlas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esquirlas.Infrastructure.EntityConfigurations
{
    public class PersonajeConfiguration : IEntityTypeConfiguration<Personaje>
    {
        public void Configure(EntityTypeBuilder<Personaje> builder)
        {
            builder.ToTable("Personajes");

            builder.Property(e => e.PersonajeId)
                .HasAnnotation("Relational:ColumnName", "PersonajeId")
                .ValueGeneratedOnAdd();

            builder.HasKey(e => e.PersonajeId);

            builder.Property(x => x.Name)
                .HasAnnotation("Relational:ColumnName", "Name")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.LastName)
                .HasAnnotation("Relational:ColumnName", "LastName")
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Age)
                .HasAnnotation("Relational:ColumnName", "Age")
                .IsRequired();

            builder.Property(e => e.Raza)
                .HasAnnotation("Relational:ColumnName", "Race")
                .IsRequired();

            builder.Property(e => e.Clase)
                .HasAnnotation("Relational:ColumnName", "Class")
                .IsRequired();

            builder.Property(e => e.Status)
                .HasAnnotation("Relational: ColumnName", "Status")
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .HasAnnotation("Relational:ColumnName", "IsDeleted")
                .IsRequired();



            /* Se agregaron los enums de Raza y Clases... la pregunta es, como la integramos para que quede
            escrita??*/


        }
    }
}
