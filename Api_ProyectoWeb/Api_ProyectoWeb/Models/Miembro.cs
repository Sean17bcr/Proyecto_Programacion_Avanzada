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
    
    public partial class Miembro
    {
        public Miembro()
        {
            this.Inscripcion = new HashSet<Inscripcion>();
            this.Pago = new HashSet<Pago>();
            this.RegistroAcceso = new HashSet<RegistroAcceso>();
        }
    
        public int miembro_id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo_electronico { get; set; }
        public System.DateTime fecha_inicio_membresia { get; set; }
    
        public virtual ICollection<Inscripcion> Inscripcion { get; set; }
        public virtual ICollection<Pago> Pago { get; set; }
        public virtual ICollection<RegistroAcceso> RegistroAcceso { get; set; }
    }
}
