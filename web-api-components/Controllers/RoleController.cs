using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using web_api_components.Models;
using web_api_components.ErrorHandlers;
using web_api_components.DTO;

namespace web_api_components.Controllers
{
    public class RoleController : ApiController
    {
    
        public IHttpActionResult Get()
        {
            RoleBALayer rb = new RoleBALayer();
            IEnumerable<RoleDTO> data = rb.findAll().AsEnumerable();
        
            if(data.Count() < 1) { return BadRequest("Roles don't exist"); };
            return Ok(data);
        }
    }
}