using Esquirlas.Application.Interfaces;
using Esquirlas.Domain.Common;
using Esquirlas.Domain.DTOs;
using Esquirlas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace Esquirlas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaccionesController : ControllerBase
    {
        private readonly IFaccionesServices IfaccionesServices;
        public FaccionesController(IFaccionesServices IfaccionesServices)
        {
            this.IfaccionesServices = IfaccionesServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FaccionDTO>> GetAllFacciones()
        {
            var response = IfaccionesServices.GetAllFacciones();

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<FaccionDTO> CreateFaccion([FromBody] FaccionDTO faccionDTO)
        {
            var response = IfaccionesServices.CreateFaccion(faccionDTO);

            if (response.HasErrors)
                return BadRequest(response.Messages);

            return Ok(response);
        }

        [HttpPut]
        public ActionResult<Result> UpdateFaccion(FaccionDTO faccionDTO)
        {
            var response = IfaccionesServices.UpdateFaccion(faccionDTO);

            if (response.HasErrors)
            {
                return BadRequest(response.Messages);
            }

            return Ok(response);
        }

        [HttpDelete("{faccionId}")]
        public ActionResult<Result> Delete([FromRoute] FaccionDTO faccionDTO)
        {
            var response = IfaccionesServices.DeleteFaccion(faccionDTO);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }

        [HttpGet]
        public ActionResult<Result> FaccionesFilterBy([FromQuery] int filtro)
        {
            var response = IfaccionesServices.FaccionFilterBy(filtro);

            return Ok(response);
        }

    }
}
