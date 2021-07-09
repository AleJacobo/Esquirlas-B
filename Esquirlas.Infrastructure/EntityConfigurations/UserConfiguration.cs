using Esquirlas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esquirlas.Infrastructure.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(x => x.UserId)
                .HasAnnotation("Relational:ColumnName", "UserId")
                .ValueGeneratedOnAdd();

            builder.HasKey(x => x.UserId);

            builder.Property(x => x.Usuario)
                .HasAnnotation("Relational:ColumnName", "User")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasAnnotation("Relational:ColumnName", "Email")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasAnnotation("Relational:ColumnName", "Password")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasAnnotation("Relational:ColumnName", "Status")
                .IsRequired();
        }
    }
}
