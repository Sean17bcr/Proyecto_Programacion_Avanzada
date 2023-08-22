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
        [HttpGet]
        [Route("api/ConsultarEquipos")]
        public List<EquipoEnt> ConsultarEquipos()
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from c in bd.Equipo
                             select c).ToList();
                List<EquipoEnt> resp = new List<EquipoEnt>();

                if (datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        resp.Add(new EquipoEnt
                        {
                            Equipo_id = item.Equipo_id,
                            Nombre = item.Nombre,
                            Descripcion = item.Descripcion,
                            Cantidad = item.Cantidad
                        });
                    }
                }
                return resp;
            }
        }

        [HttpGet]
        [Route("api/ConsultarEquipo")]
        public EquipoEnt ConsultarEquipo(long q)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Equipo
                             where x.Equipo_id == q
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    EquipoEnt resp = new EquipoEnt();
                    resp.Equipo_id = datos.Equipo_id;
                    resp.Nombre = datos.Nombre;
                    resp.Descripcion = datos.Descripcion;
                    resp.Cantidad = datos.Cantidad;
                    return resp;
                }

                return null;
            }
        }

        [HttpPost]
        [Route("api/RegistrarEquipo")]
        public long RegistrarEquipo(EquipoEnt entidad)
        {

            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                Equipo tabla = new Equipo();
                tabla.Nombre = entidad.Nombre;
                tabla.Descripcion = entidad.Descripcion;
                tabla.Cantidad = entidad.Cantidad;

                bd.Equipo.Add(tabla);
                bd.SaveChanges();

                return tabla.Equipo_id;
            }
        }


        [HttpPut]
        [Route("api/ActualizarEquipo")]
        public int ActualizarEquipo(EquipoEnt entidad)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Equipo
                             where x.Equipo_id == entidad.Equipo_id
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    datos.Nombre = entidad.Nombre;
                    datos.Descripcion = entidad.Descripcion;
                    datos.Cantidad = entidad.Cantidad;
                    return bd.SaveChanges();
                }
                return 0;
            }
        }

        [HttpDelete]
        [Route("api/EliminarEquipo")]
        public int EliminarEquipo(long q)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var equipo = (from x in bd.Equipo
                              where x.Equipo_id == q
                              select x).FirstOrDefault();
                if (equipo != null)
                {
                    bd.Equipo.Remove(equipo);
                    return bd.SaveChanges();
                }
                return 0;
            }
        }
    }
}


