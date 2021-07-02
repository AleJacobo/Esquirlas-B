using Esquirlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Domain.Entities
{
    public class Deidad
    {
        public int DeidadId { get; set; }
        public DeidadesEnum Nombre { get; set; }
    }
}
