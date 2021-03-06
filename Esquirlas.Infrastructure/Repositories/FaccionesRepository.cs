using Esquirlas.Domain.Entities;
using Esquirlas.Domain.Enums;
using Esquirlas.Infrastructure.Interfaces;
using System.Linq;

namespace Esquirlas.Infrastructure.Repositories
{
    public class FaccionesRepository : IFaccionesRepository
    {
        #region Context - Constructor
        private readonly DataContext context;
        public FaccionesRepository(DataContext context)
        {
            this.context = context;
        }
        #endregion
        public IQueryable<Faccion> GetAllFacciones()
        {
            return context.Facciones
                .Where(x => x.IsDeleted == false);
        }
        public Faccion GetFaccionById(int faccionId)
        {
            return context.Facciones
                   .Where(x => x.IsDeleted == false && x.FaccionId == faccionId).FirstOrDefault();
        }
        public bool FaccionExists(int faccionesId)
        {
            return context.Facciones
                .Any(x => x.FaccionId == faccionesId);
        }
        public void CreateFaccion(Faccion entity)
        {
            context.Facciones.Add(entity);
            context.SaveChanges();
        }
        public void UpdateFaccion(Faccion entity)
        {
            context.Facciones.Update(entity);
            context.SaveChanges();
        }
        public IQueryable<Faccion> FaccionFilterBy(eFiltrosFacciones filter)
        {
            return context.Facciones
                  .Where(x => x.IsDeleted == false && x.Equals(filter));
        }
    }
}