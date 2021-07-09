﻿using Esquirlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public UsuariosEnum Nombre { get; set; }
    }
}
