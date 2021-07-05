using Esquirlas.Domain.Common;
using Esquirlas.Domain.Entities;
using Esquirlas.Domain.DTOs;

namespace Esquirlas.Application.Interfaces
{
    public interface IFaccionesServices
    {
        Result GetAllFacciones();
        Result CreateFaccion(FaccionDTO faccionDTO);
        Result DeleteFaccion(FaccionDTO faccionDTO);
        Result UpdateFaccion(FaccionDTO faccionDTO);
        Result FaccionFilterBy(int filtro);

    }
}
