using Esquirlas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.Property(e => e.IsDeleted)
                .HasAnnotation("Relational:ColumnName", "IsDeleted")
                .IsRequired();
            // continuar con el resto con respesto a personje validator
        }
    }
}
