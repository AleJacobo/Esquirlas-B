using Esquirlas.Application.Interfaces;
using Esquirlas.Domain.Common;
using Esquirlas.Domain.DTOs;
using Esquirlas.Domain.Entities;
using Esquirlas.Domain.Enums;
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
        #region Obj and Constructor
        private readonly IPersonajesServices IpersonajesServices;
        public PersonajesController(IPersonajesServices IpersonajesServices)
        {
            this.IpersonajesServices = IpersonajesServices;
        } 
        #endregion
        [HttpGet]
        public ActionResult<Result> GetAllPersonajes()
        {
            var response = IpersonajesServices.GetAllPersonajes();

            return response;
        }

        [HttpGet]
        public ActionResult<Result> PersonajesFilterBy([FromQuery] int filtro)
        {
            var response = IpersonajesServices.PersonajeFilterBy(filtro);

            return response;
        }

        [HttpPost]
        public ActionResult<Result> CreatePersonaje([FromBody] PersonajeDTO personajeDTO)
        {
            var response = IpersonajesServices.CreatePersonaje(personajeDTO);

            if (response.HasErrors)
                return BadRequest(response.Messages);

            return Ok(response);
        }

        [HttpPut]
        public ActionResult<Result> UpdatePersonaje(PersonajeDTO personajeDTO)
        {
            var response = IpersonajesServices.UpdatePersonaje(personajeDTO);

            if (response.HasErrors)
            {
                return BadRequest(response.Messages);
            }

            return Ok(response);
        }

        [HttpDelete("{personajeId}")]
        public ActionResult<Result> DeletePersonaje([FromRoute] PersonajeDTO personajeDTO)
        {
            var response = IpersonajesServices.DeletePersonaje(personajeDTO);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }
    }
}
