using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ProyectoWeb.Entities
{
    public class InscripcionEnt
    {
        public long inscripcion_id { get; set; }
        public long miembro_id { get; set; }
        public long clase_id { get; set; }
        public long actividad_id { get; set; }
        public DateTime fecha_inscripcion { get; set; }
        public bool estado_inscripcion { get; set; }
        public String detalles { get; set; }

    }
}