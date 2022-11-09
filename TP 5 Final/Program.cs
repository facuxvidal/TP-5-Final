using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------\nBIENVENIDO\n------------------------------------");
            Cliente cliente = new Cliente();
            cliente = cliente.LogIn();
            if (!cliente.EsCorporativo)
            {
                Console.WriteLine("------------------------------------\nLo sentimos pero esta apliacion no esta hecha para usted.\nHasta Luego!");
                Console.ReadLine();
            }
            else
            {
                cliente.MostrarDatos();
                string rsp_principal = Menu.MostrarPrincipal();
                if (rsp_principal == "1")
                {
                    Random numero_orden_servicio = new Random();
                    SolicitudDeServicio solicitud = new SolicitudDeServicio(numero_orden_servicio.Next(), DateTime.Now);

                    string rsp_encomiendas = Menu.MostrarConsultaEncomiendas();
                    int contador_encomiendas = 0;
                    do
                    {
                        string rsp_consulta_peso = Menu.MostrarConsutaPeso(contador_encomiendas);
                        List<string> respuestas_validas_peso = new List<string>();
                        respuestas_validas_peso.Add("1");
                        respuestas_validas_peso.Add("2");
                        respuestas_validas_peso.Add("3");
                        respuestas_validas_peso.Add("4");

                        if (respuestas_validas_peso.Contains(rsp_consulta_peso))
                        {
                            contador_encomiendas++;
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------\nLo sentimos pero nuestro servicio solo admite encomiendas menores a 30 kg.");
                            string rsp_consulta_salir = Menu.MostrarConsultaDeseaSalir();
                            if (rsp_consulta_salir == "1")
                            {
                                // Igualo las variables para forzar salir de la ejecucion del programa
                                rsp_encomiendas = "0";
                                contador_encomiendas = 0;
                            }
                        }

                    } while (Convert.ToInt32(rsp_encomiendas) != contador_encomiendas);


                    bool urgente = Menu.MostrarConsultaUrgencia(); // cargar este dato a la propiedad "EsPrioridad" de una orden de servicio instanciada

                    string origen = "";
                    string destino = "";
                    string sucursal_de_retiro;
                    string sucursal_de_entrega;
                    string direccion_origen;
                    string provincia_destino;
                    string direccion_destino;
                    string region_internacional;
                    string direccion_internacional;
                    bool entrega_domicilio;
                    bool retiro_domicilio;

                    Console.WriteLine("------------------------------------\nSELECCIONAR ORIGEN");
                    // Consulta direcion de entrega o retiro ORIGEN
                    string provincia_origen = Menu.MostrarConsultaProvincia("origen");
                    solicitud.Origen = provincia_origen;

                    string retiro_o_entrega = Menu.MostrarConsultaRetiroEntrega("Dejarlo en sucursal", "Recoleccion a domicilio");
                    if (retiro_o_entrega == "Recoleccion a domicilio")
                    {
                        // aca estoy pidiendo que lo pasen a buscar por mi casa
                        direccion_origen = Menu.MostrarConsultaDireccionNacional("origen");
                        origen = $"{direccion_origen}, {provincia_origen}";
                        retiro_domicilio = true;
                    }
                    else  //Si no elegiste provincia que tenga sucursal, te va a decir que lo entregues en agente externo más cercano
                    {
                        if (provincia_origen != "CHACO" && provincia_origen != "RIO NEGRO" && provincia_origen != "CORDOBA" && provincia_origen != "CABA" && provincia_origen != "BUENOS AIRES")
                        {
                            origen = $"Punto de venta externo más cercano en {provincia_origen}";
                        }
                        else //Si la provincia tiene sucursal, te va a mandar a ella.
                        {
                            switch (provincia_origen)
                            {
                                case "CHACO":
                                    {
                                        origen = "Sucursal de Resistencia";
                                        break;
                                    }
                                case "RIO NEGRO":
                                    {
                                        origen = "Sucursal de VIEDMA";
                                        break;
                                    }
                                case "CORDOBA":
                                    {
                                        origen = "Sucursal de CORDOBA";
                                        break;
                                    }
                                case "CABA":
                                    {
                                        origen = "Sucursal de CABA";
                                        break;
                                    }
                                case "BUENOS AIRES":
                                    {
                                        origen = "Sucursal de CABA";
                                        break;
                                    }
                            }
                        }
                        retiro_domicilio = false;
                    }


                    Console.WriteLine("------------------------------------\nSELECCIONAR DESTINO");
                    // Consulta si el DESTINO es NACIONAL o INTERNACIONAL
                    string pais_destino = Menu.MostrarConsultaInternacional();

                    // Consulta direcion de entrega o retiro DESTINO
                    if (pais_destino == "Nacional") // Si no es Internacional
                    {
                        retiro_o_entrega = Menu.MostrarConsultaRetiroEntrega("Retirar en sucursal", "Entregar a domicilio");
                        if (retiro_o_entrega == "Entregar a domicilio")
                        {
                            provincia_destino = Menu.MostrarConsultaProvincia("destino");
                            direccion_destino = Menu.MostrarConsultaDireccionNacional("destino");
                            destino = $"{direccion_destino}, {provincia_destino}, {pais_destino}";
                            entrega_domicilio = true;
                        }
                        else
                        {
                            entrega_domicilio = false;
                            provincia_destino = Menu.MostrarConsultaProvincia("destino");
                            if (provincia_destino != "CHACO" || provincia_destino != "RIO NEGRO" || provincia_destino != "CORDOBA" || provincia_destino != "CABA" || provincia_destino != "BUENOS AIRES")
                            {
                                destino = $"Punto de venta externo más cercano en {provincia_destino}";
                            }
                            else //Si la provincia tiene sucursal, te va a mandar a ella.
                            {
                                switch (provincia_destino)
                                {
                                    case "CHACO":
                                        {
                                            destino = "Sucursal de Resistencia";
                                            break;
                                        }
                                    case "RIO NEGRO":
                                        {
                                            destino = "Sucursal de VIEDMA";
                                            break;
                                        }
                                    case "CORDOBA":
                                        {
                                            destino = "Sucursal de CORDOBA";
                                            break;
                                        }
                                    case "CABA":
                                        {
                                            destino = "Sucursal de CABA";
                                            break;
                                        }
                                    case "BUENOS AIRES":
                                        {
                                            destino = "Sucursal de CABA";
                                            break;
                                        }
                                    default:
                                        destino = "Sin Identificar";
                                        break;
                                }
                            }
                        }
                    }
                    else // Si es Internacional
                    {
                        region_internacional = Menu.MostrarConsultaRegionInternacional();
                        direccion_internacional = Menu.MostrarConsultaDireccionInternacional();
                        destino = $"{direccion_internacional}, {region_internacional}";
                        entrega_domicilio = true;
                    }

                    // CALCULAR PRECIO BULTO SEGÚN PROVINCIAL/REGIONAL, NACIONAL Y PESO.
                    float precio_bulto = 0f;
                    decimal tarifa = Tarifa.Calcular(retiro_domicilio, entrega_domicilio, urgente, precio_bulto);

                    // MOSTRAR RESUMEN - FALTA CALCULAR TARIFA
                    Menu.MostrarResumenPedido(Convert.ToInt32(contador_encomiendas), tarifa, origen, destino);


                    Console.WriteLine("Muchas gracias por utilizar nuestra aplicación! Esperamos verlo pronto!");
                    Console.WriteLine("Presione [Enter] para salir");
                    Console.ReadLine();
                }
                else if (rsp_principal == "2")
                {
                    CuentaCliente saldo_cliente = new CuentaCliente();
                    string rsp_consulta_saldo = saldo_cliente.ConsultarSaldo(cliente);
                    if (rsp_consulta_saldo != "") // Si es diferente de "", preguntamos si quiere salir
                    {
                        Console.WriteLine(rsp_consulta_saldo);
                        string rsp_consulta_salir = Menu.MostrarConsultaDeseaSalir();
                        if (rsp_consulta_salir == "1")
                        {
                            // Igualo las variables para forzar salir de la ejecucion del programa
                        }
                    }

                    else
                    {
                        Console.WriteLine("Muchas gracias por utilizar nuestra aplicación! Esperamos verlo pronto!");
                        Console.WriteLine("Presione [Enter] para salir");
                        Console.ReadLine();
                    }
                }
                else if (rsp_principal == "3")
                {

                }
                else if (rsp_principal == "4")
                {
                    Console.WriteLine("Hasta luego!");
                    Console.WriteLine("Muchas gracias por utilizar nuestra aplicación! Esperamos verlo pronto!");
                    Console.WriteLine("Presione [Enter] para salir");
                    Console.ReadLine();
                }
            }
        }
    }
}
