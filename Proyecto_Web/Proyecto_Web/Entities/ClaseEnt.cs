using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Web.Entities
{
    public class ClaseEnt
    {
        public int Clase_id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Horario { get; set; }
        public int Capacidad { get; set; }
    }
}