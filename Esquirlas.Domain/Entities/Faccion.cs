using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Domain.Entities
{
    public class Faccion
    {
        public int FaccionId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
