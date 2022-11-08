using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class Tarifa
    {
        public decimal MontoTotal { get; set; } // la suma de los montos totales por bulto
        public bool EsInternacional { get; set; }
        public decimal RecargoUrgente { get; set; }
        public decimal RecargoRetiroEnPuerta { get; set; }
        public decimal RecargoEntregaEnPuerta { get; set; }


        public void Calcular()
        {

        }

        public void Cargar()
        {

        }

        
    }
}
