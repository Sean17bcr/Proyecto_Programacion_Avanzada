using Proyecto_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Web.Entities;


namespace Proyecto_Web.Controllers
{
    public class MembresiaController : Controller
    {

        MembresiaModel model = new MembresiaModel();

        [HttpGet]
        public ActionResult EliminarMembresia(long q)
        {
            var resp = model.EliminarMembresia(q);

            var datos = model.ConsultarMembresia(long.Parse(Session["IdSesion"].ToString()));

            if (resp > 0)
            {
                return RedirectToAction("ConsultarMembresias", "Membresia");
            }
            else
            {
                ViewBag.MsjPantalla = "La membresia no se pudo eliminar";
                return View("ConsultarMembresias");
            }
        }
        public ActionResult ConsultarMembresias()
        {
            var datos = model.ConsultarMembresias();
            return View(datos);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegistrarMembresia(MembresiaEnt entidad)
        {
            var resp = model.RegistrarMembresia(entidad);

            if (resp > 0)
                return RedirectToAction("ConsultarMembresias", "Membresia");
            else
            {
                ViewBag.MsjPantalla = "No se ha podido registrar su información";
                return View("RegistrarMembresia");
            }
        }

        [HttpGet]
        public ActionResult Editar(long q)
        {
            var datos = model.ConsultarMembresia(q);
            return View(datos);
        }

        [HttpPost]
        public ActionResult EditarMembresia(MembresiaEnt entidad)
        {
            model.ActualizarMembresia(entidad);
            return RedirectToAction("ConsultarMembresias", "Membresia");
        }

    }
}