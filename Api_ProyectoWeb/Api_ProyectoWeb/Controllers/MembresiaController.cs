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
    public class MembresiaController: ApiController
    {
        [HttpGet]
        [Route("api/ConsultarMembresias")]
        public List<MembresiaEnt> ConsultarMembresias()
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from c in bd.Membresia
                             select c).ToList();
                List<MembresiaEnt> resp = new List<MembresiaEnt>();

                if (datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        resp.Add(new MembresiaEnt
                        {
                            IdMembresia = item.IdMembresia,
                            TipoMembresia = item.TipoMembresia,
                            PrecioMembresia = item.PrecioMembresia                            
                        });
                    }
                }
                return resp;
            }
        }

        [HttpGet]
        [Route("api/ConsultarMembresia")]
        public MembresiaEnt ConsultarMembresia(long q)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Membresia
                             where x.IdMembresia == q
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    MembresiaEnt resp = new MembresiaEnt();
                    resp.IdMembresia = datos.IdMembresia;
                    resp.TipoMembresia = datos.TipoMembresia;
                    resp.PrecioMembresia = datos.PrecioMembresia;
                    return resp;
                }

                return null;
            }
        }

        [HttpPost]
        [Route("api/RegistrarMembresia")]
        public long RegistrarMembresia(MembresiaEnt entidad)
        {

            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                Membresia tabla = new Membresia();
                tabla.TipoMembresia = entidad.TipoMembresia;
                tabla.PrecioMembresia = entidad.PrecioMembresia;

                bd.Membresia.Add(tabla);
                bd.SaveChanges();

                return tabla.IdMembresia;
            }
        }


        [HttpPut]
        [Route("api/ActualizarMembresia")]
        public int ActualizarMembresia(MembresiaEnt entidad)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Membresia
                             where x.IdMembresia == entidad.IdMembresia
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    datos.TipoMembresia = entidad.TipoMembresia;
                    datos.PrecioMembresia = entidad.PrecioMembresia;
                    return bd.SaveChanges();
                }
                return 0;
            }
        }

        [HttpDelete]
        [Route("api/EliminarMembresia")]
        public int EliminarMembresia(long q)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var membresia = (from x in bd.Membresia
                              where x.IdMembresia == q
                              select x).FirstOrDefault();
                if (membresia != null)
                {
                    bd.Membresia.Remove(membresia);
                    return bd.SaveChanges();
                }
                return 0;
            }
        }
    }
}