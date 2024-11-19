using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        public ActionResult Get()
        {
            ML.ResultExcel errores = new ML.ResultExcel();
            errores.Errores = new List<ML.ResultExcel>();
            return View(errores.Errores);
            //if (Session["PathArchivo"] == null)
            //{
            //    return View(new ML.ResultExcel());
            //}
            //else
            //{
            //    /// esta validacion para que la tienes ??
            //    ML.ResultExcel resultExcel = (ML.ResultExcel)Session["PathArchivo"];
            //    return View(resultExcel);
            //}
        }

        [HttpPost]
        public ActionResult CargaMasivaTxt()
        {
            HttpPostedFileBase file = Request.Files["ArchivoTxt"];

            if (file == null)
            {
                if (file.ContentLength > 0)
                {
                    //OLEDB o ODBC Proveedores de ADO.NET
                    string extension = Path.GetExtension(file.FileName).ToLower();//extensiones del archivo

                    if (extension == ".txt")//valida si la extension es igual a la de excel
                    {
                        string pathFolder = "~/CargaMasiva/";//se pasa la ruta de la carpeta que se creo en el pl_mvc parade ahi jalar la copia del archivo

                        string pathArchivo = Server.MapPath(pathFolder) + Path.GetFileNameWithoutExtension(file.FileName) + "-" +
                        DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";

                        if (!System.IO.File.Exists(pathArchivo))//revisar que la ruta del archivo exista
                        {
                            file.SaveAs(pathArchivo);

                            //BL
                            //se trae toda la logica de nogocio, se manda a traer el metodo!!!

                            BL.Producto.CargaMasivaTxt(pathArchivo);
                            return PartialView("Modal");
                        }
                    }
                    else
                    {
                        //message error
                        //regresar la vista
                    }


                }
                else
                {
                    //mensaje error
                }
            }
            else
            {

            }
            return PartialView("Modal");
        }

        [HttpPost]
        public ActionResult Get(int? dato)
        {
            if (Session["PathArchivo"] == null)
            {

                HttpPostedFileBase file = Request.Files["ArchivoExcel"];
                string pathFolder = ConfigurationManager.AppSettings["pathFolder"].ToString();

                if (file.ContentLength > 0)
                {
                    //OLEDB o ODBC Proveedores de ADO.NET
                    string extensionArchivo = Path.GetExtension(file.FileName).ToLower();//extensiones del archivo
                    string extensionModulo = ConfigurationManager.AppSettings["TipoExcel"].ToString();

                    if (extensionArchivo == extensionModulo)//valida si la extension es igual a la de excel
                    {
                        //string pathFolder = "~/CargaMasiva/";//se pasa la ruta de la carpeta que se creo en el pl_mvc para de ahi jalar la copia del archivo

                        string pathArchivo = Server.MapPath(pathFolder) + Path.GetFileNameWithoutExtension(file.FileName) + '-' + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xlsx";

                        if (!System.IO.File.Exists(pathArchivo))//revisar que la ruta del archivo exista
                        {
                            file.SaveAs(pathArchivo);
                            //pasamos toda la cadena de conexion
                            string connectionString = ConfigurationManager.AppSettings["ConnectionStringExcel"].ToString() + pathArchivo;

                            //BL
                            //se trae toda la logica de nogocio se manda a traer el metodo!!!
                            var resultProducto = BL.Producto.CargaMasivaExcel(connectionString);

                            if (resultProducto.Item1)
                            {
                                var resultValidar = BL.Producto.ValidarDatos(resultProducto.Item3);
                                if (resultValidar.Item2.Errores.Count == 0)
                                {
                                    Session["PathArchivo"] = pathArchivo;

                                    return View();
                                    //return View(resultValidar.Item2.Errores);
                                }
                                return View(resultValidar);
                            }
                            else
                            {
                                ViewBag.Mensaje = "El excel no contiene registros";
                                return PartialView("Modal");
                            }
                        }
                    }
                    else
                    {
                        //message error
                        //regresar la vista
                        ViewBag.Mensaje = "Favor de seleccionar un archivo .xlsx, Verifique su archivo";
                        return PartialView("Modal");
                    }
                }
                else
                {
                    //mensaje error
                    ViewBag.Mensaje = "No selecciono ningun archivo, Seleccione uno correctamente";
                    return PartialView("Modal");
                }
                return View();
            }
            else
            {
                string pathArchivo = Session["PathArchivo"].ToString();
                string connectionString = ConfigurationManager.AppSettings["ConnectionStringExcel"].ToString() + pathArchivo;

                var datos = BL.Producto.CargaMasivaExcel(connectionString);

                if (datos.Item1)
                {
                    foreach (ML.Producto producto in datos.Item3)
                    {
                        BL.Producto.AddEF(producto);
                    }
                }

                ViewBag.Mensaje = "Se realizo la carga de manera correcta";
                Session["PathArchivo"] = null;
                return PartialView("Modal");
            }
        }
    }
}