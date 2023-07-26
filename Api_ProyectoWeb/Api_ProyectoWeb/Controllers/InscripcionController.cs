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
    public class InscripcionController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarInscripcion")]
        public int AgregarInscripcion(InscripcionEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return 0;
            }
        }

        [HttpDelete]
        [Route("api/EliminarInscripcion")]
        public InscripcionEnt EliminarInscripcion(InscripcionEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return entidad;
            }

        }

        [HttpPut]
        [Route("api/EditarInscripcion")]
        public int EditarInscripcion(InscripcionEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return 0;
            }
        }
    }
}
