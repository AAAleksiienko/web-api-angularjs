using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Web_Api_AngularJs.Business_Layer;
using Web_Api_AngularJs.Data_Access_Layer;

namespace Web_Api_AngularJs.Controllers
{
    public class ProductController : ApiController
    {

        [Authorize]
        public IHttpActionResult Get()
        {
            ProductBA pm = new ProductBA();
            IEnumerable<ProductDA> data = pm.findAll();

            if (data.Count() < 1)
            {
                // return BadRequest("Products weren't found");
            }

            return Ok(data);
        }

        public IHttpActionResult Get(int id)
        {
            ProductBA pm = new ProductBA();
            ProductDA data = pm.findProduct(id);

            if (data.Id == null)
            {
                //return BadRequest("Product wasn't found"); 

                IHttpActionResult response;
                response = ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with id: " + id + " does't exist"));
                return response;
            }

            return Ok(data);
        }

        public IHttpActionResult Delete(int id)
        {
            ProductBA pm = new ProductBA();
            pm.deleteProduct(id);

            return Ok("Product was deleted successfully");
        }

        public IHttpActionResult postProduct([FromBody] ProductDA product)
        {
            ProductBA pm = new ProductBA();
            ProductDA data = pm.addProduct(product);

            return Ok("Product was created successfully");
        }

        public IHttpActionResult Put(string id, [FromBody] ProductDA product)
        {
            ProductBA pm = new ProductBA();
            ProductDA data = pm.changeProduct(id, product);
            if (data.Id == null) { return BadRequest("Product wasn't changed"); }
            return Ok(data);
        }


    }
}