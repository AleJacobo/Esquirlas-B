using Esquirlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Infrastructure.Interfaces
{
    public interface IFaccionesRepository
    {
        IQueryable<Faccion> GetAllFacciones();
        Faccion GetFaccionById(int faccionId);
        bool FaccionExists(int faccionId);
        void CreateFaccion(Faccion entity);
        void UpdateFaccion(Faccion entity);
    }
}
