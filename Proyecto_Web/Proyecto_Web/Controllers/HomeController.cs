using Proyecto_Web.Entities;
using Proyecto_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Web.Controllers
{
    public class HomeController : Controller
    {
        UsuarioModel model = new UsuarioModel();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(UsuarioEnt entidad)
        {
            try
            {
                var resp = model.IniciarSesion(entidad);

                if (resp != null)
                {
                    Session["IdSesion"] = resp.IdUsuario.ToString();
                    Session["CorreoSesion"] = resp.CorreoElectronico;
                    Session["NombreSesion"] = resp.Nombre;
                    Session["RolSesion"] = resp.NombreRol;
                    Session["IdRolSesion"] = resp.IdRol;
                    Session["MembresiaSesion"] = resp.TipoMembresia;
                    Session["IdMembresiaSesion"] = resp.IdMembresia;

                    return RedirectToAction("ConsultarUsuarios", "Usuario");
                }
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido validar su información";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.MsjPantalla = "Consulta con el administrador del sistema";
                return View("Index");
            }
        }



        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(UsuarioEnt entidad)
        {
            entidad.IdRol = 2;
            entidad.IdMembresia = 1;

            var resp = model.Registrarse(entidad);

            if (resp > 0)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.MsjPantalla = "No se ha podido registrar su información";
                return View("Registro");
            }
        }



    }
}