using Esquirlas.Domain.Common;
using Esquirlas.Domain.DTOs;

namespace Esquirlas.Application.Interfaces
{
    public interface IUsersServices
    {
        Result CreateUser(UserDTO userDTO);
        Result LogIn(string Email);
        Result LogOut(string Email);
    }
}
