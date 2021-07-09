using Esquirlas.Domain.Common;
using Esquirlas.Domain.Entities;
using Esquirlas.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Esquirlas.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Faccion> Facciones { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // las configurations ayudan con las especificaciones que van a la base de datos
            modelBuilder.ApplyConfiguration(new FaccionConfiguration());
            modelBuilder.ApplyConfiguration(new PersonajeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            SeedInitialData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            //model builder enlaza los datos prefijados de las libreries y enums creados a la base de datos
            /* no se cual usar
            modelBuilder.Entity<Casa>().HasData(new CasasEnum());
            modelBuilder.Entity<Clase>().HasData(new ClasesEnum());
            modelBuilder.Entity<Deidad>().HasData(new DeidadesEnum());
            modelBuilder.Entity<Usuario>().HasData(new UsuariosEnum());
            */

            modelBuilder.Entity<Casa>().Property(e => e.Nombre).HasConversion<string>();
            modelBuilder.Entity<Clase>().Property(e => e.Nombre).HasConversion<string>();
            modelBuilder.Entity<Dios>().Property(e => e.Nombre).HasConversion<string>();

            foreach (var item in CiudadesDictionary.Ciudades)
            {
                modelBuilder.Entity<Ciudad>().HasData(new Ciudad[]
                {
                    new Ciudad() { CiudadId = item.Key, Nombre = item.Value },
                });
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
