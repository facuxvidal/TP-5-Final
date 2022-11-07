using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class Factura
    {
        public int NumeroFactura { get; set; }
        public decimal PrecioFinal { get; set; }
        public int Unidades { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Estado { get; set; } // Solo puede tomar 2 valores

        public void GenerarFactura()
        {
            // crea una instancia de objeto de la clase Factura
        }
    }
}
