using Esquirlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Domain.Entities
{
    public class Clase
    {
        public int ClaseId { get; set; }
        public ClasesEnum Nombre { get; set; }
    }
}
