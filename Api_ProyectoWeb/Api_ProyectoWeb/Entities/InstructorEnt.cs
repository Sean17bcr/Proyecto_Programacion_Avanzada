using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ProyectoWeb.Entities
{
    public class InstructorEnt
    {
        public long instructor_id { get; set; }
        public string nombre { get; set; }
        public string especialidad { get; set; }
        public string horarios_disponibles { get; set; }

    }
}