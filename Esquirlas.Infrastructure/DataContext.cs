using Microsoft.EntityFrameworkCore;
using Esquirlas.Domain.Entities;
using System.Data.Entity;

namespace Esquirlas.Infrastructure
{
    public class DataContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public Microsoft.EntityFrameworkCore.DbSet<Personaje> Personajes { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Faccion> Facciones { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }     
    }
}
