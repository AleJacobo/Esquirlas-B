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
    public class Personajes_Services : IPersonajes_Services
    {
        private readonly IMapper mapper;
        private readonly IPersonajes_Repository personajes_Repository;
        
        public Personajes_Services(IMapper mapper, IPersonajes_Repository personajes_Repository)
        {            
            this.personajes_Repository = personajes_Repository;
            this.mapper = mapper;
        }

        public Result GetAllFilter(Personaje request)
        {
            var personajesDb = personajes_Repository.GetAllPeronajes();

            var response = personajesDb;

            var response2 = mapper.Map<List<Personaje>>(response);

            return new Result().Success($"{response2}");
            
        }

        public Result CreatePersonaje(Personaje request)
        {
            bool exists = personajes_Repository.Exists(request.PersonajeId);
            if (exists)
                return new Result().Fail("Ya Existe un Registro de este Personaje");

            var entity = mapper.Map<Personaje>(request);

            personajes_Repository.Create(entity);

            return new Result().Success($"Se Registró el Personaje {entity.Name} {entity.LastName}");
        }

        public Result DeletePersonaje(Guid PersonajeId)
        {
            Personaje entity = personajes_Repository.GetById(PersonajeId);
            if (entity == null)
                return new Result().NotFound();

            entity.IsDeleted = true;

            personajes_Repository.Update(entity);
            return new Result().Success("Se eliminó el Personaje");
        }
        
        public Result UpdatePersonaje()
        {
            throw new NotImplementedException();
        }
    }
}
