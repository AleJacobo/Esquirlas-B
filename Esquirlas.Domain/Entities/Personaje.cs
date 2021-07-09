using Esquirlas.Domain.Enums;

namespace Esquirlas.Domain.Entities
{
    public class Personaje
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
