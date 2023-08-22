using System;
using System.Web.Mvc;
using Proyecto_Web.Entities;
using Proyecto_Web.Models;

namespace Proyecto_Web.Controllers
{
    public class ClaseController : Controller
    {
        ClaseModel model = new ClaseModel();


        [HttpGet]
        public ActionResult EliminarClase(long q)
        {
            var resp = model.EliminarClase(q);

            var datos = model.ConsultarClase(long.Parse(Session["IdSesion"].ToString()));

            if (resp > 0)
            {
                return RedirectToAction("ConsultarClases", "Clase");
            }
            else
            {
                ViewBag.MsjPantalla = "La clase no se pudo eliminar";
                return View("ConsultarClases");
            }
        }
        public ActionResult ConsultarClases()
        {
            var datos = model.ConsultarClases();
            return View(datos);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegistrarClase(ClaseEnt entidad)
        {
            var resp = model.RegistrarClase(entidad);

            if (resp > 0)
                return RedirectToAction("ConsultarClases", "Clase");
            else
            {
                ViewBag.MsjPantalla = "No se ha podido registrar su información";
                return View("ConsultarClases");
            }
        }

        [HttpGet]
        public ActionResult Editar(long q)
        {
            var datos = model.ConsultarClase(q);
            return View(datos);
        }

        [HttpPost]
        public ActionResult EditarClase(ClaseEnt entidad)
        {
            model.ActualizarClase(entidad);
            return RedirectToAction("ConsultarClases", "Clase");
        }
    }
}
