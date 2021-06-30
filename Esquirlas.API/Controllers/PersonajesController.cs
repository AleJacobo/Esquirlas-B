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
    public class PersonajesController : ControllerBase
    {
        private readonly IPersonajesServices IpersonajesServices;
        public PersonajesController(IPersonajesServices IpersonajesServices)
        {
            this.IpersonajesServices = IpersonajesServices;
        }

        [HttpGet]
        public ActionResult<Result> GetAllPersonajes([FromQuery] Personaje request)
        {
            var response = IpersonajesServices.GetAllPersonajes(request);

            return response;
        }

        [HttpPost]
        public ActionResult<Result> Create([FromBody] Personaje request)
        {
            var response = IpersonajesServices.CreatePersonaje(request);

            if (response.HasErrors)
                return BadRequest(response.Messages);

            return Ok(response);
        }

        [HttpPut]
        public ActionResult<Result> Update()
        {
            var response = IpersonajesServices.UpdatePersonaje();

            if (response.HasErrors)
            {
                return BadRequest(response.Messages);
            }

            return Ok(response);
        }

        [HttpDelete("{personajeId}")]
        public ActionResult<Result> Delete([FromRoute] Guid personajeId)
        {
            var response = IpersonajesServices.DeletePersonaje(personajeId);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }
    }
}
