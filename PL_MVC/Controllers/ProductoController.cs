using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ML;
using PL_MVC.DTO;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult GetAll()
        {
            //ML.Producto productoBusqueda = new ML.Producto(); sin la api

            //productoBusqueda.Nombre = "";sin la api

            //var result = BL.Producto.GetAllEF(productoBusqueda); sin la api

            ///API Rest
            /*using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60605/");

                var responseTask = client.GetAsync("api/Producto/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    //ML.Producto producto = result.Item3; sin la api
                    //return View(producto); sin la api
                    //ML.Producto producto1 = new List<ML.Producto>(); sin la api
                    var readTask = result.Content.ReadAsAsync<ApiResponse<ML.Producto>>();
                    readTask.Wait();

                    if (readTask.Result.Success)
                    {
                        ML.Producto producto = readTask.Result.Data;
                        return View(producto);
                    }
                    else
                    {
                        ML.Producto producto = new ML.Producto();
                        return View(producto);
                    }
                }
                else
                {
                    ML.Producto producto = new ML.Producto();
                    return View();
                }
            }*/
            ServiceReferenceProducto.ServiceProductoClient client = new ServiceReferenceProducto.ServiceProductoClient();

            var result = client.GetAll();
            if (result.Item1 == true)
            {
                ML.Producto producto = new ML.Producto();
                producto.Productos = new List<ML.Producto>();

                foreach (ML.Producto p in result.Item3)
                {
                    producto.Productos.Add(p);
                }
                return View(producto);
            }
            else
            {
                return View("Modal");
            }
        }
        //metodo para la busqueda sin la api
        //[HttpPost]
        //public ActionResult GetAll(ML.Producto productoBusqueda)
        //{
        //    productoBusqueda.Nombre = productoBusqueda.Nombre == null ? "" : productoBusqueda.Nombre;

        //    var registro = BL.Producto.GetAllEF(productoBusqueda);
        //    if (registro.Item1)
        //    {
        //        return View(registro.Item3);
        //    }
        //    else
        //    {
        //        ViewBag.Text = "Ocurrio un error: " + registro.Item2;
        //        return PartialView("Modal");
        //    }
        //}

        [HttpPost]
        public ActionResult GetAll(ML.Producto productoBusqueda)
        {
            //productoBusqueda.Nombre = productoBusqueda.Nombre == null ? "" : productoBusqueda.Nombre;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60605/api/");
                var responseTask = client.GetAsync("Producto/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;
                //var registro = BL.Producto.GetAllEF(productoBusqueda);
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<(bool, string, ML.Producto, Exception)>();
                    readTask.Wait();

                    if (readTask.Result.Item1 == true)
                    {
                        ML.Producto producto = readTask.Result.Item3;
                        return View(producto);
                    }

                    else
                    {
                        ViewBag.Text = "Ocurrio un error: " + readTask.Result.Item2;
                        return PartialView("Modal");
                    }
                }
                else
                {
                    ViewBag.Text = "Ocurrio un error: ";
                    return PartialView("Modal");
                }
            }
        }

        //public ActionResult Form(int? IdProducto)
        //{
        //    ML.Producto producto = new ML.Producto();

        //    producto.Proveedor = new ML.Proveedor();
        //    producto.Departamento = new ML.Departamento();
        //    producto.Departamento.Area = new ML.Area();

        //    var resultadoArea = BL.Area.GetAllArea();
        //    producto.Departamento.Area.Areas = resultadoArea.Item3.Areas;

        //    var resultadoProveedor = BL.Proveedor.GetAllProveedor();
        //    producto.Proveedor.Proveedores = resultadoProveedor.Item3.Proveedores;

        //    if (IdProducto != null)
        //    {
        //        var result = BL.Producto.GetByIdLINQ(IdProducto.Value);
        //        producto = result.Item3;
        //        if (result.Item1)
        //        {
        //            producto.Departamento.Area.Areas = resultadoArea.Item3.Areas;
        //            producto.Proveedor.Proveedores = resultadoProveedor.Item3.Proveedores;
        //            producto.Departamento.Departamentos = BL.Departamento.GetByIdArea(producto.Departamento.Area.IdArea).Item3.Departamentos;


        //            return View(producto);
        //        }
        //        else
        //        {
        //            ViewBag.Text = "Ocurrio un error" + result.Item2;

        //            return PartialView("Modal");
        //        }
        //    }
        //    else
        //    {
        //        if (resultadoProveedor.Item1 && resultadoArea.Item1)
        //        {
        //            producto.Departamento.Area.Areas = resultadoArea.Item3.Areas;
        //            producto.Proveedor.Proveedores = resultadoProveedor.Item3.Proveedores;

        //            return View(producto);
        //        }
        //        else
        //        {
        //            ViewBag.Text = "Ocurrió un error" + resultadoArea.Item2;
        //            return PartialView("Modal");
        //        }
        //    }
        //}
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            producto.Proveedor = new ML.Proveedor();
            producto.Departamento = new ML.Departamento();
            producto.Departamento.Area = new ML.Area();

            var resultadoArea = BL.Area.GetAllArea();
            producto.Departamento.Area.Areas = resultadoArea.Item3.Areas;

            var resultadoProveedor = BL.Proveedor.GetAllProveedor();
            producto.Proveedor.Proveedores = resultadoProveedor.Item3.Proveedores;

            if (IdProducto != null)
            {
                //var result = client.GetById(IdProducto.Value);
                ServiceReferenceProducto.ServiceProductoClient client = new ServiceReferenceProducto.ServiceProductoClient();
                var result = BL.Producto.GetByIdLINQ(IdProducto.Value);

                producto = result.Item3;
                if (result.Item1)//200 - 299
                {

                    producto.Departamento.Area.Areas = resultadoArea.Item3.Areas;
                    producto.Proveedor.Proveedores = resultadoProveedor.Item3.Proveedores;
                    producto.Departamento.Departamentos = BL.Departamento.GetByIdArea(producto.Departamento.Area.IdArea).Item3.Departamentos;


                    return View(producto);
                }
                else
                {
                    ViewBag.Text = "Ocurrio un error" + result;

                    return PartialView("Modal");
                }
            }
            else
            {
                if (resultadoProveedor.Item1 && resultadoArea.Item1)
                {
                    producto.Departamento.Area.Areas = resultadoArea.Item3.Areas;
                    producto.Proveedor.Proveedores = resultadoProveedor.Item3.Proveedores;

                    return View(producto);
                }
                else
                {
                    ViewBag.Text = "Ocurrió un error" + resultadoArea.Item2;
                    return PartialView("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            HttpPostedFileBase file = Request.Files["Imagen"];
            if (file.ContentLength > 0)
            {
                producto.Imagen = ConvertirABase64(file);
            }
            if (producto.IdProducto != 0)
            {
                ///Sin Api REST
                //var update = BL.Producto.UpdateEF(producto);
                //if (update.Item1)
                //{
                //    ViewBag.Text = "El Registro se ha Actualizado Exitosamente";
                //    return PartialView("Modal");
                //}
                //else
                //{
                //    ViewBag.Text = "Ocurrio un Error: El Registro No se Guardo Exitosamente";
                //    return PartialView("Modal");
                //}
                ///Fin Sin ApiRest

                ///API REST
                //using (HttpClient client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri("http://localhost:60605/");

                //    var responseTask = client.PutAsJsonAsync<ML.Producto>("api/Producto/Update", producto);
                //    responseTask.Wait();

                //    var result = responseTask.Result;
                //    //var update = BL.Producto.UpdateEF(producto);
                //    if (result.IsSuccessStatusCode)
                //    {
                //        ViewBag.Text = "El Registro se ha Actualizado Exitosamente";
                //        return PartialView("Modal");
                //    }
                //    else
                //    {
                //        ViewBag.Text = "Ocurrio un Error: El Registro No se Guardo Exitosamente";
                //        return PartialView("Modal");
                //    }
                //}
                ///Fin API REST
                ServiceReferenceProducto.ServiceProductoClient client = new ServiceReferenceProducto.ServiceProductoClient();

                var result = client.Update(producto);
                if (result.Item1)
                {
                    ViewBag.Text = "El Registro se ha Actualizado Exitosamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Text = "Ocurrio un Error: El Registro No se Guardo Exitosamente";
                    return PartialView("Modal");
                }
            }
            else
            {
                //var result = BL.Producto.AddEF(producto);

                //if (result.Item1)
                //{
                //    ViewBag.Text = "Se Agrego Exitosamente";
                //    return PartialView("Modal");
                //}
                //else
                //{
                //    ViewBag.Text = "No Se Agrego Exitosamente";
                //    return PartialView("Modal");
                //}

                ///APIREST
                //using (HttpClient client = new HttpClient())
                //{

                //    client.BaseAddress = new Uri("http://localhost:60605/");

                //    var responseTask = client.PostAsJsonAsync<ML.Producto>("api/Producto/Add", producto);
                //    responseTask.Wait();

                //    var result = responseTask.Result;


                //    if (result.IsSuccessStatusCode)
                //    {

                //        //dynamic tupla = Newtonsoft.Json.JsonConvert.DeserializeObject(result.ToString());
                //        //bool resultado = tupla.Item1;

                //        ViewBag.Text = "Se Agrego Exitosamente";
                //        return PartialView("Modal");
                //    }
                //    else
                //    {
                //        ViewBag.Text = "No Se Agrego Exitosamente";
                //        return PartialView("Modal");
                //    }
                //}
                ///FIN APIREST///
                ServiceReferenceProducto.ServiceProductoClient client = new ServiceReferenceProducto.ServiceProductoClient();

                var result = client.Add(producto);
                if (result.Item1)
                {
                    ViewBag.Text = "Se Agrego Exitosamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Text = "No Se Agrego Exitosamente";
                    return PartialView("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int IdProducto)
        {
            if (IdProducto != 0)
            {
                ///API RESt
                //using (HttpClient client = new HttpClient())
                //{

                //    client.BaseAddress = new Uri("http://localhost:60605/");

                //    var responseTask = client.DeleteAsync("api/Producto/Delete?IdProducto=" + IdProducto);
                //    responseTask.Wait();
                //    var result = responseTask.Result;
                //    //var result = BL.Producto.DeleteLINQ(IdProducto);

                //    if (result.IsSuccessStatusCode)
                //    {
                //        ViewBag.Text = "Se Elimino Exitosamente";
                //        return PartialView("Modal");

                //    }
                //    else
                //    {
                //        ViewBag.Text = "No se Elimino Exitosamente";
                //        return PartialView("Modal");
                //    }
                //}
                ///FIN API REST
                ///
                ServiceReferenceProducto.ServiceProductoClient client = new ServiceReferenceProducto.ServiceProductoClient();

                var result = client.Delete(IdProducto);

                if (result.Item1 == true)
                {
                    //var result = BL.Producto.DeleteLINQ(IdProducto);

                    ViewBag.Text = "Se Elimino Exitosamente";
                    return PartialView("Modal");

                }
                else
                {
                    ViewBag.Text = "No se Elimino Exitosamente";
                    return PartialView("Modal");

                }
            }
            else
            {
                ViewBag.Text = "No se Elimino Exitosamente";
                return PartialView("Modal");
            }
        }

        [HttpPost]
        public JsonResult DepartamentosGetByIdArea(int IdArea)
        {
            var result = BL.Departamento.GetByIdArea(IdArea);

            if (result.Item1)
            {
                return Json(result.Item3.Departamentos, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result.Item2, JsonRequestBehavior.AllowGet);
            }
        }
        public string ConvertirABase64(HttpPostedFileBase Imagen)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            byte[] data = reader.ReadBytes((int)Imagen.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;

        }
    }
}
