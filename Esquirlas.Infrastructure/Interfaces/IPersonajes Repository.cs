using Esquirlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Infrastructure.Interfaces
{
    public interface IPersonajes_Repository
    {
        IQueryable<Personaje> GetAllPersonajes();
        Personaje GetById(Guid personajeId);
        bool Exists(Guid personajeId);
        void Create(Personaje entity);
        void Update(Personaje entity);
    }
}
