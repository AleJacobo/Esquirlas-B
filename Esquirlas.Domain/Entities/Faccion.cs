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
