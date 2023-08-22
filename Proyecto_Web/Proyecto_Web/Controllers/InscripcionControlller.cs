
using Proyecto_Web.Entities;
using Proyecto_Web.Models;
using System;
using System.Web.Mvc;

namespace Proyecto_Web.Controllers
{
    public class InscripcionController : Controller
    {
        private InscripcionModel model = new InscripcionModel();

        public ActionResult GestionInscripciones()
        {
            var inscripciones = model.VerInscripciones();
            return View(inscripciones);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(InscripcionEnt inscripcion)
        {
            if (ModelState.IsValid)
            {
                var result = model.AgregarInscripcion(inscripcion);
                if (result > 0)
                {
                    return RedirectToAction("GestionInscripciones");
                }
            }
            return View(inscripcion);
        }

        public ActionResult Editar(int id)
        {
            var inscripcion = model.ConsultarInscripcion(id);
            if (inscripcion != null)
            {
                return View(inscripcion);
            }
            return RedirectToAction("GestionInscripciones");
        }

        [HttpPost]
        public ActionResult Editar(InscripcionEnt inscripcion)
        {
            if (ModelState.IsValid)
            {
                // Aquí omitimos la edición de IdUsuario
                inscripcion.IdUsuario = 0;

                var result = model.EditarInscripcion(inscripcion);
                if (result > 0)
                {
                    return RedirectToAction("GestionInscripciones");
                }
            }
            return View(inscripcion);
        }

        public ActionResult Eliminar(int id)
        {
            var inscripcion = model.ConsultarInscripcion(id);
            if (inscripcion != null)
            {
                return View(inscripcion);
            }
            return RedirectToAction("GestionInscripciones");
        }

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection form)
        {
            var result = model.EliminarInscripcion(id);
            if (result > 0)
            {
                return RedirectToAction("GestionInscripciones");
            }
            return RedirectToAction("GestionInscripciones");
        }
    }
}

