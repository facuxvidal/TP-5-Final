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

        public static string MostrarConsultaPeso(int encomiendas)
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
            string region_internacional = Path.GetFullPath("..\\..\\..\\RegionesInternacionales.txt");
            FileInfo FI = new FileInfo(region_internacional);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(region_internacional);
            int contador_lineas = 0;
            string opcion_elegida = "";
            string rsp = "";
            while (!SR.EndOfStream)
            {
                SR.ReadLine();
                var regiones = lineas[contador_lineas].Split('|');
                List<string> opciones_validas = new List<string>();
                int agrego_nueva_opcion = 0;
                foreach (string region in regiones)
                {
                    opciones_validas.Add($"{agrego_nueva_opcion}");
                    agrego_nueva_opcion++;
                }

                bool bandera = true;
                while (bandera)
                {
                    Console.WriteLine($"------------------------------------\n¿Hacia que parte del mundo desea enviar su pedido? Ingrese un número segun corresponda: \n------------------------------------");
                    int una_region = 1;
                    foreach (var region in regiones)
                    {
                        if (agrego_nueva_opcion != una_region)
                        {
                            Console.WriteLine($"[{una_region}] {regiones[una_region]}");
                            una_region++;
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
                rsp = regiones[int.Parse(opcion_elegida)];
                break;

            }
            SR.Close();
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
                        Console.WriteLine($"------------------------------------\nIngrese el pais hacia donde desea enviar el pedido: \n------------------------------------");
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
            long entero_validado;

            if (!long.TryParse(numero, out entero_validado))
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
