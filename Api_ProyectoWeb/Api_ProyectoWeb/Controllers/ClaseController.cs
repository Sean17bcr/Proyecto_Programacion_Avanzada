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
    public class ClaseController : ApiController
    {

        [HttpGet]
        [Route("api/ConsultarClases")]
        public List<ClaseEnt> ConsultarClases()
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from c in bd.Clase
                             select c).ToList();
                List<ClaseEnt> resp = new List<ClaseEnt>();

                if (datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        resp.Add(new ClaseEnt
                        {
                            Clase_id = item.Clase_id,
                            Nombre = item.Nombre,
                            Descripcion = item.Descripcion,
                            Horario = item.Horario,
                            Capacidad = item.Capacidad
                        });
                    }
                }

                return resp;
            }
        }

        [HttpGet]
        [Route("api/ConsultarClase")]
        public ClaseEnt ConsultarClase(long q)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Clase
                             where x.Clase_id == q
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    ClaseEnt resp = new ClaseEnt();
                    resp.Clase_id = datos.Clase_id;
                    resp.Nombre = datos.Nombre;
                    resp.Descripcion = datos.Descripcion;
                    resp.Horario = datos.Horario;
                    resp.Capacidad = datos.Capacidad;
                    return resp;
                }

                return null;
            }
        }

        [HttpPost]
        [Route("api/RegistrarClase")]
        public long RegistrarClase(ClaseEnt entidad)
        {

                using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
                {
                    Clase tabla = new Clase();
                    tabla.Nombre = entidad.Nombre;
                    tabla.Descripcion = entidad.Descripcion;
                    tabla.Horario = entidad.Horario;
                    tabla.Capacidad = entidad.Capacidad;

                    bd.Clase.Add(tabla);
                    bd.SaveChanges();

                    return tabla.Clase_id;
                }
        }


        [HttpPut]
        [Route("api/ActualizarClase")]
        public int ActualizarClase(ClaseEnt entidad)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Clase
                             where x.Clase_id == entidad.Clase_id
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    datos.Nombre = entidad.Nombre;
                    datos.Descripcion = entidad.Descripcion;
                    datos.Horario = entidad.Horario;
                    datos.Capacidad = entidad.Capacidad;
                    return bd.SaveChanges();
                }
                return 0;
            }
        }

        [HttpDelete]
        [Route("api/EliminarClase")]
        public int EliminarClase(long q)
        {
                using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
                {
                var claseG = (from x in bd.Clase
                             where x.Clase_id == q
                             select x).FirstOrDefault();
                if (claseG != null)
                {
                    bd.Clase.Remove(claseG);
                    return bd.SaveChanges();
                }
                return 0;
            }
        }
    }
}

