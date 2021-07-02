using AutoMapper;
using Esquirlas.Application.Interfaces;
using Esquirlas.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Application.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IMapper mapper;
        private readonly IUsersRepository IusersRepository;

        public UsersServices(IMapper mapper, IUsersRepository IusersRepository)
        {
            this.IusersRepository = IusersRepository;
            this.mapper = mapper;
        }
    }
}