using Esquirlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Infrastructure.Interfaces
{
    public interface IPersonajesRepository
    {
        IQueryable<Personaje> GetAllPersonajes();
        Personaje GetPersonajeById(int personajeId);
        bool PersonajeExists(int personajeId);
        void CreatePersonaje(Personaje entity);
        void UpdatePersonaje(Personaje entity);
    }
}
