using AutoMapper;
using Esquirlas.Domain.DTOs;
using Esquirlas.Domain.Entities;

namespace Esquirlas.Application.AutoMappers
{
    public class mapUsers : Profile
    {
        public mapUsers()
        {
            CreateMap<UserDTO, User>().ReverseMap()
            //Se puede personalizar para cuando no usas los mismos datos en cada clase o cuando se llaman distinto pero es lo mismo (ejemplo con dos idiomas)
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.Usuario, y => y.MapFrom(z => z.Usuario))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Status, y => y.MapFrom(z => z.Status));
        }
    }
}
