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
        public static string MostrarConsultaDireccionNacional(string tipo_de_direccion)
        {
            string direccion_origen = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese su dirección de {tipo_de_direccion}: Calle, Altura, Departamento y Código Postal");
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
        public static string MostrarConsutaProvincia(string ubicacion)
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("CABA");
            opciones_validas.Add("BUENOS AIRES");
            opciones_validas.Add("CORDOBA");
            opciones_validas.Add("SAN JUAN");
            opciones_validas.Add("SAN LUIS");
            opciones_validas.Add("SANTA CRUZ");
            opciones_validas.Add("CHUBUT");
            opciones_validas.Add("RIO NEGRO");
            opciones_validas.Add("NEUQUEN");
            opciones_validas.Add("LA PAMPA");
            opciones_validas.Add("TIERRA DEL FUEGO");
            opciones_validas.Add("MENDOZA");
            opciones_validas.Add("LA RIOJA");
            opciones_validas.Add("ENTRE RIOS");
            opciones_validas.Add("SANTA FE");
            opciones_validas.Add("CORRIENTES");
            opciones_validas.Add("MISIONES");
            opciones_validas.Add("CHACO");
            opciones_validas.Add("CATAMARCA");
            opciones_validas.Add("SANTIAGO DEL ESTERO");
            opciones_validas.Add("TUCUMAN");
            opciones_validas.Add("FORMOSA");
            opciones_validas.Add("SALTA");
            opciones_validas.Add("JUJUY");


            string opcion_elegida = "";
            bool bandera = true;

            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese la provincia de {ubicacion} (sin tildes):  ");
                opcion_elegida = Console.ReadLine();

                if (String.IsNullOrEmpty(opcion_elegida))
                {
                    Console.WriteLine("------------------------------------\nERROR - No ingreso ninguna provincia.");
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
            return opcion_elegida;

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
        public static string MostrarConsultaRetiroEntrega(string opcion1, string opcion2)
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese un número según la opción de entrega/retiro que desee:\n------------------------------------");
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

            string rsp;
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
                default:
                    rsp = "Sin Identificar";
                    break;
            }
            return rsp;
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
        public static string MostrarConsultaInternacional()
        {
            string opcion_elegida = "";
            bool flag = true;
            string rsp = "";
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");

            while (flag)
            {
                Console.WriteLine("¿Desea enviar su encomienda/correspondencia dentro de Argentina?: \n[1] SI \n[2] NO");
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
                    flag = false;
                }
            }

            if (opcion_elegida == "1")
            {
                rsp = "Argentina";
            }
            else if (opcion_elegida == "2")
            {
                bool flag2 = true;
                while (flag2)
                {
                    Console.WriteLine("Ingrese el Pais de destino:  ");
                    rsp = Console.ReadLine();
                    if (String.IsNullOrEmpty(rsp))
                    {
                        Console.WriteLine("------------------------------------\nERROR - No seleccionó ninguna opcion.");
                        Console.WriteLine("------------------------------------\nIntente nuevamente!");
                    }
                    else
                    {
                        flag2 = false;
                    }
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
                Console.WriteLine($"------------------------------------\nIngrese la dirección de destino: Calle, Altura, Departamento, Ciudad y País ");
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
