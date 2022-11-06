using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public static class Menu
    {
        public static string MostrarPrincipal()
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");
            opciones_validas.Add("3");
            opciones_validas.Add("4");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine("------------------------------------\nIngrese un numero de acuerdo a la accion que necesita realizar");
                Console.WriteLine("[1] Solicitar servicio \n[2] Consultar estado de cuenta \n[3] Consultar seguimiento del pedido \n[4] Salir");
                opcion_elegida = Console.ReadLine();

                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(opcion_elegida))
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
            return opcion_elegida;
        }
        public static void MostrarConsutaCiudadDestino()
        {

        }
        public static void MostrarConsutaCiudadOrigen()
        {

        }
        public static void MostrarConsutaPeso()
        {

        }
        public static void MostrarConsutaSeguimiento()
        {

        }
        private static bool ValidaEntero(string numero)
        {
            bool rsp = true;
            int entero_validado;

            if (!int.TryParse(numero, out entero_validado))
            {
                rsp = false;
            }
            else if (entero_validado <= 0)
            {
                rsp = false;
            }
            return rsp;
        }
    }
}
