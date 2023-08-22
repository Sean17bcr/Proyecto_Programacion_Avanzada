using System;
using System.Web.Mvc;
using Proyecto_Web.Entities;
using Proyecto_Web.Models;

namespace Proyecto_Web.Controllers
{
    public class RutinaController : Controller
    {
        RutinaModel model = new RutinaModel();

        [HttpGet]
        public ActionResult EliminarRutina(long q)
        {
            var resp = model.EliminarRutina(q);

            var datos = model.ConsultarRutina(long.Parse(Session["IdSesion"].ToString()));

            if (resp > 0)
            {
                return RedirectToAction("ConsultarRutinas", "Rutina");
            }
            else
            {
                ViewBag.MsjPantalla = "La rutina no se pudo eliminar";
                return View("ConsultarRutinas");
            }
        }
        public ActionResult ConsultarRutinas()
        {
            var datos = model.ConsultarRutinas();
            return View(datos);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegistrarRutina(RutinaEnt entidad)
        {
            var resp = model.RegistrarRutina(entidad);

            if (resp > 0)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.MsjPantalla = "No se ha podido registrar su información";
                return View("RegistrarRutina");
            }
        }

        [HttpGet]
        public ActionResult Editar(long q)
        {
            var datos = model.ConsultarRutina(q);
            return View(datos);
        }

        [HttpPost]
        public ActionResult EditarRutina(RutinaEnt entidad)
        {
            model.ActualizarRutina(entidad);
            return RedirectToAction("ConsultarRutinas", "Rutina");
        }
    }
}
