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

                    int id_correspondencia = 0;
                    float peso = 0f;
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
                        if (rsp_consulta_peso == "1")
                        {
                            peso = 0.5f;
                        }
                        else if (rsp_consulta_peso == "2")
                        {
                            peso = 10f;
                        }
                        else if (rsp_consulta_peso == "3")
                        {
                            peso = 20f;
                        }
                        else if (rsp_consulta_peso == "4")
                        {
                            peso = 30f;
                        }
                    } while (Convert.ToInt32(rsp_encomiendas) != contador_encomiendas);

                    EncomiendaCorrespondencia encomienda = new EncomiendaCorrespondencia(id_correspondencia++, peso);


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
                    bool internacional;

                    Console.WriteLine("------------------------------------\nSELECCIONAR ORIGEN");
                    // Consulta direcion de entrega o retiro ORIGEN
                    string provincia_origen = Menu.MostrarConsultaProvincia("origen");
                    solicitud.Origen = provincia_origen;

                    string retiro_o_entrega_origen = Menu.MostrarConsultaRetiroEntrega("Dejarlo en sucursal", "Recoleccion a domicilio");
                    solicitud.TipoDeRetiro = retiro_o_entrega_origen;
                    if (retiro_o_entrega_origen == "Recoleccion a domicilio")
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
                            origen = $"{provincia_origen}";
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
                        internacional = false;
                        string retiro_o_entrega_destino = Menu.MostrarConsultaRetiroEntrega("Retirar en sucursal", "Entregar a domicilio");
                        solicitud.TipoDeEntrega = retiro_o_entrega_destino;
                        if (retiro_o_entrega_destino == "Entregar a domicilio")
                        {
                            provincia_destino = Menu.MostrarConsultaProvincia("destino");
                            direccion_destino = Menu.MostrarConsultaDireccionNacional("destino");
                            destino = $"{direccion_destino}, {provincia_destino}, {pais_destino}";
                            entrega_domicilio = true;
                            solicitud.Destino = destino;
                        }
                        else
                        {
                            entrega_domicilio = false;
                            provincia_destino = Menu.MostrarConsultaProvincia("destino");
                            if (provincia_destino != "CHACO" || provincia_destino != "RIO NEGRO" || provincia_destino != "CORDOBA" || provincia_destino != "CABA" || provincia_destino != "BUENOS AIRES")
                            {
                                destino = $"{provincia_destino}";
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
                            solicitud.Destino = provincia_destino;
                        }
                    }
                    // Si es Internacional
                    else
                    {
                        internacional = true;
                        solicitud.TipoDeEntrega = "Entregar a domicilio";
                        region_internacional = Menu.MostrarConsultaRegionInternacional();
                        direccion_internacional = Menu.MostrarConsultaDireccionInternacional();
                        destino = $"{region_internacional}, {direccion_internacional}";
                        entrega_domicilio = true;
                        solicitud.Destino = region_internacional;
                    }
                    


                    // CALCULAR PRECIO BULTO SEGÚN PROVINCIAL/REGIONAL, NACIONAL Y PESO.
                    float precio_bulto = 0f;
                    Tarifa tarifa = new Tarifa(internacional, urgente, retiro_domicilio, entrega_domicilio);
                    float tarifa1 = Tarifa.Calcular(tarifa.RecargoRetiroEnPuerta, tarifa.RecargoEntregaEnPuerta, tarifa.RecargoUrgente, solicitud.Origen, solicitud.Destino, tarifa.EsInternacional, encomienda.Peso);


                    // MOSTRAR RESUMEN - FALTA CALCULAR TARIFA
                    Menu.MostrarResumenPedido(Convert.ToInt32(contador_encomiendas), tarifa1, origen, destino, solicitud.NumeroOrdenServicio);


                    // CREAR ORDEN DE SERVICIO UNA VEZ CONFIRMADO
                    OrdenDeServicio orden = new OrdenDeServicio(solicitud.NumeroOrdenServicio, urgente, solicitud.Fecha, solicitud.Fecha.AddDays(7), "En curso");

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
