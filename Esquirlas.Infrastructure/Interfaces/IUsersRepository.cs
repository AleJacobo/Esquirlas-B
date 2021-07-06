using Esquirlas.Domain.Entities;
using System;

namespace Esquirlas.Infrastructure.Interfaces
{
    public interface IUsersRepository
    {
        void CreateUser(User entity);
        bool IsOn(string Email);
        bool FindUser(string Email);
        void LogIn(string Email, string Password);
        void LogOut(string Email);
    }
}
