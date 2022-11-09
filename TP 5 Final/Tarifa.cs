using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class Tarifa
    {
        public Tarifa( bool esInternacional, bool recargoUrgente, bool recargoRetiroEnPuerta, bool recargoEntregaEnPuerta)
        {
            EsInternacional = esInternacional;
            RecargoUrgente = recargoUrgente;
            RecargoRetiroEnPuerta = recargoRetiroEnPuerta;
            RecargoEntregaEnPuerta = recargoEntregaEnPuerta;
        }

        public decimal MontoTotal { get; set; } // la suma de los montos totales por bulto
        public bool EsInternacional { get; set; }
        public bool RecargoUrgente { get; set; }
        public bool RecargoRetiroEnPuerta { get; set; }
        public bool RecargoEntregaEnPuerta { get; set; }


        public static float Calcular(bool retiro_domicilio, bool entrega_domicilio, bool urgente, float precio_bulto)
        {
            // interanacionales
            string tarifas_internacionales = Path.GetFullPath("..\\..\\..\\PreciosInternacionales.txt");
            FileInfo FI = new FileInfo(tarifas_internacionales);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(tarifas_internacionales);
            int contador_lineas = 0;
            while (!SR.EndOfStream)
            {
                SR.ReadLine();
                var tarifas = lineas[contador_lineas].Split('|');
                if (tarifas[0]=="0.5")
                {

                }
                else
                {
                    SR.Close();
                    break;
                }
                contador_lineas++;
            }


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
