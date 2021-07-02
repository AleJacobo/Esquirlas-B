using Esquirlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Domain.Entities
{
    public class Casa
    {
        public int CasaId { get; set; }
        public CasasEnum Nombre { get; set; }
        public int Prestigio { get; set; }
    }
}
