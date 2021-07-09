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
        public ActionResult<IEnumerable<Personaje>> GetAllPersonajes()
        {
            var response = IpersonajesServices.GetAllPersonajes();

            return Ok(response);
        }

        [HttpGet("{personajeId}")]
        public ActionResult<Personaje> GetPersonajeById(Guid personajeId)
        {
            var response = IpersonajesServices.GetPersonajeById(personajeId);
            return Ok(response);
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
        public ActionResult<Result> Update([FromBody] Guid personajeId, Personaje request)
        {
            var response = IpersonajesServices.UpdatePersonaje(personajeId, request);

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
