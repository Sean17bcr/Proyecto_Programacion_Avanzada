using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api_ProyectoWeb.Controllers
{
    public class HomeController : Controller
    {
        /*Test GitHub*/
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
