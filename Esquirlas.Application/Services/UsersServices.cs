using AutoMapper;
using Esquirlas.Application.Interfaces;
using Esquirlas.Domain.Common;
using Esquirlas.Domain.Entities;
using Esquirlas.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Application.Services
{
    public class UsersServices : IUserServices
    {
        private readonly UsersServices users_;        
        private readonly IMapper mapper;
        private readonly IUsersRepository IUsersrepository;


        public Result CreateUser(User request)
        {
            bool exist = IUsersrepository.FindUser(request.Email);
            if (exist)
            {
                return new Result().Fail("El mail ya se encuentra registrado");
            }

            var entity = mapper.Map<User>(request);

            IUsersrepository.CreateUser(entity);

            return new Result().Success("Se registró correctamente la cuenta");

        }

        public Result LogIn(string Email)
        {
            var isOn = IUsersrepository.IsOn(Email);

            if (isOn == false)
            {
                return new Result().Fail("Inicie sesión para continuar");
            }
            else
            {
                return new Result().Success("Logueado correctamente");
            }
        }

        public Result LogOut(string Email)
        {
            var isOn = IUsersrepository.IsOn(Email);

            if (isOn == true)
            {
                return new Result().Success("Deslogueado correctamente");
            }
            else
            {
                return new Result().Fail("Sesión no encontrada");
            }
        }
    }
}