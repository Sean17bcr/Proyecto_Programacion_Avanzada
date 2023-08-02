using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ProyectoWeb.Entities
{
    public class PagoEnt
    {
        public long Pago_id { get; set; }
        public long IdUsuario { get; set; }
        public DateTime Fecha_pago { get; set; }
        public decimal Monto { get; set; }
        public String Metodo_pago { get; set; }
    }
}