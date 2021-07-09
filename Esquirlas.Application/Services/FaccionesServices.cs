using AutoMapper;
using Esquirlas.Application.Interfaces;
using Esquirlas.Domain.Common;
using Esquirlas.Domain.DTOs;
using Esquirlas.Domain.Entities;
using Esquirlas.Domain.Enums;
using Esquirlas.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;

namespace Esquirlas.Application.Services
{
    public class FaccionesServices : IFaccionesServices
    {
        #region Obj and Context
        private readonly IMapper mapper;
        private readonly IFaccionesRepository IfaccionesRepository;
        public FaccionesServices(IMapper mapper, IFaccionesRepository Ifaccionesrepository)
        {
            this.IfaccionesRepository = Ifaccionesrepository;
            this.mapper = mapper;
        }
        #endregion
        public IEnumerable<FaccionDTO> GetAllFacciones()
        {
            var response = IfaccionesRepository.GetAllFacciones();
            var response2 = mapper.Map<List<FaccionDTO>>(response);

            return response2;
        }
        public Result CreateFaccion(FaccionDTO faccionDTO)
        {
            bool exists = IfaccionesRepository.FaccionExists(faccionDTO.FaccionId);
            if (exists)
                return new Result().Fail("Ya existe un registro de esa faccion");

            var entity = mapper.Map<Faccion>(faccionDTO);
            IfaccionesRepository.CreateFaccion(entity);

            return new Result().Success($"Se Registró la Faccion {faccionDTO.Name}");
        }
        public Result DeleteFaccion(FaccionDTO faccionDTO)
        {
            Faccion entity = IfaccionesRepository.GetFaccionById(faccionDTO.FaccionId);
            if (entity == null)
                return new Result().NotFound();

            entity.IsDeleted = true;

            IfaccionesRepository.UpdateFaccion(entity);
            return new Result().Success("Se eliminó la Faccion");
        }
        public Result UpdateFaccion(FaccionDTO faccionDTO)
        {
            Faccion oldfaccion = IfaccionesRepository.GetFaccionById(faccionDTO.FaccionId);
            if (oldfaccion == null)
                return new Result().NotFound();

            var entity = mapper.Map<Faccion>(faccionDTO);

            IfaccionesRepository.UpdateFaccion(entity);
            return new Result().Success("Se han aplicado los cambios correctamente");

        }
        public Result FaccionFilterBy(int filtro)
        {
            eFiltrosFacciones filter = (eFiltrosFacciones)(Enum.GetValues(typeof(eFiltrosFacciones)))
               .GetValue(filtro);

            var response = IfaccionesRepository.FaccionFilterBy(filter);

            var response2 = mapper.Map<List<Personaje>>(response);

            return new Result().Success($"{response2}");
        }
    }
}
