using Esquirlas.Application.Interfaces;
using Esquirlas.Domain.Common;
using Esquirlas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult<Result> GetAllPersonajes([FromQuery] Faccion request)
        {
            var response = IfaccionesServices.GetAllFacciones(request);

            return response;
        }

        [HttpPost]
        public ActionResult<Result> Create([FromBody] Faccion request)
        {
            var response = IfaccionesServices.CreateFaccion(request);

            if (response.HasErrors)
                return BadRequest(response.Messages);

            return Ok(response);
        }

        [HttpPut]
        public ActionResult<Result> Update()
        {
            var response = IfaccionesServices.UpdateFaccion();

            if (response.HasErrors)
            {
                return BadRequest(response.Messages);
            }

            return Ok(response);
        }

        [HttpDelete("{faccionId}")]
        public ActionResult<Result> Delete([FromRoute] int faccionId)
        {
            var response = IfaccionesServices.DeleteFaccion(faccionId);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }
    }
}
