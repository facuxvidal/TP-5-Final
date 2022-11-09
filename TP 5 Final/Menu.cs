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
        public static string MostrarConsultaEncomiendas()
        {
            List<string> encomiendas_habilitadas = new List<string>();
            encomiendas_habilitadas.Add("1");
            encomiendas_habilitadas.Add("2");
            encomiendas_habilitadas.Add("3");
            encomiendas_habilitadas.Add("4");
            encomiendas_habilitadas.Add("5");

            string encomiendas = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine("------------------------------------\nIngrese la cantidad de Encomiendas o Correspondencia que desee enviar en su pedido:");
                encomiendas = Console.ReadLine();

                if (String.IsNullOrEmpty(encomiendas))
                {
                    Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(encomiendas))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!encomiendas_habilitadas.Contains(encomiendas))
                {
                    Console.WriteLine("------------------------------------\nERROR - Puede enviar hasta 5 encomiendas por Servicio!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }
            return encomiendas;
        }
        public static string MostrarConsutaPeso(int encomiendas)
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");
            opciones_validas.Add("3");
            opciones_validas.Add("4");
            opciones_validas.Add("5");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese un numero de acuerdo al peso del encomienda/correspondencia N° {encomiendas + 1}\n------------------------------------");
                Console.WriteLine("[1] Menor o igual a 500gr \n[2] Mayor a 500gr y hasta 10 kg \n[3] Hasta 20 kg \n[4] Hasta 30 kg \n[5] Mayor");
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
        public static string MostrarConsultaDeseaSalir()
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\n¿Desea salir?\n------------------------------------");
                Console.WriteLine("[1] Si \n[2] No");
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
        public static void MostrarConsutaSeguimiento()
        {

        }
        public static bool MostrarConsultaUrgencia()
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
        public static string MostrarConsultaSucursales(string accion)
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");
            opciones_validas.Add("3");
            opciones_validas.Add("4");
            opciones_validas.Add("5");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese un número dependiendo de la sucursal donde desea {accion.ToLower()} su pedido\n------------------------------------");
                Console.WriteLine("[1] VIEDMA\n[2] CORDOBA\n[3] RESISTENCIA\n[4] CABA \n[5] AGENTE OFICIAL EXTERNO");
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

            string rsp;
            switch (opcion_elegida)
            {
                case "1":
                    {
                        rsp = $"{accion} en Sucursal de VIEDMA";
                        break;
                    }
                case "2":
                    {
                        rsp = $"{accion} en Sucursal de CORDOBA";
                        break;
                    }
                case "3":
                    {
                        rsp = $"{accion} en Sucursal de RESISTENCIA";
                        break;
                    }
                case "4":
                    {
                        rsp = $"{accion} en Sucursal de CABA";
                        break;
                    }
                case "5":
                    {
                        rsp = $"{accion} en Agente oficial externo";
                        break;
                    }
                default:
                    rsp = "Sin Identificar";
                    break;
            }
            return rsp;
        }


        public static string MostrarConsultaProvincia(string ubicacion)
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");
            opciones_validas.Add("3");
            opciones_validas.Add("4");
            opciones_validas.Add("5");
            opciones_validas.Add("6");
            opciones_validas.Add("7");
            opciones_validas.Add("8");
            opciones_validas.Add("9");
            opciones_validas.Add("10");
            opciones_validas.Add("11");
            opciones_validas.Add("12");
            opciones_validas.Add("13");
            opciones_validas.Add("14");
            opciones_validas.Add("15");
            opciones_validas.Add("16");
            opciones_validas.Add("17");
            opciones_validas.Add("18");
            opciones_validas.Add("19");
            opciones_validas.Add("20");
            opciones_validas.Add("21");
            opciones_validas.Add("22");
            opciones_validas.Add("23");
            opciones_validas.Add("24");

            string opcion_elegida = "";
            bool bandera = true;

            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese un número segun la Provincia de {ubicacion} que corresponda:  ");
                Console.WriteLine("[1] CABA \n[2] BUENOS AIRES \n[3] CORDOBA \n[4] SAN JUAN \n[5] SAN LUIS \n[6] SANTA CRUZ \n[7] CHUBUT \n[8] RIO NEGRO ");
                Console.WriteLine("[9] NEUQUEN \n[10] LA PAMPA \n[11] TIERRA DEL FUEGO \n[12] MENDOZA \n[13] LA RIOJA \n[14] ENTRE RIOS \n[15] SANTA FE \n[16] CORRIENTES ");
                Console.WriteLine("[17] MISIONES \n[18] CHACO \n[19] CATAMARCA \n[20] SANTIAGO DEL ESTERO \n[21] TUCUMAN \n[22] FORMOSA \n[23] SALTA \n[24] JUJUY");
                opcion_elegida = Console.ReadLine();

                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No ingreso ninguna provincia.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!opciones_validas.Contains(opcion_elegida.ToUpper().Trim()))
                {
                    Console.WriteLine("------------------------------------\nERROR - Ingreso una provincia inexistente!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }

            string rsp = "";
            switch (opcion_elegida)
            {
                case "1":
                    {
                        rsp = "CABA";
                        break;
                    }
                case "2":
                    {
                        rsp = "BUENOS AIRES";
                        break;
                    }
                case "3":
                    {
                        rsp = "CORDOBA";
                        break;
                    }
                case "4":
                    {
                        rsp = "SAN JUAN";
                        break;
                    }
                case "5":
                    {
                        rsp = "SAN LUIS";
                        break;
                    }
                case "6":
                    {
                        rsp = "SANTA CRUZ";
                        break;
                    }
                case "7":
                    {
                        rsp = "CHUBUT";
                        break;
                    }
                case "8":
                    {
                        rsp = "RIO NEGRO";
                        break;
                    }
                case "9":
                    {
                        rsp = "NEUQUEN";
                        break;
                    }
                case "10":
                    {
                        rsp = "LA PAMPA";
                        break;
                    }
                case "11":
                    {
                        rsp = "TIERRA DEL FUEGO";
                        break;
                    }
                case "12":
                    {
                        rsp = "MENDOZA";
                        break;
                    }
                case "13":
                    {
                        rsp = "LA RIOJA";
                        break;
                    }
                case "14":
                    {
                        rsp = "ENTRE RIOS";
                        break;
                    }
                case "15":
                    {
                        rsp = "SANTA FE";
                        break;
                    }
                case "16":
                    {
                        rsp = "CORRIENTES";
                        break;
                    }
                case "17":
                    {
                        rsp = "MISIONES";
                        break;
                    }
                case "18":
                    {
                        rsp = "CHACO";
                        break;
                    }
                case "19":
                    {
                        rsp = "CATAMARCA";
                        break;
                    }
                case "20":
                    {
                        rsp = "SANTIAGO DEL ESTERO";
                        break;
                    }
                case "21":
                    {
                        rsp = "TUCUMAN";
                        break;
                    }
                case "22":
                    {
                        rsp = "FORMOSA";
                        break;
                    }
                case "23":
                    {
                        rsp = "SALTA";
                        break;
                    }
                case "24":
                    {
                        rsp = "JUJUY";
                        break;
                    }

            }
            return rsp;

        }
        public static string MostrarConsultaDireccionNacional(string tipo_de_direccion)
        {
            string direccion_origen = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese su dirección de {tipo_de_direccion} de la siguiente forma: 'Calle, Altura, Departamento y Código Postal' ");
                direccion_origen = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(direccion_origen))
                {
                    Console.WriteLine("------------------------------------\nERROR - Deberá aclarar una direccion valida!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }
            return direccion_origen;
        }
        public static string MostrarConsultaRetiroEntrega(string opcion1, string opcion2)
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese un número según la opción de entrega o retiro que desee:\n------------------------------------");
                Console.WriteLine($"[1] {opcion1} \n[2] {opcion2}");
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

            string rsp = "";
            switch (opcion_elegida)
            {
                case "1":
                    {
                        rsp = $"{opcion1}";
                        break;
                    }
                case "2":
                    {
                        rsp = $"{opcion2}";
                        break;
                    }
            }
            return rsp;
        }

        public static string MostrarConsultaInternacional()
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");

            string rsp = "";
            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine("------------------------------------\n¿Desea enviar su encomienda/correspondencia dentro de Argentina?: \n[1] Si \n[2] No");
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

            switch (opcion_elegida)
            {
                case "1":
                    {
                        rsp = "Nacional";
                        break;
                    }
                case "2":
                    {
                        rsp = "Internacional";
                        break;
                    }
            }
            return rsp;
        }
        public static string MostrarConsultaRegionInternacional()
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");
            opciones_validas.Add("3");
            opciones_validas.Add("4");
            opciones_validas.Add("5");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese un número dependiendo del continente donde desea enviar su pedido: \n------------------------------------");
                Console.WriteLine("[1] PAISES LIMITROFES\n[2] AMERICA LATINA\n[3] AMERICA DEL NORTE\n[4] EUROPA \n[5] ASIA");
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

            string rsp;
            switch (opcion_elegida)
            {
                case "1":
                    {
                        rsp = $"PAISES LIMITROFE";
                        break;
                    }
                case "2":
                    {
                        rsp = $"AMERICA LATINA";
                        break;
                    }
                case "3":
                    {
                        rsp = $"AMERICA DEL NORTE";
                        break;
                    }
                case "4":
                    {
                        rsp = $"EUROPA";
                        break;
                    }
                case "5":
                    {
                        rsp = $"ASIA";
                        break;
                    }
                default:
                    rsp = "Sin Identificar";
                    break;
            }
            return rsp;
        }
        public static string MostrarConsultaDireccionInternacional()
        {
            string direccion_destino = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese la dirección de destino: 'Calle, Altura, Departamento, Ciudad y País' ");
                direccion_destino = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(direccion_destino))
                {
                    Console.WriteLine("------------------------------------\nERROR - Deberá aclarar una direccion valida!");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }
            return direccion_destino;
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

        public static void MostrarResumenPedido(int cantidad_encomiendas, decimal tarifa, string origen, string destino)
        {
            Random numero_pedido = new();
            Console.WriteLine($"------------------------------------\nRESUMEN DEL PEDIDO N°{numero_pedido.Next()}");



            if (cantidad_encomiendas == 1)
            {
                Console.WriteLine($"Encomienda/correspondencia a enviar: {cantidad_encomiendas} \nTarifa: ${(tarifa * cantidad_encomiendas)} \nOrigen: {origen} \nDestino: {destino}");
            }
            else
            {
                Console.WriteLine($"Encomiendas/correspondencias a enviar: {cantidad_encomiendas} \nTarifa: ${(tarifa * cantidad_encomiendas)} \nOrigen: {origen} \nDestino: {destino}");
            }



            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");

            string opcion_elegida;
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine("------------------------------------\nPor favor confirmar el pedido");
                Console.WriteLine("[1] Confirmar \n[2] Cancelar");
                opcion_elegida = Console.ReadLine();

                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion. Por favor seleccione una opcion!");
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
        }
    }
}
