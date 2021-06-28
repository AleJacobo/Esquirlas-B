using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Infrastructure.Repositories
{
    public class Facciones_Repository
    {
        private readonly DataContext context;
        public Facciones_Repository(DataContext context)
        {
            this.context = context;
        }

        //forma ale
        public List<FaccionesDTO> getAllFacciones()
        {
            List<FaccionesDTO> resultfacciones = new List<FaccionesDTO>();

            var facciones = context.Facciones.Where(x => x.Status == true).ToList();

            foreach (var x in facciones)
            {
                FaccionesDTO faccion = new FaccionesDTO
                {
                    // Agregar Primitivos aca.
                };
                resultfacciones.Add(faccion);
            }
            return resultfacciones;
        }
        public void AddFaccion(FaccionesDTO faccionesDTO)
        {
            context.Facciones.Add(new Domain.Entities.Faccion()
            {
                // Agregar con primitivos

            });
            context.SaveChanges();
        }
        public void ModFaccion(FaccionesDTO faccionesDTO)
        {
            var faccion = context.Facciones.Where(x => x.Status == true).FirstOrDefault();

            if (faccion != null)
            {
                // hacer el update de primitivos
                context.Facciones.Update(faccion);
                context.SaveChanges();
            }

        }
        public void RemoveFaccion()
        {
            var faccion = context.Facciones.Where(x => x.Status == true).FirstOrDefault();
            // verificacion con ID o con alguna otro primitivo

            if (faccion != null)
            {
                faccion.Status = false;
                context.Facciones.Update(faccion);
                context.SaveChanges();
            }
        }
        public FaccionesDTO getFaccion()
        {
            var faccion = context.Facciones.Where(x => x.Status == true).FirstOrDefault();

            FaccionesDTO faccionesDTO = new FaccionesDTO()
            {
                //agregar primitivos
            };
            return faccionesDTO;

            //forma nel
        }
    }
}
