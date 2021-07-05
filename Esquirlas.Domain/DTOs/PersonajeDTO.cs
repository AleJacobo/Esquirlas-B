using Esquirlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Domain.DTOs
{
    public class PersonajeDTO
    {
        public int PersonajeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public eRazas Raza { get; set; }    
        public eClases Clase { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}