using Esquirlas.Domain.Entities;
using Esquirlas.Domain.Enums;
using System.Linq;

namespace Esquirlas.Infrastructure.Interfaces
{
    public interface IFaccionesRepository
    {
        IQueryable<Faccion> GetAllFacciones();
        Faccion GetFaccionById(int faccionId);
        bool FaccionExists(int faccionId);
        void CreateFaccion(Faccion entity);
        void UpdateFaccion(Faccion entity);
        IQueryable<Faccion> FaccionFilterBy(eFiltrosFacciones filter);
    }
}
