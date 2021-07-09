using Esquirlas.Domain.Common;
using Esquirlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Application.Interfaces
{
    public interface IPersonajesServices
    {
        IEnumerable<Personaje> GetAllPersonajes();
        Personaje GetPersonajeById(Guid personajeId);
        Result CreatePersonaje(Personaje request);
        Result UpdatePersonaje(Guid personajeId, Personaje request);
        Result DeletePersonaje(Guid personajeId); 
    }
}
