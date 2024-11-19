using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class OperacionesController : ApiController
    {
        [HttpPost]
        [Route("api/Hola")]
        public IHttpActionResult HolaMundo(string Nombre)
        {
            string saludo = "Hola " + Nombre;
            //regresa un JSON y el status code, codigo de estado HTTP
            return Content(HttpStatusCode.OK, saludo);
        }

        [HttpPost]
        [Route("api/Suma")]
        public IHttpActionResult Suma(int a, int b)
        {
            var suma = "La Suma es: " + (a + b);
            //regresa un JSON y el status code, codigo de estado HTTP
            if (suma != null)
            {
                return Content(HttpStatusCode.OK, suma);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, suma);
            }
        }

        [HttpPost]
        [Route("api/Resta")]
        public IHttpActionResult Resta(int a, int b)
        {
            string resta = "La Resta es: " + (a - b);
            //regresa un JSON y el status code, codigo de estado HTTP
            return Content(HttpStatusCode.OK, resta);
        }

        [HttpPost]
        [Route("api/Multiplicacion")]
        public IHttpActionResult Multiplicacion(int a, int b)
        {
            string multiplicacion = "La Multiplicacion es: " + (a * b);
            //regresa un JSON y el status code, codigo de estado HTTP
            return Content(HttpStatusCode.OK, multiplicacion);
        }

        [HttpPost]
        [Route("api/Division")]
        public IHttpActionResult Division(int a, int b)
        {
            string division = "La Division es: " + (a / b);
            //regresa un JSON y el status code, codigo de estado HTTP
            return Content(HttpStatusCode.OK, division);
        }

        [HttpPost]
        [Route("api/subcategoria/Add")]

        // POST api/subcategoria
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
