using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult GetAllDepa()
        {
            var result = BL.Departamento1.GetAllLINQ();

            if (result.Item1)
            {
                ML.Departamento departamento = result.Item3;
                return View(departamento);
            }
            else
            {
                ML.Departamento departamento = new ML.Departamento();
                return View();
            }
        }
        public ActionResult FormDepa(int? IdDepartamento)
        {
            ML.Departamento departamento = new ML.Departamento();

            departamento.Area = new ML.Area();

            var resultadoArea = BL.Area.GetAllArea();
            departamento.Area.Areas = resultadoArea.Item3.Areas;

            if (IdDepartamento != null)
            {
                var result = BL.Departamento1.GetByIdEF(IdDepartamento.Value);
                departamento = result.Item3;
                if (result.Item1)
                {
                    departamento.Area.Areas = resultadoArea.Item3.Areas;

                    return View(departamento);
                }
                else
                {
                    ViewBag.Text = "Ocurrio un problema" + result.Item2;
                    return PartialView("Modal");
                }
            }
            else
            {
                if (resultadoArea.Item1)
                {
                    departamento.Area.Areas = resultadoArea.Item3.Areas;
                    return View(departamento);
                }
                else
                {
                    ViewBag.Text = "Ocurrió un error" + resultadoArea.Item2;
                    return PartialView("Modal");
                }
            }
        }
        [HttpPost]
        public ActionResult FormDepa(ML.Departamento departamento)
        {
            if (departamento.IdDepartamento != 0)
            {
                var update = BL.Departamento1.UpdateEF(departamento);
                if (update.Item1)
                {
                    ViewBag.Text = "El Registro se ha Actualizado Exitosamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Text = "Ocurrio un Error: El Registro No se Actualizo Exitosamente";
                    return PartialView("Modal");
                }
            }
            else
            {
                var result = BL.Departamento1.AddSqlClient(departamento);

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
        public ActionResult Delete(int IdDepartamento)
        {
            if (IdDepartamento != 0)
            {
                
                var result = BL.Departamento1.DeleteSqlClient(IdDepartamento);


                ViewBag.Text = "Se Elimino Exitosamente";
                return PartialView("Modal");

                return RedirectToAction("GetAllDepa");
            }
            else
            {
                ViewBag.Text = "No se Elimino Exitosamente";
                return PartialView("Modal");

                return RedirectToAction("GetAllDepa");
            }
        }

    }
}