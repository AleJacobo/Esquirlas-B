using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esquirlas.Domain.Common;
using Esquirlas.Domain.Entities;

namespace Esquirlas.Application.Interfaces
{
    interface IUserServices
    {
        Result CreateUser(User request);         
        Result LogIn(string Email);
        Result LogOut(string Email);
    }
}
