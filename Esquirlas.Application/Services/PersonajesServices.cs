using AutoMapper;
using Esquirlas.Application.Interfaces;
using Esquirlas.Domain.Common;
using Esquirlas.Domain.Entities;
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
        private readonly IMapper mapper;
        private readonly IPersonajesRepository IpersonajesRepository;
        
        public PersonajesServices(IMapper mapper, IPersonajesRepository IpersonajesRepository)
        {            
            this.IpersonajesRepository = IpersonajesRepository;
            this.mapper = mapper;
        }

        public IEnumerable<Personaje> GetAllPersonajes()
        {
            var result = IpersonajesRepository.GetAllPersonajes();
            var response = mapper.Map<IEnumerable<Personaje>>(result);

            return response;            
        }

        public Personaje GetPersonajeById(Guid personajeId)
        {
            var result = IpersonajesRepository.GetPersonajeById(personajeId);
            var response = mapper.Map<Personaje>(result);

            return response;
        }

        public Result CreatePersonaje(Personaje request)
        {
            bool exists = IpersonajesRepository.PersonajeExists(request.PersonajeId);
            if (exists)
                return new Result().Fail("Ya Existe un Registro de este Personaje");

            var entity = mapper.Map<Personaje>(request);

            IpersonajesRepository.CreatePersonaje(entity);

            return new Result().Success($"Se Registró el Personaje {entity.Name} {entity.LastName}");
        }
        public Result UpdatePersonaje(Guid personajeId, Personaje request)
        {
            bool exists = IpersonajesRepository.PersonajeExists(request.PersonajeId);
            if (exists == false)
                return new Result().NotFound();

            var entity = mapper.Map<Personaje>(request);

            IpersonajesRepository.UpdatePersonaje(entity);

            return new Result().Success("Se modificó con éxito");
        }

        public Result DeletePersonaje(Guid PersonajeId)
        {
            Personaje entity = IpersonajesRepository.GetPersonajeById(PersonajeId);
            if (entity == null)
                return new Result().NotFound();

            entity.IsDeleted = true;

            IpersonajesRepository.UpdatePersonaje(entity);
            return new Result().Success("Se eliminó el Personaje");
        }       
        
    }
}
