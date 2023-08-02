using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ProyectoWeb.Entities
{
    public class InscripcioEnt
    {
        public long Inscripcion_id { get; set; }
        public long IdUsuario { get; set; }
        public long Clase_id { get; set; }
        public DateTime Fecha_inscripcion { get; set; }
        public bool Estado_inscripcion { get; set; }
        public string Detalles { get; set; }
    }
}