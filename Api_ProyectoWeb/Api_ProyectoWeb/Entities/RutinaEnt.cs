using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ProyectoWeb.Entities
{
    public class RutinaEnt
    {
        public long Rutina_id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public int Duracion { get; set; }
        
    }
}