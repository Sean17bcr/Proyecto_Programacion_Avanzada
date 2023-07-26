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
    public class InstructorController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarInstructor")]
        public int AgregarInstructor(InstructorEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return 0;
            }
        }

        [HttpDelete]
        [Route("api/EliminarInstructor")]
        public InstructorEnt EliminarInstructor(InstructorEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return entidad;
            }

        }

        [HttpPut]
        [Route("api/EditarInstructor")]
        public int EditarInstructor(InstructorEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return 0;
            }
        }
    }
}
