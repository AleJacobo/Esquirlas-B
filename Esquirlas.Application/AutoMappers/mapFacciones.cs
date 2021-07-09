using AutoMapper;
using Esquirlas.Domain.DTOs;
using Esquirlas.Domain.Entities;

namespace Esquirlas.Application.AutoMappers
{
    public class mapFacciones : Profile
    {
        public mapFacciones()
        {
            CreateMap<FaccionDTO, Faccion>().ReverseMap()
            //Se puede personalizar para cuando no usas los mismos datos en cada clase o cuando se llaman distinto pero es lo mismo (ejemplo con dos idiomas)
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
                .ForMember(x => x.IsDeleted, y => y.MapFrom(z => z.IsDeleted));
        }
    }
}
