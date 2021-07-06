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
    public class MappPersonajes : Profile
    {
        public MappPersonajes()
        {
            CreateMap<PersonajesDTO, Personaje>().ReverseMap()
            //Se puede personalizar para cuando no usas los mismos datos en cada clase o cuando se llaman distinto pero es lo mismo (ejemplo con dos idiomas)
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.Age))
                .ForMember(x => x.PhotoUrl, y => y.MapFrom(z => z.PhotoUrl))
                .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
                .ForMember(x => x.IsDeleted, y => y.MapFrom(z => z.IsDeleted))
                .ForMember(x => x.Faccion, y => y.MapFrom(z => z.Faccion))
                .ForMember(x => x.Casa, y => y.MapFrom(z => z.Casa))
                .ForMember(x => x.Ciudad, y => y.MapFrom(z => z.Ciudad))
                .ForMember(x => x.Clase, y => y.MapFrom(z => z.Clase))
                .ForMember(x => x.Deidad, y => y.MapFrom(z => z.Deidad));
        }        
    }
}
