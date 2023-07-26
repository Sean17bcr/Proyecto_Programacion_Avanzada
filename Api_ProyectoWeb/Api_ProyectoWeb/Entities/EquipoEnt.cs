using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ProyectoWeb.Entities
{
    public class EquipoEnt
    {
        public long equipo_id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int capacidad { get; set; }
       
    }
}