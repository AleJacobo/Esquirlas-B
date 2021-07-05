using AutoMapper;
using Esquirlas.Application.Interfaces;
using Esquirlas.Domain.Common;
using Esquirlas.Domain.DTOs;
using Esquirlas.Domain.Entities;
using Esquirlas.Domain.Enums;
using Esquirlas.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Application.Services
{
    public class PersonajesServices : IPersonajesServices
    {
        #region Object and Context
        private readonly IMapper mapper;
        private readonly IPersonajesRepository Ipersonajesrepository;

        public PersonajesServices(IMapper mapper, IPersonajesRepository Ipersonajesrepository)
        {
            this.Ipersonajesrepository = Ipersonajesrepository;
            this.mapper = mapper;
        } 
        #endregion
        public Result GetAllPersonajes()
        {
            var personajesDb = Ipersonajesrepository.GetAllPersonajes();

            var response = personajesDb;

            var response2 = mapper.Map<List<Personaje>>(response);

            return new Result().Success($"{response2}");
            
        }
        public Result CreatePersonaje(PersonajeDTO personajeDTO)
        {
            bool exists = Ipersonajesrepository.PersonajeExists(personajeDTO.PersonajeId);
            if (exists)
                return new Result().Fail("Ya Existe un Registro de este Personaje");

            var entity = mapper.Map<Personaje>(personajeDTO);

            Ipersonajesrepository.CreatePersonaje(entity);

            return new Result().Success($"Se Registró el Personaje {entity.Name} {entity.LastName}");
        }
        public Result DeletePersonaje(PersonajeDTO personajeDTO)
        {
            Personaje entity = Ipersonajesrepository.GetPersonajeById(personajeDTO.PersonajeId);
            if (entity == null)
                return new Result().NotFound();

            entity.IsDeleted = true;

            Ipersonajesrepository.UpdatePersonaje(entity);
            return new Result().Success("Se eliminó el Personaje");
        }
        public Result UpdatePersonaje(PersonajeDTO personajeDTO)
        {
            var oldper = Ipersonajesrepository.GetPersonajeById(personajeDTO.PersonajeId);
            if (oldper == null)
                return new Result().NotFound();

            var entity = mapper.Map<Personaje>(personajeDTO);

            Ipersonajesrepository.UpdatePersonaje(entity);
            return new Result().Success("Se han aplicado los cambios correctamente");
        }
        public Result PersonajeFilterBy(int filtro)
        {
            eFiltrosPersonajes filter = (eFiltrosPersonajes)(Enum.GetValues(typeof(eFiltrosPersonajes)))
                .GetValue(filtro);

            var response = Ipersonajesrepository.PersonajeFilterBy(filter);
            
            var response2 = mapper.Map<List<Personaje>>(response);

            return new Result().Success($"{response2}");
        }
    }
}
