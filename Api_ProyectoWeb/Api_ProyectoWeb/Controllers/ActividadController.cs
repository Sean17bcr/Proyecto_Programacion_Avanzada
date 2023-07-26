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
    public class ActividadController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarActividad")]
        public int AgregarActividad(ActividadEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return 0;
            }
        }

        [HttpDelete]
        [Route("api/EliminarActividad")]
        public ActividadEnt EliminarActividad(ActividadEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return entidad;
            }

        }

        [HttpPut]
        [Route("api/EditarActividad")]
        public int EditarActividad(ActividadEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return 0;
            }
        }

    }
}
