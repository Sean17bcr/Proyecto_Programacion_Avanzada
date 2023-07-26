using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ProyectoWeb.Entities
{
    public class ClaseEnt
    {
        public long clase_id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string horario { get; set; }
        public int capacidad { get; set; }
       
    }
}