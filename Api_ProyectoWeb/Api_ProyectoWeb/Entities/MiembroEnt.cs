using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ProyectoWeb.Entities
{
    public class MiembroEnt
    {
        public long miembro_id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo_electronico { get; set; }
        public DateTime fecha_inicio_membresia { get; set; }
    }
}