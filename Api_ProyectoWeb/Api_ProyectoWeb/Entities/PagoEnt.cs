using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ProyectoWeb.Entities
{
    public class PagoEnt
    {
        public int Pago_id { get; set; }
        public int IdUsuario { get; set; }
        public int IdMembresia { get; set; }
        public DateTime Fecha_pago { get; set; }
        public decimal Monto { get; set; }
        public String Metodo_pago { get; set; }
    }
}