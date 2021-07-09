using Esquirlas.Domain.Enums;

namespace Esquirlas.Domain.Entities
{
    public class Casa
    {
        public int CasaId { get; set; }
        public eCasas Nombre { get; set; }
        public int Prestigio { get; set; }
    }
}
