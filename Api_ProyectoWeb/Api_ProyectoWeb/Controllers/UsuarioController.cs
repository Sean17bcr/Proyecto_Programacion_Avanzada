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
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("api/AgregarUsuario")]
        public int AgregarUsuario(UsuarioEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return 0;
            }

        }

        [HttpDelete]
        [Route("api/EliminarUsuario")]
        public UsuarioEnt EliminarUsuario(UsuarioEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return null;
            }

        }

        [HttpPut]
        [Route("api/EditarUsuario")]
        public int EditarUsuario(UsuarioEnt entidad)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return 0;
            }
        }

        [HttpGet]
        [Route("api/BuscarUsuarioPorNombre")]
        public UsuarioEnt BuscarUsuarioPorNombre(long q)
        {
            using (var bd = new GimnasioDBEntities())
            {
                var datos = (from x in bd.Miembro
                             where x.miembro_id == q
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    UsuarioEnt resp = new UsuarioEnt();
                    resp.nombre = datos.nombre;
                    resp.direccion = datos.direccion;
                    resp.telefono = datos.telefono;
                    resp.correo_electronico = datos.correo_electronico;
                    resp.fecha_inicio_membresia = datos.fecha_inicio_membresia;
                    return resp;
                }

                return null;
            }
        }

        [HttpGet]
        [Route("api/GenerarInformePagoInscripcion")]
        public UsuarioEnt GenerarInformePagoInscripcion(long q)
        {
            using (var bd = new GimnasioDBEntities())
            {
                return null;
            }
        }



    }
}
