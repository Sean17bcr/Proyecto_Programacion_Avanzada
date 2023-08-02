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
    public class EquipoController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarEquipo")]
        public int AgregarEquipo(EquipoEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return 0;
            }
        }

        [HttpDelete]
        [Route("api/EliminarEquipo")]
        public EquipoEnt EliminarEquipo(EquipoEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return entidad;
            }

        }

        [HttpPut]
        [Route("api/EditarEquipo")]
        public int EditarEquipo(EquipoEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return 0;
            }
        }
    }
}
