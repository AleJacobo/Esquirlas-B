using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esquirlas.Domain.Entities;

namespace Esquirlas.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Faccion> Facciones { get; set; }
    }
}
