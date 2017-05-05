using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_api_components.Models;
using web_api_components.DTO;
using System.Web.Http;

namespace web_api_components.Controllers
{
    public class UserController : ApiController
    {
        public IHttpActionResult Get()
        {
            UserBALayer ub = new UserBALayer();
            IEnumerable<UserDTO> data = ub.findAll();

            if (data.Count() < 1) { return BadRequest("Users don't exist"); };
            return Ok(data);
        }


        public IHttpActionResult postCreateUser([FromBody] UserDTO user)
        {
            UserBALayer ubl = new UserBALayer();
            UserDTO data = ubl.addUser(user);
            if(data.Name == null) { return BadRequest("User wasn't created successfully"); };
            return Ok(data);
        }

    

        [Route("api/user/login")]
        public IHttpActionResult postTryToLogin([FromBody] UserDTO user)
        {
            UserBALayer ub1 = new UserBALayer();
            UserDTO data = ub1.login(user);
            if(data.Id == null) { return BadRequest("Incorrect credentials. Pls change name/password and try again"); };
            return Ok(data);
        }
    }
}