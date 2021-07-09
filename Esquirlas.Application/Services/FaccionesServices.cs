using AutoMapper;
using Esquirlas.Application.Interfaces;
using Esquirlas.Domain.Common;
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
        private readonly IMapper mapper;
        private readonly IFaccionesRepository IfaccionesRepository;

        public FaccionesServices(IMapper mapper, IFaccionesRepository IfaccionesRepository)
        {
            this.IfaccionesRepository = IfaccionesRepository;
            this.mapper = mapper;
        }

        public Result GetAllFacciones(Faccion request)
        {
            var faccionesDb = IfaccionesRepository.GetAllFacciones();

            var response = faccionesDb;

            var response2 = mapper.Map<List<Faccion>>(response);

            return new Result().Success($"{response2}");

        }

        public Result CreateFaccion(Faccion request)
        {
            bool exists = IfaccionesRepository.FaccionExists(request.FaccionId);
            if (exists)
                return new Result().Fail("Ya existe un registro de esa faccion");

            var entity = mapper.Map<Faccion>(request);
            IfaccionesRepository.CreateFaccion(entity);

            return new Result().Success($"Se Registró la Faccion {entity.Name}");
        }
        public Result DeleteFaccion(int faccionId)
        {
            Faccion entity = IfaccionesRepository.GetFaccionById(faccionId);
            if (entity == null)
                return new Result().NotFound();

            entity.IsDeleted = true;

            IfaccionesRepository.UpdateFaccion(entity);
            return new Result().Success("Se eliminó la Faccion");
        }

        public Result UpdateFaccion()
        {
            throw new NotImplementedException();
        }
    }
}
