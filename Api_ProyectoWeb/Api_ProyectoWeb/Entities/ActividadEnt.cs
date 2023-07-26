using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ProyectoWeb.Entities
{
    public class ActividadEnt
    {
        public long actividad_id { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public String horario { get; set; }
    }
}