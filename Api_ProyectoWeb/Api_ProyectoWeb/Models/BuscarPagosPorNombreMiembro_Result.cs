//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api_ProyectoWeb.Models
{
    using System;
    
    public partial class BuscarPagosPorNombreMiembro_Result
    {
        public int pago_id { get; set; }
        public Nullable<int> miembro_id { get; set; }
        public Nullable<System.DateTime> fecha_pago { get; set; }
        public Nullable<decimal> monto { get; set; }
        public string metodo_pago { get; set; }
        public string estado_pago { get; set; }
        public string nombre_miembro { get; set; }
    }
}
