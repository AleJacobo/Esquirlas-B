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
            CreateMap<PersonajesDTO, Personaje>().ReverseMap();
            //Se puede personalizar para cuando no usas los mismos datos en cada clase o cuando se llaman distinto pero es lo mismo (ejemplo dos idiomas)
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.PhotoUrl))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.Faccion, opt => opt.MapFrom(src => src.Faccion))
                .ForMember(dest => dest.Casa, opt => opt.MapFrom(src => src.Casa))
                .ForMember(dest => dest.Ciudad, opt => opt.MapFrom(src => src.Ciudad))
                .ForMember(dest => dest.Clase, opt => opt.MapFrom(src => src.Clase))
                .ForMember(dest => dest.Deidad, opt => opt.MapFrom(src => src.Deidad));
        }        
    }
}
