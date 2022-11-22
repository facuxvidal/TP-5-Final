using System;
using System.Collections;
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
        public Tarifa(bool esInternacional, bool recargoUrgente, bool recargoRetiroEnPuerta, bool recargoEntregaEnPuerta)
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


        public static decimal Calcular(Tarifa tarifa, SolicitudDeServicio solicitud, List<EncomiendaCorrespondencia> encomiendas, string ubicacion, string previo_internacional)
        {
            decimal precio_bulto = 0;
            string tarifas_por_region = Path.GetFullPath("..\\..\\..\\TarifasXRegion.txt");
            FileInfo FI = new FileInfo(tarifas_por_region);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(tarifas_por_region);
            int contador_lineas = 0;
            string costo_tarifa = "";
            while (!SR.EndOfStream)
            {
                SR.ReadLine();
                var tarifas_por_peso = lineas[contador_lineas].Split('|');
                contador_lineas++;
                if (tarifas_por_peso[0] == ubicacion)
                {
                    foreach (var encomienda in encomiendas)
                    {
                        // Recorrro  las tarifas hasta que encuentro el peso de la encomienda y la macheo con su costo
                        for (int i = 1; i < 5; i++)
                        {
                            var peso_y_costo = tarifas_por_peso[i].Split('-');
                            if (peso_y_costo[0] == encomienda.Peso.ToString())
                            {
                                costo_tarifa = peso_y_costo[1];
                                break;
                            }
                        }

                        /*switch (ubicacion)
                        {
                            case "LOCAL":
                                {
                                    precio_bulto += decimal.Parse(costo_tarifa);
                                    break;
                                }
                            case "PROVINCIAL":
                                {
                                    precio_bulto += decimal.Parse(costo_tarifa);
                                    break;
                                }
                            case "REGIONAL":
                                {
                                    precio_bulto += decimal.Parse(costo_tarifa);
                                    break;
                                }
                            case "NACIONAL":
                                {
                                    precio_bulto += decimal.Parse(costo_tarifa);
                                    break;
                                }
                            case "PAISES LIMITROFES":
                                {
                                    precio_bulto += decimal.Parse(costo_tarifa);
                                    break;
                                }
                            case "AMERICA LATINA":
                                {
                                    precio_bulto += decimal.Parse(costo_tarifa);
                                    break;
                                }
                            case "AMERICA DEL NORTE":
                                {
                                    precio_bulto += decimal.Parse(costo_tarifa);
                                    break;
                                }
                            case "EUROPA":
                                {
                                    precio_bulto += decimal.Parse(costo_tarifa);
                                    break;
                                }
                            case "ASIA":
                                {
                                    precio_bulto += decimal.Parse(costo_tarifa);
                                    break;
                                }
                        }*/
                        precio_bulto += decimal.Parse(costo_tarifa);
                    }
                }

                // Si es internacional sumo costo de envío hasta CABA
                if(tarifas_por_peso[0] == previo_internacional)
                {
                    foreach (var encomienda in encomiendas)
                    {
                        // Recorrro  las tarifas hasta que encuentro el peso de la encomienda y la macheo con su costo
                        for (int i = 1; i < 5; i++)
                        {
                            var peso_y_costo = tarifas_por_peso[i].Split('-');
                            if (peso_y_costo[0] == encomienda.Peso.ToString())
                            {
                                costo_tarifa = peso_y_costo[1];
                                break;
                            }
                        }

                        /*switch (previo_internacional)
                        {
                            case "PROVINCIAL":
                                {
                                    precio_bulto += decimal.Parse(costo_tarifa);
                                    break;
                                }
                            case "REGIONAL":
                                {
                                    precio_bulto += decimal.Parse(costo_tarifa);
                                    break;
                                }
                            case "NACIONAL":
                                {
                                    precio_bulto += decimal.Parse(costo_tarifa);
                                    break;
                                }
                        }*/
                        precio_bulto += decimal.Parse(costo_tarifa);

                    }
                }
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
