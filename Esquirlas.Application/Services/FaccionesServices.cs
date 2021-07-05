using AutoMapper;
using Esquirlas.Application.Interfaces;
using Esquirlas.Domain.Common;
using Esquirlas.Domain.DTOs;
using Esquirlas.Domain.Entities;
using Esquirlas.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Application.Services
{
    public class FaccionesServices : IFaccionesServices
    {
        #region Obj and Context
        private readonly IMapper mapper;
        private readonly IFaccionesRepository Ifaccionesrepository;
        public FaccionesServices(IMapper mapper, IFaccionesRepository Ifaccionesrepository)
        {
            this.Ifaccionesrepository = Ifaccionesrepository;
            this.mapper = mapper;
        } 
        #endregion
        public Result GetAllFacciones()
        {
            var faccionesDb = Ifaccionesrepository.GetAllFacciones();

            var response = faccionesDb;

            var response2 = mapper.Map<List<FaccionDTO>>(response);

            return new Result().Success($"{response2}");

        }
        public Result CreateFaccion(FaccionDTO faccionDTO)
        {
            bool exists = Ifaccionesrepository.FaccionExists(faccionDTO.FaccionId);
            if (exists)
                return new Result().Fail("Ya existe un registro de esa faccion");

            var entity = mapper.Map<Faccion>(faccionDTO);
            Ifaccionesrepository.CreateFaccion(entity);

            return new Result().Success($"Se Registró la Faccion {faccionDTO.Name}");
        }
        public Result DeleteFaccion(FaccionDTO faccionDTO)
        {
            Faccion entity = Ifaccionesrepository.GetFaccionById(faccionDTO.FaccionId);
            if (entity == null)
                return new Result().NotFound();

            entity.IsDeleted = true;

            Ifaccionesrepository.UpdateFaccion(entity);
            return new Result().Success("Se eliminó la Faccion");
        }
        public Result UpdateFaccion(FaccionDTO faccionDTO)
        {
            Faccion oldfaccion = Ifaccionesrepository.GetFaccionById(faccionDTO.FaccionId);
            if (oldfaccion == null)
                return new Result().NotFound();
            
            var entity = mapper.Map<Faccion>(faccionDTO);

            Ifaccionesrepository.UpdateFaccion(entity);
            return new Result().Success("Se han aplicado los cambios correctamente");

        }
    }
}
