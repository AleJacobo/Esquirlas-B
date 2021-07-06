using AutoMapper;
using Esquirlas.Domain.DTOs;
using Esquirlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Application.AutoMappers
{
    public class MappUsers : Profile
    {
        public MappUsers()
        {
            CreateMap<UsersDTO, User>().ReverseMap()
            //Se puede personalizar para cuando no usas los mismos datos en cada clase o cuando se llaman distinto pero es lo mismo (ejemplo con dos idiomas)
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.Age))
                .ForMember(x => x.Birthday, y => y.MapFrom(z => z.Birthday))
                .ForMember(x => x.Telephone, y => y.MapFrom(z => z.Telephone))
                .ForMember(x => x.PhotoUrl, y => y.MapFrom(z => z.PhotoUrl))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Nationality, y => y.MapFrom(z => z.Nationality))
                .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
                .ForMember(x => x.IsDeleted, y => y.MapFrom(z => z.IsDeleted))
                .ForMember(x => x.Usuario, y => y.MapFrom(z => z.Usuario));
        }
    }
}
