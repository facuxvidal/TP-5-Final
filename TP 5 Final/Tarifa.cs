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


        public static decimal Calcular(bool retiro_domicilio, bool entrega_domicilio, bool urgente, float precio_bulto)
        {
            // A CODEAR
            float sumador = 0f;
            float sumador_urgente = 0f;
            if (retiro_domicilio)
                sumador += 3500;
            if (entrega_domicilio)
                sumador += 1500;
            if (urgente)
            {
                sumador_urgente += precio_bulto * 0.5f;
                if (sumador_urgente > 15000)
                {
                    sumador_urgente = 15000;
                }
            }
            sumador += sumador_urgente;


            return 12;
        }

        public void Cargar()
        {
            

        }


    }
}
