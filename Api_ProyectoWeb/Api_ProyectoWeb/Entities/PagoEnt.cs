using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ProyectoWeb.Entities
{
    public class PagoEnt
    {
        public long pago_id { get; set; }
        public long miembro_id { get; set; }
        public DateTime fecha_pago { get; set; }
        public decimal monto { get; set; }
        public String metodo_pago { get; set; }
        public bool estado_pago { get; set; }
    }
}