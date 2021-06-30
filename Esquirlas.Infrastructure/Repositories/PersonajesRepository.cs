using Esquirlas.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Esquirlas.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Infrastructure.Repositories
{
    public class PersonajesRepository: IPersonajesRepository
    {
        private readonly DataContext context;
        public PersonajesRepository(DataContext context)
        {
            this.context = context;
        }
        #region FormaAle
		//forma ale
        /*
        public List<PersonajesDTO> getAllPersonajes()
        {
            List<PersonajesDTO> resultpersonajes = new List<PersonajesDTO>();

            var personajes = context.Facciones.Where(x => x.Status == true).ToList();

            foreach (var x in personajes)
            {
                PersonajesDTO personaje = new PersonajesDTO
                {
                    // Agregar Primitivos aca.
                };
                resultpersonajes.Add(personaje);
            }
            return resultpersonajes;
        }
        public void AddPersonaje(PersonajesDTO personajesDTO)
        {
            context.Personajes.Add(new Domain.Entities.Personaje()
            {
                // Agregar con primitivos

            });
            context.SaveChanges();
        }
        public void ModPersonaje(PersonajesDTO personajesDTO)
        {
            var personaje = context.Personajes.Where(x => x.Status == true).FirstOrDefault();

            if (personaje != null)
            {
                // hacer el update de primitivos
                context.Personajes.Update(personaje);
                context.SaveChanges();
            }
        }
        public void RemovePersonaje()
        {
            var personaje = context.Personajes.Where(x => x.Status == true).FirstOrDefault();
            // verificacion con ID o con alguna otro primitivo

            if (personaje != null)
            {
                personaje.Status = false;
                context.Personajes.Update(personaje);
                context.SaveChanges();
            }
        }
        public PersonajesDTO getPersonaje()
        {
            var personaje = context.Personajes.Where(x => x.Status == true).FirstOrDefault();

            PersonajesDTO personajesDTO = new PersonajesDTO()
            {
                //agregar primitivos
            };
            return personajesDTO;
        } */
	#endregion
        //forma nelson
        // Todo se realiza al enlazarlo con la interface y el datacontext
        public IQueryable<Personaje> GetAllPersonajes()
        {            
            return context.Personajes
                .Where(x => x.IsDeleted == false);
        }
        public Personaje GetPersonajeById(Guid personajeId)
        {
            return context.Personajes
                .Where(x => x.IsDeleted == false && x.PersonajeId == personajeId).FirstOrDefault();
        }
        public bool PersonajeExists(Guid personajeId)
        {
            return context.Personajes.Any(x => x.PersonajeId == personajeId);
        }
        public void CreatePersonaje(Personaje entity)
        {
            context.Personajes.Add(entity);
            context.SaveChanges();
        }
        /*public void DeletePersonaje(Guid personajeId)
        {
            var personaje= context.Facciones
                .Where(x => x.FaccionId == personajeId && x.IsDeleted == false).FirstOrDefault();

            personaje.IsDeleted = true;
            context.Facciones.Update(personaje);
            context.SaveChanges();
        } */
        public void UpdatePersonaje(Personaje entity)
        {
            context.Personajes.Update(entity);
            context.SaveChanges();
        }
    }
}
