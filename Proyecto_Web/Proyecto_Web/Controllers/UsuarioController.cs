using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Proyecto_Web.Entities;
using Proyecto_Web.Models;

namespace Proyecto_Web.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioModel model = new UsuarioModel();

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ConsultarUsuarios()
        {
            var datos = model.ConsultarUsuarios();
            return View(datos);
        }
        [HttpGet]
        public ActionResult Editar(long q)
        {
            var datos = model.ConsultarUsuario(q);
            var roles = model.ConsultarRoles();
            var membresias = model.ConsultarMembresiasUsuario();

            var listaRoles = new List<SelectListItem>();
            foreach (var item in roles)
            {
                listaRoles.Add(new SelectListItem { Text = item.NombreRol, Value = item.IdRol.ToString() });
            }
            var listaMembresias = new List<SelectListItem>();
            foreach (var item in membresias)
            {
                listaMembresias.Add(new SelectListItem { Text = item.TipoMembresia, Value = item.IdMembresia.ToString() });
            }

            ViewBag.ListaRoles = listaRoles;
            ViewBag.ListaMembresias = listaMembresias;
            return View(datos);
        }

        [HttpPost]
        public ActionResult EditarUsuario(UsuarioEnt entidad)
        {
            var resp = model.EditarUsuario(entidad);

            if (resp > 0)
                return RedirectToAction("ConsultarUsuarios", "Usuario");
            else
            {
                ViewBag.MsjPantalla = "No se ha podido actualizar la información del usuario";
                return View("Editar");
            }
        }
    }
}
