﻿using Esquirlas.Domain.Common;
using Esquirlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Application.Interfaces
{
    public interface IPersonajes_Services
    {
        Result GetAllFilter(Personaje request);
        Result CreatePersonaje(Personaje request);
        Result DeletePersonaje(Guid PersonajeId);        
        Result UpdatePersonaje();
    }
}
