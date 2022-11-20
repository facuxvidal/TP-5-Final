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

        public static decimal Calcular(Tarifa tarifa, SolicitudDeServicio solicitud, List<EncomiendaCorrespondencia> encomiendas, string ubicacion)
        {
            decimal precio_bulto = 0;
            if (tarifa.EsInternacional)
            {
                string tarifas_internacionales = Path.GetFullPath("..\\..\\..\\PreciosInternacionales.txt");
                FileInfo FI = new FileInfo(tarifas_internacionales);
                StreamReader SR = FI.OpenText();
                string[] lineas = File.ReadAllLines(tarifas_internacionales);
                int contador_lineas = 0;
                while (!SR.EndOfStream)
                {
                    SR.ReadLine();
                    var tarifas = lineas[contador_lineas].Split('|');
                    contador_lineas++;
                    foreach (var encomienda in encomiendas)
                    {
                        if (tarifas[0] == encomienda.Peso.ToString())
                        {
                            switch (ubicacion)
                            {
                                case "PAISES LIMITROFES":
                                    {
                                        precio_bulto += decimal.Parse(tarifas[1]);
                                        break;
                                    }
                                case "AMERICA LATINA":
                                    {
                                        precio_bulto += decimal.Parse(tarifas[2]);
                                        break;
                                    }
                                case "AMERICA DEL NORTE":
                                    {
                                        precio_bulto += decimal.Parse(tarifas[3]);
                                        break;
                                    }
                                case "EUROPA":
                                    {
                                        precio_bulto += decimal.Parse(tarifas[4]);
                                        break;
                                    }
                                case "ASIA":
                                    {
                                        precio_bulto += decimal.Parse(tarifas[5]);
                                        break;
                                    }
                            }
                        }
                    }
                }
                SR.Close();
            }
            else
            {
                string tarifas_nacionales = Path.GetFullPath("..\\..\\..\\PreciosNacionales.txt");
                FileInfo FI = new FileInfo(tarifas_nacionales);
                StreamReader SR = FI.OpenText();
                string[] lineas = File.ReadAllLines(tarifas_nacionales);
                int contador_lineas = 0;
                
                while (!SR.EndOfStream)
                {
                    SR.ReadLine();
                    var tarifas = lineas[contador_lineas].Split('|');
                    contador_lineas++;
                    foreach (var encomienda in encomiendas)
                    {
                        if (tarifas[0] == encomienda.Peso.ToString())
                        {
                            switch (ubicacion)
                            {
                                case "LOCAL":
                                    {
                                        precio_bulto += decimal.Parse(tarifas[1]);
                                        break;
                                    }
                                case "PROVINCIAL":
                                    {
                                        precio_bulto += decimal.Parse(tarifas[2]);
                                        break;
                                    }
                                case "REGIONAL":
                                    {
                                        precio_bulto += decimal.Parse(tarifas[3]);
                                        break;
                                    }
                                case "NACIONAL":
                                    {
                                        precio_bulto += decimal.Parse(tarifas[4]);
                                        break;
                                    }
                            }
                        }
                    }
                }
                SR.Close();
            }

            decimal sumador = 0;
            decimal sumador_urgente = 0;
            if (tarifa.RecargoRetiroEnPuerta)
                sumador += 3500;
            if (tarifa.RecargoEntregaEnPuerta)
                sumador += 1500;
            if (tarifa.RecargoUrgente)
            {
                sumador_urgente += precio_bulto * 0.5M;
                if (sumador_urgente > 15000)
                {
                    sumador_urgente = 15000;
                }
            }
            return tarifa.MontoTotal = sumador + sumador_urgente + precio_bulto;

        }

        public static decimal Calcular2(Tarifa tarifa, SolicitudDeServicio solicitud, List<EncomiendaCorrespondencia> encomiendas, string ubicacion)
        {
            decimal precio_bulto = 0;
            string tarifas_por_region = Path.GetFullPath("..\\..\\..\\TarifasXRegion.txt");
            FileInfo FI = new FileInfo(tarifas_por_region);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(tarifas_por_region);
            int contador_lineas = 0;
            int contador_peso = 0;
            while (!SR.EndOfStream)
            {
                SR.ReadLine();
                var tarifas_por_peso = lineas[contador_lineas].Split('|');
                contador_lineas++;
                if (tarifas_por_peso[0] == ubicacion)
                {
                    foreach (var encomienda in encomiendas)
                    {
                        contador_peso++;
                        var peso_y_costo = tarifas_por_peso[contador_peso].Split('-');

                        foreach (var peso in peso_y_costo) // TENEMOS QUE RECORRER LOS PESOS Y SUS COSTOS PARA MACHEARLOS CON EL PESO DE LA ENCOMIENDA SIN QUE SE VAYA DEL LOOP
                        {

                        }

                        if (peso_y_costo[0] == encomienda.Peso.ToString()) // ESTO LO TENEMOS QUE CORREGIR
                        {
                            switch (ubicacion)
                            {
                                case "LOCAL":
                                    {
                                        precio_bulto += decimal.Parse(peso_y_costo[1]);
                                        break;
                                    }
                                case "PROVINCIAL":
                                    {
                                        precio_bulto += decimal.Parse(peso_y_costo[1]);
                                        break;
                                    }
                                case "REGIONAL":
                                    {
                                        precio_bulto += decimal.Parse(peso_y_costo[1]);
                                        break;
                                    }
                                case "NACIONAL":
                                    {
                                        precio_bulto += decimal.Parse(peso_y_costo[1]);
                                        break;
                                    }
                                case "PAISES LIMITROFES":
                                    {
                                        precio_bulto += decimal.Parse(peso_y_costo[1]);
                                        break;
                                    }
                                case "AMERICA LATINA":
                                    {
                                        precio_bulto += decimal.Parse(peso_y_costo[1]);
                                        break;
                                    }
                                case "AMERICA DEL NORTE":
                                    {
                                        precio_bulto += decimal.Parse(peso_y_costo[1]);
                                        break;
                                    }
                                case "EUROPA":
                                    {
                                        precio_bulto += decimal.Parse(peso_y_costo[1]);
                                        break;
                                    }
                                case "ASIA":
                                    {
                                        precio_bulto += decimal.Parse(peso_y_costo[1]);
                                        break;
                                    }
                            }
                        }
                    }
                }
                contador_peso = 0;
            }
            SR.Close();

            decimal sumador = 0;
            decimal sumador_urgente = 0;
            if (tarifa.RecargoRetiroEnPuerta)
                sumador += 3500;
            if (tarifa.RecargoEntregaEnPuerta)
                sumador += 1500;
            if (tarifa.RecargoUrgente)
            {
                sumador_urgente += precio_bulto * 0.5M;
                if (sumador_urgente > 15000)
                {
                    sumador_urgente = 15000;
                }
            }
            return tarifa.MontoTotal = sumador + sumador_urgente + precio_bulto;
        }
    }
}
