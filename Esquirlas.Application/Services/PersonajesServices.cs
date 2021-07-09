using AutoMapper;
using Esquirlas.Application.Interfaces;
using Esquirlas.Domain.Common;
using Esquirlas.Domain.DTOs;
using Esquirlas.Domain.Entities;
using Esquirlas.Domain.Enums;
using Esquirlas.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;

namespace Esquirlas.Application.Services
{
    public class PersonajesServices : IPersonajesServices
    {
        #region Object and Context
        private readonly IMapper mapper;
        private readonly IPersonajesRepository IpersonajesRepository;

        public PersonajesServices(IMapper mapper, IPersonajesRepository Ipersonajesrepository)
        {
            this.IpersonajesRepository = Ipersonajesrepository;
            this.mapper = mapper;
        }
        #endregion
        public IEnumerable<PersonajeDTO> GetAllPersonajes()
        {
            var result = IpersonajesRepository.GetAllPersonajes();
            var response = mapper.Map<IEnumerable<PersonajeDTO>>(result);

            return response;
        }
        public PersonajeDTO GetPersonajeById(int personajeId)
        {
            var entity = IpersonajesRepository.GetPersonajeById(personajeId);
            var response = mapper.Map<PersonajeDTO>(entity);

            return response;
        }
        public Result CreatePersonaje(PersonajeDTO personajeDTO)
        {
            bool exists = IpersonajesRepository.PersonajeExists(personajeDTO.PersonajeId);
            if (exists)
                return new Result().Fail("Ya Existe un Registro de este Personaje");

            var entity = mapper.Map<Personaje>(personajeDTO);

            IpersonajesRepository.CreatePersonaje(entity);

            return new Result().Success($"Se Registró el Personaje {entity.Name} {entity.LastName}");
        }
        public Result DeletePersonaje(PersonajeDTO personajeDTO)
        {
            Personaje request = IpersonajesRepository.GetPersonajeById(personajeDTO.PersonajeId);
            if (request == null)
                return new Result().NotFound();

            request.IsDeleted = true;

            var entity = mapper.Map<Personaje>(request);

            IpersonajesRepository.UpdatePersonaje(entity);
            return new Result().Success("Se eliminó el Personaje");
        }
        public Result UpdatePersonaje(PersonajeDTO personajeDTO)
        {
            var oldper = IpersonajesRepository.GetPersonajeById(personajeDTO.PersonajeId);
            if (oldper == null)
                return new Result().NotFound();

            var entity = mapper.Map<Personaje>(personajeDTO);

            IpersonajesRepository.UpdatePersonaje(entity);
            return new Result().Success("Se han aplicado los cambios correctamente");
        }
        public Result PersonajeFilterBy(int filtro)
        {
            eFiltrosPersonajes filter = (eFiltrosPersonajes)(Enum.GetValues(typeof(eFiltrosPersonajes)))
                .GetValue(filtro);

            var response = IpersonajesRepository.PersonajeFilterBy(filter);

            var response2 = mapper.Map<List<Personaje>>(response);

            return new Result().Success($"{response2}");
        }
    }
}
