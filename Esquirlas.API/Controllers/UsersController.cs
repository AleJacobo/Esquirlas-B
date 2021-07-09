using Esquirlas.Application.Interfaces;
using Esquirlas.Domain.Common;
using Esquirlas.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Esquirlas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Obj and Contr
        private readonly IUsersServices IusersServices;
        public UsersController(IUsersServices IusersServices)
        {
            this.IusersServices = IusersServices;
        } 
        #endregion
        
        [HttpGet]

        public ActionResult<Result> LogIn([FromQuery] string email)
        {
            var response = IusersServices.LogIn(email);
            return Ok(response);
        }

        [HttpGet]

        public ActionResult<Result> LogOut([FromQuery] string email)
        {
            var response = IusersServices.LogOut(email);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Result> CreateUser([FromBody] UserDTO userDTO)
        {
            var response = IusersServices.CreateUser(userDTO);

            if (response.HasErrors)
                return BadRequest(response.Messages);

            return Ok(response);
        }


    }
}
