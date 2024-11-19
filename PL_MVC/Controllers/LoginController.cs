using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var result = BL.UsuarioLogin.LoginEmail(email);

            if (result.Item1 == true)
            {
                if (result.Item3.Password == password)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Text = "Contraseña incorrecta";
                    return PartialView("Model");
                }
            }
            else
            {
                ViewBag.Text = "El Correo esta incorrecto";
                return PartialView("Model");
            }

            return View();
        }
    }
}