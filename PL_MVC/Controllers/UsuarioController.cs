using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuarioBusqueda = new ML.Usuario();

            usuarioBusqueda.Nombre = "";
            usuarioBusqueda.ApellidoPaterno = "";
            usuarioBusqueda.ApellidoMaterno = "";

            var result = BL.UsuarioDireccion.GetAllUsuarioDireccion(usuarioBusqueda);

            if (result.Item1)
            {
                ML.Usuario usuario = result.Item3;
                return View(usuario);
            }
            else
            {
                ML.Usuario usuario = new ML.Usuario();
                return View();
            }

        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuarioBusquda)
        {
            usuarioBusquda.Nombre = usuarioBusquda.Nombre == null ? "" : usuarioBusquda.Nombre;
            usuarioBusquda.ApellidoPaterno = usuarioBusquda.ApellidoPaterno == null ? "" : usuarioBusquda.ApellidoPaterno;
            usuarioBusquda.ApellidoMaterno = usuarioBusquda.ApellidoMaterno == null ? "" : usuarioBusquda.ApellidoMaterno;

            var registro = BL.UsuarioDireccion.GetAllUsuarioDireccion(usuarioBusquda);
            if (registro.Item1)
            {
                return View(registro.Item3);
            }
            else
            {
                ViewBag.Text = "Ocurrio un error: " + registro.Item2;
                return PartialView("Modal");
            }

        }

        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            //var resultadoRol = BL.Usuario.GetAllRol();  //traer todo para drop down list
            //usuario.Usuarios = resultadoRol.Item3.Usuarios;

            usuario.Rol = new ML.Rol();
            //usuario.Rol.Roles = new List<object>();

            var resultadoRol = BL.Rol.GetAll();
            usuario.Rol.Roles = resultadoRol.Item3.Roles;

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            var resultadoPais = BL.Pais.GetAll();
            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultadoPais.Item3.Paises;

            //Update
            if (IdUsuario != null)
            {
                var result = BL.UsuarioDireccion.GetByIdUsuarioDireccion(IdUsuario.Value);
                usuario = result.Item3;
                if (result.Item1)
                {
                    usuario.Rol.Roles = resultadoRol.Item3.Roles;

                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultadoPais.Item3.Paises;
                    usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdColonia(usuario.Direccion.Colonia.IdColonia).Item3.Colonias;
                    usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio).Item3.Municipios;
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Item3.Estados;

                    return View(usuario);
                }
                else
                {
                    ViewBag.Text = "Ocurrio un problema" + result.Item2;
                    return PartialView("Modal");
                }

            }

            else
            //Agregar
            {
                if (resultadoRol.Item1 && resultadoPais.Item1)
                {
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultadoPais.Item3.Paises;
                    usuario.Rol.Roles = resultadoRol.Item3.Roles;
                    return View(usuario);
                }
                else
                {
                    ViewBag.Text = "Ocurrió un error" + resultadoRol.Item2;
                    return PartialView("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            HttpPostedFileBase file = Request.Files["Imagen"];
            if (file.ContentLength > 0)
            {
                usuario.Imagen = ConvertirABase64(file);
            }

            if (usuario.IdUsuario != 0)
            {
                var update = BL.UsuarioDireccion.UpdateUsuarioDireccion(usuario);
                if (update.Item1)
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
                var result = BL.UsuarioDireccion.AddUsuarioDireccion(usuario);
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
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int IdUsuario, int IdDireccion)
        {
            if (IdUsuario != 0 && IdDireccion != 0)
            {

                var result = BL.UsuarioDireccion.DeleteUsuarioDireccion(IdUsuario, IdDireccion);


                ViewBag.Text = "Se Elimino Exitosamente";
                return PartialView("Modal");

                return RedirectToAction("GetAll");
            }
            else
            {
                ViewBag.Text = "No se Elimino Exitosamente";
                return PartialView("Modal");

                //return RedirectToAction("GetAll");
            }
        }
        [HttpPost]
        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);

            if (result.Item1)
            {
                return Json(result.Item3.Estados, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result.Item2, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            var result = BL.Municipio.GetByIdMunicipio(IdEstado);
            if (result.Item1)
            {
                return Json(result.Item3.Municipios, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result.Item2, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdColonia(IdMunicipio);
            if (result.Item1)
            {
                return Json(result.Item3.Colonias, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public JsonResult CambiarEstatus(int IdUsuario, bool Status)
        {
            var result = BL.UsuarioDireccion.CambiarStatus(IdUsuario, Status);
            if (result.Item1)
            {
                return Json(result.Item1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result.Item2, JsonRequestBehavior.AllowGet);
            }
        }
    }
}