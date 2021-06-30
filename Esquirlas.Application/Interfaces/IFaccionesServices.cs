using Esquirlas.Domain.Common;
using Esquirlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Application.Interfaces
{
    public interface IFaccionesServices
    {
        Result GetAllFacciones(Faccion request);
        Result CreateFaccion(Faccion request);
        Result DeleteFaccion(Guid faccionId);
        Result UpdateFaccion();

    }
}
