using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpPost]
        [Route("api/Producto/Add")]
        public IHttpActionResult Add([FromBody] ML.Producto producto)
        {
            var result = BL.Producto.AddEF(producto);
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [HttpPut]
        [Route("api/Producto/Update")]
        public IHttpActionResult Update([FromBody] ML.Producto producto)
        {
            var result = BL.Producto.UpdateEF(producto);
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.Item2);
            }
        }
        [HttpDelete]
        [Route("api/Producto/Delete")]
        public IHttpActionResult Delete(int IdProducto)
        {
            var result = BL.Producto.DeleteLINQ(IdProducto);
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [HttpGet]
        [Route("api/Producto/GetById")]
        public IHttpActionResult GetById(int IdProducto)
        {
            var result = BL.Producto.GetByIdLINQ(IdProducto);
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [HttpGet]
        [Route("api/Producto/GetAll")]
        public IHttpActionResult GetAll()
        {
            var result = BL.Producto.GetAllEFSB();

            var response = new ApiResponse<ML.Producto>
            {
                Success = result.Item1,
                Message = result.Item2,
                Data = result.Item3,
                Exception = result.Item4
            };

            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, response);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, response);
            }
        }

        [HttpPost]
        [Route("api/Producto1/Add")]
        public IHttpActionResult Post([FromBody] ML.Producto producto)
        {

            var result = BL.Producto.AddEF(producto);

            if (result.Item1)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
