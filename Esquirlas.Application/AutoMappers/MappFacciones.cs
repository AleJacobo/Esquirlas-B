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
    public class MappFacciones : Profile
    {
        public MappFacciones()
        {
            CreateMap<FaccionesDTO, Faccion>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted));                
        }
    }
}
