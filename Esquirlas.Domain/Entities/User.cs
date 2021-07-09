namespace Esquirlas.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
