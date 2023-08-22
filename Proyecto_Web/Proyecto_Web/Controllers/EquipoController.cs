using System;
using System.Web.Mvc;
using Proyecto_Web.Entities;
using Proyecto_Web.Models;

namespace Proyecto_Web.Controllers
{
    public class EquipoController : Controller
    {
        EquipoModel model = new EquipoModel();

        [HttpGet]
        public ActionResult EliminarEquipo(long q)
        {
            var resp = model.EliminarEquipo(q);

            var datos = model.ConsultarEquipo(long.Parse(Session["IdSesion"].ToString()));

            if (resp > 0)
            {
                return RedirectToAction("ConsultarEquipos", "Equipo");
            }
            else
            {
                ViewBag.MsjPantalla = "El equipo no se pudo eliminar";
                return View("ConsultarEquipos");
            }
        }
        public ActionResult ConsultarEquipos()
        {
            var datos = model.ConsultarEquipos();
            return View(datos);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegistrarEquipo(EquipoEnt entidad)
        {
            var resp = model.RegistrarEquipo(entidad);

            if (resp > 0)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.MsjPantalla = "No se ha podido registrar su información";
                return View("RegistrarEquipo");
            }
        }

        [HttpGet]
        public ActionResult Editar(long q)
        {
            var datos = model.ConsultarEquipo(q);
            return View(datos);
        }

        [HttpPost]
        public ActionResult EditarEquipo(EquipoEnt entidad)
        {
            model.ActualizarEquipo(entidad);
            return RedirectToAction("ConsultarEquipos", "Equipo");
        }
    }
}

