using Esquirlas.Domain.Common;
using Esquirlas.Domain.DTOs;
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
        Result GetAllPersonajes(PersonajeDTO personajesDTO);
        Result CreatePersonaje(PersonajeDTO personajesDTO);
        Result DeletePersonaje(PersonajeDTO personajesDTO);        
        Result UpdatePersonaje(PersonajeDTO personajeDTO);
    }
}
