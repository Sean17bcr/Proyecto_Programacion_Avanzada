using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Web.Controllers
{
    public class HomeController : Controller
    {

        /*Abre la pantalla de inicio de sesion*/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /*Abre la pantalla de Registro*/
        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        /*Abre la pantalla Principal del sistema*/
        [HttpGet]
        public ActionResult Principal()
        {

            return View();
        }

        /*Se redirige a la pantalla principall *Debe llevar programacion para autenticar valores* */
        [HttpPost]
        public ActionResult IniciarSesion()
        {
            /*Programacion*/
            return RedirectToAction("Principal", "Home");
        }

        /*Se redirige a la pantalla principall *Debe llevar programacion para autenticar valores* */
        [HttpPost]
        public ActionResult Registrarse()
        {
            /*Programacion*/
            return RedirectToAction("Index", "Home");
        }


    }
}