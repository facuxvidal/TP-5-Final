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


        public static float Calcular(bool retiro_domicilio, bool entrega_domicilio, bool urgente, string origen, string destino, bool internacional, float peso)
        {
            float precio_bulto = 0f;

            // interanacionales
            if (internacional)
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

                    // NO SE SI ESTA BIEN. NOS FALTA EL DATO DEL PESO PARA COMPARAR CUAL DEBERIA SER)
                    if (tarifas[0] == "0.5")
                    {
                        switch (destino)
                        {
                            case "PAISES LIMITROFES":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[1]);
                                    break;
                                }
                            case "AMERICA LATINA":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[2]);
                                    break;
                                }
                            case "AMERICA DEL NORTE":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[3]);
                                    break;
                                }
                            case "EUROPA":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[4]);
                                    break;
                                }
                            case "ASIA":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[5]);
                                    break;
                                }
                            default:
                                destino = "Sin Identificar";
                                break;
                        }
                    }
                    else if (tarifas[0] == "10")
                    {
                        switch (destino)
                        {
                            case "PAISES LIMITROFES":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[1]);
                                    break;
                                }
                            case "AMERICA LATINA":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[2]);
                                    break;
                                }
                            case "AMERICA DEL NORTE":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[3]);
                                    break;
                                }
                            case "EUROPA":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[4]);
                                    break;
                                }
                            case "ASIA":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[5]);
                                    break;
                                }
                            default:
                                destino = "Sin Identificar";
                                break;
                        }
                    }
                    else if (tarifas[0] == "20")
                    {
                        switch (destino)
                        {
                            case "PAISES LIMITROFES":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[1]);
                                    break;
                                }
                            case "AMERICA LATINA":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[2]);
                                    break;
                                }
                            case "AMERICA DEL NORTE":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[3]);
                                    break;
                                }
                            case "EUROPA":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[4]);
                                    break;
                                }
                            case "ASIA":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[5]);
                                    break;
                                }
                            default:
                                destino = "Sin Identificar";
                                break;
                        }
                    }
                    else if (tarifas[0] == "30")
                    {
                        switch (destino)
                        {
                            case "PAISES LIMITROFES":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[1]);
                                    break;
                                }
                            case "AMERICA LATINA":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[2]);
                                    break;
                                }
                            case "AMERICA DEL NORTE":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[3]);
                                    break;
                                }
                            case "EUROPA":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[4]);
                                    break;
                                }
                            case "ASIA":
                                {
                                    precio_bulto = Convert.ToSingle(tarifas[5]);
                                    break;
                                }
                            default:
                                destino = "Sin Identificar";
                                break;
                        }
                    }


                    else
                    {
                        SR.Close();
                        break;
                    }
                    contador_lineas++;
                }

                if(destino == tarifas_internacionales[])
            }
            // nacionales
            else
            {

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

        public static void Cargar()
        {
            

        }


    }
}
