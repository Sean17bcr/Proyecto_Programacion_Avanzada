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
    public class PagoController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarPago")]
        public int AgregarPago(PagoEnt entidad)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                return 0;
            }
        }

        [HttpDelete]
        [Route("api/EliminarPago")]
        public PagoEnt EliminarPago(PagoEnt entidad)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                return entidad;
            }

        }

        [HttpPut]
        [Route("api/EditarPago")]
        public int EditarPago(PagoEnt entidad)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                return 0;
            }
        }

        [HttpGet]
        [Route("api/GenerarInformePagoInscripcion")]
        public List<PagoEnt> GenerarInformePagoInscripcion(PagoEnt entidad)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                return null;
            }
        }

    }
}
