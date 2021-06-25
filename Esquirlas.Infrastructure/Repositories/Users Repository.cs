using System.Collections.Generic;

namespace Esquirlas.Infrastructure.Repositories
{
    public class Users_Repository
    {
        private DataContext context { get; set; }
        public Users_Repository(DataContext context)
        {
            this.context = context;
        }


    }
}
