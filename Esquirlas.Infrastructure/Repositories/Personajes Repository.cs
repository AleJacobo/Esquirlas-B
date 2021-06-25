using Esquirlas.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Infrastructure.Repositories
{
    public class Personajes_Repository
    {
        private DataContext context { get; set; }
        public Personajes_Repository(DataContext context)
        {
            this.context = context;
        }
        public List<PersonajesDTO> getAllPersonajes()
        {
            List<PersonajesDTO> resultpersonajes = new List<PersonajesDTO>();

            var personajes = context.Facciones.Where(x => x.Status == true).ToList();

            foreach (var x in personajes)
            {
                PersonajesDTO personaje= new PersonajesDTO
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
        }
    }
}
