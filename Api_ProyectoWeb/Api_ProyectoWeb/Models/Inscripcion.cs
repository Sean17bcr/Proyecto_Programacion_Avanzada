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
    
    public partial class Inscripcion
    {
        public int Inscripcion_id { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> Clase_id { get; set; }
        public Nullable<System.DateTime> Fecha_inscripcion { get; set; }
        public bool Estado_inscripcion { get; set; }
        public string Detalles { get; set; }
    
        public virtual Clase Clase { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
