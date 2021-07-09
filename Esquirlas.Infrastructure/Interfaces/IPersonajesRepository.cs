using Esquirlas.Domain.Entities;
using Esquirlas.Domain.Enums;
using System.Linq;

namespace Esquirlas.Infrastructure.Interfaces
{
    public interface IPersonajesRepository
    {
        IQueryable<Personaje> GetAllPersonajes();
        Personaje GetPersonajeById(int personajeId);
        bool PersonajeExists(int personajeId);
        void CreatePersonaje(Personaje entity);
        void UpdatePersonaje(Personaje entity);
        IQueryable<Personaje> PersonajeFilterBy(eFiltrosPersonajes filter);
    }
}
