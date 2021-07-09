using AutoMapper;
using Esquirlas.Domain.DTOs;
using Esquirlas.Domain.Entities;

namespace Esquirlas.Application.AutoMappers
{
    public class mapPersonajes : Profile
    {
        public mapPersonajes()
        {
            CreateMap<PersonajeDTO, Personaje>().ReverseMap()
            //Se puede personalizar para cuando no usas los mismos datos en cada clase o cuando se llaman distinto pero es lo mismo (ejemplo con dos idiomas)
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.Age))
                .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
                .ForMember(x => x.IsDeleted, y => y.MapFrom(z => z.IsDeleted))
                .ForMember(x => x.Clase, y => y.MapFrom(z => z.Clase));
        }
    }
}
