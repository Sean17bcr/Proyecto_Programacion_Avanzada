//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api_ProyectoWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Actividad
    {
        public Actividad()
        {
            this.Inscripcion = new HashSet<Inscripcion>();
        }
    
        public int actividad_id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string horario { get; set; }
    
        public virtual ICollection<Inscripcion> Inscripcion { get; set; }
    }
}
