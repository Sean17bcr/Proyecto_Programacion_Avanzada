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
    public class RutinaController : ApiController
    {

        [HttpGet]
        [Route("api/ConsultarRutinas")]
        public List<RutinaEnt> ConsultarRutinas()
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from c in bd.Rutina
                             select c).ToList();
                List<RutinaEnt> resp = new List<RutinaEnt>();

                if (datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        resp.Add(new RutinaEnt
                        {
                            Rutina_id = item.Rutina_id,
                            Nombre = item.Nombre,
                            Descripcion = item.Descripcion,
                            Duracion = item.Duracion
                        });
                    }
                }
                return resp;
            }
        }

        [HttpGet]
        [Route("api/ConsultarRutina")]
        public RutinaEnt ConsultarRutina(long q)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Rutina
                             where x.Rutina_id == q
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    RutinaEnt resp = new RutinaEnt();
                    resp.Rutina_id = datos.Rutina_id;
                    resp.Nombre = datos.Nombre;
                    resp.Descripcion = datos.Descripcion;
                    resp.Duracion = datos.Duracion;
                    return resp;
                }

                return null;
            }
        }

        [HttpPost]
        [Route("api/RegistrarRutina")]
        public long RegistrarRutina(RutinaEnt entidad)
        {

            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                Rutina tabla = new Rutina();
                tabla.Nombre = entidad.Nombre;
                tabla.Descripcion = entidad.Descripcion;
                tabla.Duracion = entidad.Duracion;

                bd.Rutina.Add(tabla);
                bd.SaveChanges();

                return tabla.Rutina_id;
            }
        }


        [HttpPut]
        [Route("api/ActualizarRutina")]
        public int ActualizarRutina(RutinaEnt entidad)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Rutina
                             where x.Rutina_id == entidad.Rutina_id
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    datos.Nombre = entidad.Nombre;
                    datos.Descripcion = entidad.Descripcion;
                    datos.Duracion = entidad.Duracion;
                    return bd.SaveChanges();
                }
                return 0;
            }
        }

        [HttpDelete]
        [Route("api/EliminarRutina")]
        public int EliminarRutina(long q)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var rutina = (from x in bd.Rutina
                              where x.Rutina_id == q
                              select x).FirstOrDefault();
                if (rutina != null)
                {
                    bd.Rutina.Remove(rutina);
                    return bd.SaveChanges();
                }
                return 0;
            }
        }
    }
}


