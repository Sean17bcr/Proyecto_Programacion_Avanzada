using Api_ProyectoWeb.Entities;
using Api_ProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_ProyectoWeb.Controllers
{
    public class RegistroAccesoController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarRegistroAcceso")]
        public int AgregarRegistroAcceso(RegistroAccesoEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return 0;
            }
        }

        [HttpDelete]
        [Route("api/EliminarRegistroAcceso")]
        public RegistroAccesoEnt EliminarRegistroAcceso(RegistroAccesoEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return entidad;
            }

        }

        [HttpPut]
        [Route("api/EditarRegistroAcceso")]
        public int EditarRegistroAcceso(RegistroAccesoEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return 0;
            }
        }
    }
}
