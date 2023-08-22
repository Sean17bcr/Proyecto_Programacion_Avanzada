using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ProyectoWeb.Entities
{
    public class UsuarioEnt
    {
        public int IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasenna { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string ContrasennaNueva { get; set; }
        public string ConfirmarContrasenna { get; set; }
        public string Telefono { get; set; }
        public byte IdRol { get; set; }
        public int? IdMembresia { get; set; }
        public string NombreRol { get; set; }
        public string TipoMembresia { get; set; }
        public DateTime FechaCaducidad { get; set; }
    }
}