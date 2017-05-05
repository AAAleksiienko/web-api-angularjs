using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web_api_components.Models;
using web_api_components.ErrorHandlers;
using web_api_components.DTO;

namespace web_api_components.Controllers
{
    public class ProductController : ApiController
    {

        public IHttpActionResult Get()
        {
            ProductBALayer pm = new ProductBALayer();
            IEnumerable<ProductDTO> data = pm.findAll();

            if (data.Count() < 1) {
                // return BadRequest("Products weren't found");
            }
   
            return Ok(data);
        }

        public IHttpActionResult Get(int id)
        {
            ProductBALayer pm = new ProductBALayer();
            ProductDTO data = pm.findProduct(id);

            if (data.Id == null) { return BadRequest("Product wasn't found"); }

            return Ok(data);
        }

        public IHttpActionResult Delete(int id)
        {
            ProductBALayer pm = new ProductBALayer();
            pm.deleteProduct(id);

            return Ok("Product was deleted successfully");
        }

        public IHttpActionResult postProduct([FromBody] ProductDTO product)
        {
            ProductBALayer pm = new ProductBALayer();
            ProductDTO data = pm.addProduct(product);
            
            return Ok("Product was created successfully");
        }

        public IHttpActionResult Put(string id, [FromBody] ProductDTO product)
        {
            ProductBALayer pm = new ProductBALayer();
            ProductDTO data = pm.changeProduct(id, product);
            if(data.Id == null) { return BadRequest("Product wasn't changed"); }
            return Ok(data);
        }

    }
}
