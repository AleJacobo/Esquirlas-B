using Esquirlas.Domain.Common;
using Esquirlas.Domain.DTOs;
using System.Collections;
using System.Collections.Generic;

namespace Esquirlas.Application.Interfaces
{
    public interface IFaccionesServices
    {
        IEnumerable<FaccionDTO> GetAllFacciones();
        Result CreateFaccion(FaccionDTO faccionDTO);
        Result DeleteFaccion(FaccionDTO faccionDTO);
        Result UpdateFaccion(FaccionDTO faccionDTO);
        Result FaccionFilterBy(int filtro);

    }
}
