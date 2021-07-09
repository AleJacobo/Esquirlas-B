using Esquirlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Domain.DTOs
{
    public class PersonajesDTO
    {
        public Guid PersonajeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhotoUrl { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }

        //para heredar de la otra clase
        public virtual Faccion Faccion { get; set; }

        //para heredar los enums y diccionaries
        public virtual Casa Casa { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public virtual Clase Clase { get; set; }
        public virtual Deidad Deidad { get; set; }
    }
}