using Esquirlas.Domain.Entities;
using Esquirlas.Infrastructure.Interfaces;
using System.Linq;

namespace Esquirlas.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        #region Obj and Const
        private DataContext context { get; set; }
        public UsersRepository(DataContext context)
        {
            this.context = context;
        }
        #endregion
        public bool FindUser(string Email)
        {
            return context.Users.Any(x => x.Email == Email);
        }
        public void CreateUser(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
        }
        public bool IsOn(string Email)
        {
            return context.Users.Any(x => x.Email == Email && x.Status == true);
        }
        public void LogIn(string Email, string Password)
        {
            var entity = context.Users.Where(x => x.Email == Email
                                                  && x.Password == Password
                                                  && x.Status == false).FirstOrDefault();
            if (entity != null)
            {
                entity.Status = true;
                context.SaveChanges();
            }
            else
            {
                return;
            }
        }
        public void LogOut(string Email)
        {
            var entity = context.Users.Where(x => x.Email == Email && x.Status == true).FirstOrDefault();
            if (entity != null)
            {
                entity.Status = false;
                context.SaveChanges();
            }
            else
            {
                return;
            }
        }
    }
}