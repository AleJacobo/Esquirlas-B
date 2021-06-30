using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Infrastructure.Repositories
{
    public class UsersRepository
    {
        private DataContext context { get; set; }
        public UsersRepository(DataContext context)
        {
            this.context = context;
        }


    }
}