using Esquirlas.Domain.Common;
using Esquirlas.Domain.DTOs;
using System.Collections;
using System.Collections.Generic;

namespace Esquirlas.Application.Interfaces
{
    public interface IPersonajesServices
    {
        IEnumerable<PersonajeDTO> GetAllPersonajes();
        PersonajeDTO GetPersonajeById(int personajeId);
        Result CreatePersonaje(PersonajeDTO personajesDTO);
        Result DeletePersonaje(PersonajeDTO personajesDTO);
        Result UpdatePersonaje(PersonajeDTO personajeDTO);
        Result PersonajeFilterBy(int filtro);
    }
}
