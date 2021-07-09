using AutoMapper;
using Esquirlas.Application.Interfaces;
using Esquirlas.Domain.Common;
using Esquirlas.Domain.DTOs;
using Esquirlas.Domain.Entities;
using Esquirlas.Infrastructure.Interfaces;

namespace Esquirlas.Application.Services
{
    public class UsersServices : IUsersServices
    {
        #region Obj and Const
        private readonly IMapper mapper;
        private readonly IUsersRepository IusersRepository;

        public UsersServices(IMapper mapper, IUsersRepository IusersRepository)
        {
            this.IusersRepository = IusersRepository;
            this.mapper = mapper;
        }
        #endregion
        public Result CreateUser(UserDTO userDTO)
        {
            bool exist = IusersRepository.FindUser(userDTO.Email);
            if (exist)
            {
                return new Result().Fail("El mail ya se encuentra registrado");
            }

            var entity = mapper.Map<User>(userDTO);

            IusersRepository.CreateUser(entity);

            return new Result().Success("Se registro correctamente la cuenta");

        }
        public Result LogIn(string Email)
        {
            var isOn = IusersRepository.IsOn(Email);

            if (isOn == false)
            {
                return new Result().Fail("Inicie sesion para continuar");
            }
            else
            {
                return new Result().Success("Logueado correctamente");
            }
        }
        public Result LogOut(string Email)
        {
            var isOn = IusersRepository.IsOn(Email);

            if (isOn == true)
            {
                return new Result().Success("Deslogueado correctamente");
            }
            else
            {
                return new Result().Fail("Sesion no encontrada");
            }
        }
    }
}