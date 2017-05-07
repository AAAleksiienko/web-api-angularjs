using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api_AngularJs.Business_Layer;
using Web_Api_AngularJs.Data_Access_Layer;

namespace Web_Api_AngularJs.Controllers
{
    public class UserController : ApiController
    {

        public IHttpActionResult Get()
        {
            UserBA ub = new UserBA();
            IEnumerable<UserDA> data = ub.findAll();

            if (data.Count() < 1) { return BadRequest("Users don't exist"); };
            return Ok(data);
        }


        public IHttpActionResult postCreateUser([FromBody] UserDA user)
        {
            UserBA ubl = new UserBA();
            UserDA data = ubl.addUser(user);
            if (data.Name == null) { return BadRequest("User wasn't created successfully"); };
            return Ok(data);
        }



        [Route("api/user/login")]
        public IHttpActionResult postTryToLogin([FromBody] UserDA user)
        {
            UserBA ub1 = new UserBA();
            UserDA data = ub1.login(user);
            if (data.Id == null) { return BadRequest("Incorrect credentials. Pls change name/password and try again"); };
            return Ok(data);
        }

    }
}
