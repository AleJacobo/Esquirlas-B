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
        private readonly IPersonajesServices personajes_Services;

        public PersonajesController(IPersonajesServices personajes_Services)
        {
            this.personajes_Services = personajes_Services;
        }

        [HttpGet]
        public ActionResult<Result> GetFilter([FromQuery] Personaje request)
        {
            var response = personajes_Services.GetAllPersonajes(request);

            return response;
        }

        [HttpPost]
        public ActionResult<Result> Create([FromBody] Personaje request)
        {
            var response = personajes_Services.CreatePersonaje(request);

            if (response.HasErrors)
                return BadRequest(response.Messages);

            return Ok(response);
        }

        [HttpPut]
        public ActionResult<Result> Update()
        {
            var response = personajes_Services.UpdatePersonaje();

            if (response.HasErrors)
            {
                return BadRequest(response.Messages);
            }

            return Ok(response);
        }

        [HttpDelete("{personajeId}")]
        public ActionResult<Result> Delete([FromRoute] Guid personajeId)
        {
            var response = personajes_Services.DeletePersonaje(personajeId);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }
    }
}
