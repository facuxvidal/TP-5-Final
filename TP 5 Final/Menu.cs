using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
                opcion_elegida = Console.ReadLine().Trim();

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
                encomiendas = Console.ReadLine().Trim();

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
                opcion_elegida = Console.ReadLine().Trim();

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
                opcion_elegida = Console.ReadLine().Trim();

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

        public static string MostrarConsutaSeguimiento()
        {
            string numero_orden = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine("------------------------------------\nIngrese el Numero de Orden De Servicio que desea consultar:");
                numero_orden = Console.ReadLine().Trim();

                if (String.IsNullOrEmpty(numero_orden))
                {
                    Console.WriteLine("------------------------------------\nERROR - Ingrese un número.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else if (!ValidaEntero(numero_orden))
                {
                    Console.WriteLine("------------------------------------\nERROR - No se pudo validar el numero ingresado.");
                    Console.WriteLine("------------------------------------\nIntente nuevamente!");
                }
                else
                {
                    bandera = false;
                }
            }
            return numero_orden;
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
                    opcion_elegida = Console.ReadLine().Trim();

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

        public static List<DateTime> MostrarConsultaFechas()
        {
            List<DateTime> fechas = new List<DateTime>();
            bool bandera_desde = true;
            bool bandera_hasta = true;

            Console.WriteLine("------------------------------------\nPara ver el historial de Facturas, ingrese el periodo de fechas que quiera consultar.");

            while (bandera_desde)
            {
                Console.WriteLine("------------------------------------\nIngresar Fecha Desde (DD/MM/YYYY):");
                string fecha_desde = Console.ReadLine().Trim();
                try
                {
                    DateTime fecha_desde_ok = DateTime.ParseExact(fecha_desde, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    fechas.Add(fecha_desde_ok);
                    bandera_desde = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("------------------------------------\nERROR - Por favor ingresar una fecha valida rspetando el formato 'DD/MM/YYYY'");
                    continue;
                }
            }

            while (bandera_hasta)
            {
                Console.WriteLine("------------------------------------\nIngresar Fecha Hasta (DD/MM/YYYY):");
                string fecha_hasta = Console.ReadLine().Trim();
                try
                {
                    DateTime fecha_hasta_ok = DateTime.ParseExact(fecha_hasta, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    fechas.Add(fecha_hasta_ok);
                    bandera_hasta = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("------------------------------------\nERROR - Por favor ingresar una fecha valida rspetando el formato 'DD/MM/YYYY'");
                    continue;
                }
            }
            return fechas;
        }

        /*public static string MostrarConsultaProvinciaVieja(string ubicacion)
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
        }*/

        public static string MostrarConsultaProvincia(string ubicacion)
        {
            string provincia_por_provincia = Path.GetFullPath("..\\..\\..\\Provincias.txt");
            FileInfo FI = new FileInfo(provincia_por_provincia);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(provincia_por_provincia);
            int contador_lineas = 0;
            string opcion_elegida = "";
            string rsp = "";
            while (!SR.EndOfStream)
            {
                SR.ReadLine();
                var provincias = lineas[contador_lineas].Split('|');
                List<string> opciones_validas = new List<string>();
                int agrego_nueva_opcion = 0;
                foreach (string item in provincias)
                {
                    opciones_validas.Add($"{agrego_nueva_opcion}");
                    agrego_nueva_opcion++;
                }

                bool bandera = true;
                while (bandera)
                {
                    Console.WriteLine($"------------------------------------\nIngrese un número segun la Provincia de {ubicacion} que corresponda:  ");
                    ;
                    int una_provincia = 1;
                    foreach (var item in provincias)
                    {
                        if (agrego_nueva_opcion != una_provincia)
                        {
                            Console.WriteLine($"[{una_provincia}] {provincias[una_provincia]}");
                            una_provincia++;
                        }
                    }

                    opcion_elegida = Console.ReadLine().Trim();
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
                rsp = provincias[int.Parse(opcion_elegida)];
                break;

            }
            SR.Close();
            return rsp;
        }

        public static string MostrarConsultaLocalidadXProvincia(string provincia)
        {
            string localidades_por_provincia = Path.GetFullPath("..\\..\\..\\LocalidadesXProvincia.txt");
            FileInfo FI = new FileInfo(localidades_por_provincia);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(localidades_por_provincia);
            int contador_lineas = 0;
            string opcion_elegida = "";
            string rsp = "";
            while (!SR.EndOfStream)
            {
                SR.ReadLine();
                var localidades = lineas[contador_lineas].Split('|');
                if (localidades[0] == provincia)
                {
                    List<string> opciones_validas = new List<string>();
                    int agrego_nueva_opcion = 0;
                    foreach (string item in localidades)
                    {
                        opciones_validas.Add($"{agrego_nueva_opcion}");
                        agrego_nueva_opcion++;
                    }

                    bool bandera = true;
                    while (bandera)
                    {
                        Console.WriteLine($"------------------------------------\nIngrese la localidad que corresponda: \n------------------------------------");
                        int una_localidad = 1;
                        foreach (var item in localidades)
                        {
                            if (agrego_nueva_opcion != una_localidad)
                            {
                                Console.WriteLine($"[{una_localidad}] {localidades[una_localidad]}");
                                una_localidad++;
                            }
                        }

                        opcion_elegida = Console.ReadLine().Trim();
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
                    rsp = localidades[int.Parse(opcion_elegida)];
                    break;
                }
                else
                {
                    contador_lineas++;
                }
            }
            SR.Close();
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

        public static string MostrarConsultaRetiroEntrega(string opcion1, string opcion2, string tipo_de_envio)
        {
            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese un número según la opción de {tipo_de_envio} que desee:\n------------------------------------");
                Console.WriteLine($"[1] {opcion1} \n[2] {opcion2}");
                opcion_elegida = Console.ReadLine().Trim();

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
                opcion_elegida = Console.ReadLine().Trim();
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
                Console.WriteLine($"------------------------------------\n¿Hacia que parte del mundo desea enviar su pedido? Ingrese un número segun corresponda: \n------------------------------------");
                Console.WriteLine("[1] A PAISES LIMITROFES\n[2] AMERICA LATINA\n[3] AMERICA DEL NORTE\n[4] EUROPA \n[5] ASIA");
                opcion_elegida = Console.ReadLine().Trim();

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
                        rsp = $"PAISES LIMITROFES";
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
            }
            return rsp;
        }

        public static string MostrarConsultaPaisInternacional(string region)
        {
            string paises_por_region = Path.GetFullPath("..\\..\\..\\PaisesXRegion.txt");
            FileInfo FI = new FileInfo(paises_por_region);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(paises_por_region);
            int contador_lineas = 0;
            string opcion_elegida = "";
            string rsp = "";
            while (!SR.EndOfStream)
            {
                SR.ReadLine();
                var paises = lineas[contador_lineas].Split('|');
                if (paises[0] == region)
                {
                    List<string> opciones_validas = new List<string>();
                    int agrego_nueva_opcion = 0;
                    foreach (string item in paises)
                    {
                        opciones_validas.Add($"{agrego_nueva_opcion}");
                        agrego_nueva_opcion++;
                    }

                    bool bandera = true;
                    while (bandera)
                    {
                        Console.WriteLine($"------------------------------------\nIngrese la localidad que corresponda: \n------------------------------------");
                        int un_pais = 1;
                        foreach (var item in paises)
                        {
                            if (agrego_nueva_opcion != un_pais)
                            {
                                Console.WriteLine($"[{un_pais}] {paises[un_pais]}");
                                un_pais++;
                            }
                        }

                        opcion_elegida = Console.ReadLine().Trim();
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
                    rsp = paises[int.Parse(opcion_elegida)];
                    break;
                }
                else
                {
                    contador_lineas++;
                }
            }
            SR.Close();
            return rsp;
        }

        public static string MostrarConsultaDireccionInternacional()
        {
            string direccion_destino = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine($"------------------------------------\nIngrese la dirección de destino: 'Calle, Altura, Departamento y Ciudad' ");
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

        public static string MostrarResumenPedido(int cantidad_encomiendas, decimal tarifa, string origen, string destino)
        {
            Console.WriteLine($"------------------------------------\nRESUMEN DEL PEDIDO");

            if (cantidad_encomiendas == 1)
            {
                Console.WriteLine($"Encomienda/correspondencia a enviar: {cantidad_encomiendas} \nTarifa: ${(tarifa)} \nOrigen: {origen} \nDestino: {destino}");
            }
            else
            {
                Console.WriteLine($"Encomiendas/correspondencias a enviar: {cantidad_encomiendas} \nTarifa: ${(tarifa)} \nOrigen: {origen} \nDestino: {destino}");
            }

            List<string> opciones_validas = new List<string>();
            opciones_validas.Add("1");
            opciones_validas.Add("2");

            string opcion_elegida = "";
            bool bandera = true;
            while (bandera)
            {
                Console.WriteLine("------------------------------------\nPor favor confirmar el pedido");
                Console.WriteLine("[1] Confirmar \n[2] Cancelar");
                opcion_elegida = Console.ReadLine().Trim();

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
            return opcion_elegida;
        }
    }
}
