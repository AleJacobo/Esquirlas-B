using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public int Telephone { get; set; }
        public string PhotoUrl { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }

        //para heredar los enums
        public virtual Usuario Usuario { get; set; }
    }
}
