using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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