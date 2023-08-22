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
        [Route("api/IniciarSesion")]
        public UsuarioEnt IniciarSesion(UsuarioEnt entidad)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Usuario
                             join r in bd.Rol on x.IdRol equals r.IdRol
                             join m in bd.Membresia on x.IdMembresia equals m.IdMembresia
                             where x.CorreoElectronico == entidad.CorreoElectronico
                             && x.Contrasenna == entidad.Contrasenna
                             select new
                             {
                                 x.UsaClaveTemporal,
                                 x.FechaCaducidad,
                                 x.CorreoElectronico,
                                 x.Nombre,
                                 x.Identificacion,
                                 x.IdRol,
                                 r.NombreRol,
                                 x.IdUsuario,
                                 m.IdMembresia,
                                 m.TipoMembresia
                             }).FirstOrDefault();

                if (datos != null)
                {
                    if (datos.UsaClaveTemporal && datos.FechaCaducidad < DateTime.Now)
                        return null;

                    UsuarioEnt resp = new UsuarioEnt();
                    resp.CorreoElectronico = datos.CorreoElectronico;
                    resp.Nombre = datos.Nombre;
                    resp.Identificacion = datos.Identificacion;
                    resp.IdRol = datos.IdRol;
                    resp.NombreRol = datos.NombreRol;
                    resp.IdUsuario = datos.IdUsuario;
                    resp.IdMembresia = datos.IdMembresia;
                    resp.TipoMembresia = datos.TipoMembresia;
                    return resp;
                }

                return null;
            }
        }

        [HttpPost]
        [Route("api/Registrarse")]
        public int Registrarse(UsuarioEnt entidad)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                Usuario datos = new Usuario();
                datos.CorreoElectronico = entidad.CorreoElectronico;
                datos.Contrasenna = entidad.Contrasenna;
                datos.Identificacion = entidad.Identificacion;
                datos.Nombre = entidad.Nombre;
                datos.Telefono = entidad.Telefono;
                datos.IdRol = entidad.IdRol;
                datos.IdMembresia = entidad.IdMembresia;
                bd.Usuario.Add(datos);
                return bd.SaveChanges();
            }
        }

        [HttpGet]
        [Route("api/ConsultarUsuarios")]
        public List<UsuarioEnt> ConsultarUsuarios()
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Usuario
                             join r in bd.Rol on x.IdRol equals r.IdRol
                             join m in bd.Membresia on x.IdMembresia equals m.IdMembresia
                             select new
                             {
                                 x.CorreoElectronico,
                                 x.Nombre,
                                 x.Identificacion,
                                 x.IdRol,
                                 r.NombreRol,
                                 x.IdMembresia,
                                 m.TipoMembresia,
                                 x.Telefono,
                                 x.IdUsuario
                             }).ToList();

                List<UsuarioEnt> resp = new List<UsuarioEnt>();

                if (datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        resp.Add(new UsuarioEnt
                        {
                            CorreoElectronico = item.CorreoElectronico,
                            Nombre = item.Nombre,
                            Identificacion = item.Identificacion,
                            IdRol = item.IdRol,
                            NombreRol = item.NombreRol,
                            IdMembresia = item.IdMembresia,
                            TipoMembresia = item.TipoMembresia,
                            Telefono = item.Telefono,
                            IdUsuario = item.IdUsuario
                        });
                    }
                }

                return resp;
            }
        }

        [HttpGet]
        [Route("api/ConsultarUsuario")]
        public UsuarioEnt ConsultarUsuarios(long q)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Usuario
                             where x.IdUsuario == q
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    UsuarioEnt resp = new UsuarioEnt();
                    resp.CorreoElectronico = datos.CorreoElectronico;
                    resp.Nombre = datos.Nombre;
                    resp.Identificacion = datos.Identificacion;
                    resp.IdRol = datos.IdRol;
                    resp.IdMembresia = datos.IdMembresia;
                    resp.Telefono = datos.Telefono;
                    resp.IdUsuario = datos.IdUsuario;
                    return resp;
                }

                return null;
            }
        }

        [HttpGet]
        [Route("api/ConsultarRoles")]
        public List<RolEnt> ConsultarRoles()
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Rol
                             select x).ToList();

                List<RolEnt> resp = new List<RolEnt>();

                if (datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        resp.Add(new RolEnt
                        {
                            IdRol = item.IdRol,
                            NombreRol = item.NombreRol
                        });
                    }
                }

                return resp;
            }
        }

        [HttpGet]
        [Route("api/ConsultarMembresiasUsuario")]
        public List<MembresiaEnt> ConsultarMembresiasUsuario()
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Membresia
                             select x).ToList();

                List<MembresiaEnt> resp = new List<MembresiaEnt>();

                if (datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        resp.Add(new MembresiaEnt
                        {
                            IdMembresia = item.IdMembresia,
                            TipoMembresia = item.TipoMembresia
                        });
                    }
                }

                return resp;
            }
        }

        [HttpPut]
        [Route("api/EditarUsuario")]
        public int EditarUsuario(UsuarioEnt entidad)
        {
            using (var bd = new GimnasioDBPrograAvanzadaProyectoFinalEntities1())
            {
                var datos = (from x in bd.Usuario
                             where x.IdUsuario == entidad.IdUsuario
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    datos.CorreoElectronico = entidad.CorreoElectronico;
                    datos.IdRol = entidad.IdRol;
                    return bd.SaveChanges();
                }
                return 0;
            }
        }
    }
}
