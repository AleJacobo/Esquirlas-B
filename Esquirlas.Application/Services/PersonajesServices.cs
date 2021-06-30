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
        private readonly IPersonajesRepository Ipersonajesrepository;
        
        public PersonajesServices(IMapper mapper, IPersonajesRepository Ipersonajesrepository)
        {            
            this.Ipersonajesrepository = Ipersonajesrepository;
            this.mapper = mapper;
        }

        public Result GetAllPersonajes(Personaje request)
        {
            var personajesDb = Ipersonajesrepository.GetAllPersonajes();

            var response = personajesDb;

            var response2 = mapper.Map<List<Personaje>>(response);

            return new Result().Success($"{response2}");
            
        }

        public Result CreatePersonaje(Personaje request)
        {
            bool exists = Ipersonajesrepository.PersonajeExists(request.PersonajeId);
            if (exists)
                return new Result().Fail("Ya Existe un Registro de este Personaje");

            var entity = mapper.Map<Personaje>(request);

            Ipersonajesrepository.CreatePersonaje(entity);

            return new Result().Success($"Se Registró el Personaje {entity.Name} {entity.LastName}");
        }

        public Result DeletePersonaje(Guid PersonajeId)
        {
            Personaje entity = Ipersonajesrepository.GetPersonajeById(PersonajeId);
            if (entity == null)
                return new Result().NotFound();

            entity.IsDeleted = true;

            Ipersonajesrepository.UpdatePersonaje(entity);
            return new Result().Success("Se eliminó el Personaje");
        }
        
        public Result UpdatePersonaje()
        {
            throw new NotImplementedException();
        }
    }
}
