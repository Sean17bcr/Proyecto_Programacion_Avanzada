using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Web.Entities
{
    public class InscripcionEnt
    {
        public int Inscripcion_id { get; set; }
        public int IdUsuario { get; set; }
        public int Clase_id { get; set; }
        public string NombreUsuario { get; set; }
        public string ClaseUsuario { get; set; }
        public DateTime Fecha_inscripcion { get; set; }
        public bool Estado_inscripcion { get; set; }
        public string Detalles { get; set; }
        public string UserName { get; set; }
        public string Clase { get; set; }
    }
}