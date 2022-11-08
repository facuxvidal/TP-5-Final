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

        public static bool consulta_urgencia()
        {
            {
                List<string> opciones_validas = new List<string>();
                opciones_validas.Add("1");
                opciones_validas.Add("2");

                string opcion_elegida = "";
                bool bandera = true;
                while (bandera)
                {
                    Console.WriteLine("------------------------------------\nPor favor responder correctamente: ¿Es urgente el envio de este pedido? Ingrese el número segén corresponda");
                    Console.WriteLine("[1] Si \n[2] No");
                    opcion_elegida = Console.ReadLine();

                    if (String.IsNullOrEmpty(opcion_elegida))
                    {
                        Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                        Console.WriteLine("------------------------------------\nIntente nuevamente!");
                    }
                    else if (!int.TryParse(opcion_elegida, out int salida))
                    {
                        Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                        Console.WriteLine("------------------------------------\nIntente nuevamente!");
                    }
                    else if (!opciones_validas.Contains(opcion_elegida))
                    {
                        Console.WriteLine("------------------------------------\nERROR - Marcó una opcion fuera del intervalo propuesto!");
                        Console.WriteLine("------------------------------------\nIntente nuevamente!");
                    }
                    else
                    {
                        bandera = false;
                    }
                }

                bool rsp = false;
                switch (opcion_elegida)
                {
                    case "1":
                        {
                            rsp = true;
                            break;
                        }
                    case "2":
                        {
                            rsp = false;
                            break;
                        }
                }
                return rsp;
            }
        }
    }
}
