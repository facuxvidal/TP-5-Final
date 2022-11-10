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
                    List<EncomiendaCorrespondencia> encomiendas = new List<EncomiendaCorrespondencia>();

                    decimal peso = 0;
                    int contador_encomiendas = 0;
                    string rsp_encomiendas = Menu.MostrarConsultaEncomiendas();
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
                            if (rsp_consulta_peso == "1")
                            {
                                peso = 0.5M;
                            }
                            else if (rsp_consulta_peso == "2")
                            {
                                peso = 10M;
                            }
                            else if (rsp_consulta_peso == "3")
                            {
                                peso = 20M;
                            }
                            else if (rsp_consulta_peso == "4")
                            {
                                peso = 30M;
                            }

                            encomiendas.Add(new EncomiendaCorrespondencia(contador_encomiendas, peso));
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
                    string direccion_origen;
                    string direccion_destino;
                    string region_internacional;
                    string direccion_internacional;
                    bool entrega_domicilio;
                    bool retiro_domicilio;
                    bool es_internacional;

                    Console.WriteLine("------------------------------------\nSELECCIONAR ORIGEN");
                    // Consulta direcion de Entrega o Retiro de ORIGEN
                    string provincia_origen = Menu.MostrarConsultaProvincia("ORIGEN");
                    string localidad_origen = Menu.MostrarConsultaLocalidadXProvincia(provincia_origen);
                    solicitud.Origen = $"{localidad_origen.ToUpper()}, {provincia_origen}";

                    string retiro_o_entrega_origen = Menu.MostrarConsultaRetiroEntrega("En sucursal", "A domicilio", "Retiro");
                    solicitud.TipoDeRetiro = retiro_o_entrega_origen;
                    if (retiro_o_entrega_origen == "A domicilio")
                    {
                        // Aca estoy pidiendo que lo pasen a buscar por mi casa
                        retiro_domicilio = true;
                        direccion_origen = Menu.MostrarConsultaDireccionNacional("ORIGEN");
                        solicitud.Origen = $"{direccion_origen}, {localidad_origen.ToUpper()}, {provincia_origen}";
                    }
                    else  
                    {
                        retiro_domicilio = false;
                        // Si no elegiste provincia que tenga sucursal, te va a decir que lo entregues en Agente Oficial Externo más cercano
                        if (provincia_origen != "CHACO" && provincia_origen != "RIO NEGRO" && provincia_origen != "CORDOBA" && provincia_origen != "CABA" && provincia_origen != "BUENOS AIRES")
                        {
                            origen = $"Agente Oficial Externo de: {localidad_origen}";
                        }
                        else 
                        {
                            // Si la provincia tiene sucursal, te va a mandar a ella
                            switch (provincia_origen)
                            {
                                case "CHACO":
                                    {
                                        origen = "Sucursal de RESISTENCIA";
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
                        solicitud.Origen = $"{origen}, {provincia_origen}";
                    }


                    Console.WriteLine("------------------------------------\nSELECCIONAR DESTINO");
                    // Consulta si el DESTINO es Nacional o Internacional
                    string pais_destino = Menu.MostrarConsultaInternacional();

                    // Consulta direcion de entrega o retiro DESTINO
                    if (pais_destino == "Nacional") 
                    {
                        // Si no es Internacional
                        es_internacional = false;
                        string provincia_destino = "";
                        string retiro_o_entrega_destino = Menu.MostrarConsultaRetiroEntrega("En sucursal", "A domicilio", "Entrega");
                        solicitud.TipoDeEntrega = retiro_o_entrega_destino;
                        if (retiro_o_entrega_destino == "A domicilio")
                        {
                            entrega_domicilio = true;
                            provincia_destino = Menu.MostrarConsultaProvincia("DESTINO");
                            string localidad_destino = Menu.MostrarConsultaLocalidadXProvincia(provincia_destino);
                            direccion_destino = Menu.MostrarConsultaDireccionNacional("DESTINO");
                            destino = $"{direccion_destino}, {localidad_destino.ToUpper()}, {provincia_destino}";
                            solicitud.Destino = destino;
                        }
                        else
                        {
                            entrega_domicilio = false;
                            provincia_destino = Menu.MostrarConsultaProvincia("DESTINO");
                            if (provincia_destino != "CHACO" && provincia_destino != "RIO NEGRO" && provincia_destino != "CORDOBA" && provincia_destino != "CABA" && provincia_destino != "BUENOS AIRES")
                            {
                                destino = $"{provincia_destino}";
                            }
                            else 
                            {
                                // Si la provincia tiene sucursal, te va a mandar a ella
                                switch (provincia_destino)
                                {
                                    case "CHACO":
                                        {
                                            destino = $"Sucursal de RESISTENCIA, {provincia_destino}";
                                            break;
                                        }
                                    case "RIO NEGRO":
                                        {
                                            destino = $"Sucursal de VIEDMA, {provincia_destino}";
                                            break;
                                        }
                                    case "CORDOBA":
                                        {
                                            destino = $"Sucursal de CORDOBA, {provincia_destino}";
                                            break;
                                        }
                                    case "CABA":
                                        {
                                            destino = $"Sucursal de CABA, {provincia_destino}";
                                            break;
                                        }
                                    case "BUENOS AIRES":
                                        {
                                            destino = $"Sucursal de CABA, {provincia_destino}";
                                            break;
                                        }
                                }
                            }
                            solicitud.Destino = destino;
                        }
                    }
                    else
                    {
                        // Si es Internacional
                        es_internacional = true;
                        entrega_domicilio = true;
                        solicitud.TipoDeEntrega = "A domicilio";
                        region_internacional = Menu.MostrarConsultaRegionInternacional();
                        direccion_internacional = Menu.MostrarConsultaDireccionInternacional();
                        destino = $"{direccion_internacional}, {region_internacional}";
                        solicitud.Destino = destino;
                    }

                    // CALCULAR PRECIO BULTO SEGÚN PROVINCIAL/REGIONAL, NACIONAL Y PESO.
                    Tarifa tarifa = new Tarifa(es_internacional, urgente, retiro_domicilio, entrega_domicilio);
                    //float tarifa1 = Tarifa.Calcular(tarifa.RecargoRetiroEnPuerta, tarifa.RecargoEntregaEnPuerta, tarifa.RecargoUrgente, solicitud.Origen, solicitud.Destino, tarifa.EsInternacional, encomienda.Peso);
                    Tarifa.Calcular2(tarifa, solicitud, encomiendas);

                    // MOSTRAR RESUMEN - FALTA CALCULAR TARIFA
                    //Menu.MostrarResumenPedido(contador_encomiendas, tarifa1, origen, destino, solicitud.NumeroOrdenServicio); // tarifa.MontoTotal

                    
                    // CREAR ORDEN DE SERVICIO UNA VEZ CONFIRMADO
                    OrdenDeServicio orden = new OrdenDeServicio(solicitud.NumeroOrdenServicio, urgente, solicitud.Fecha, solicitud.Fecha.AddDays(7), "En curso");

                    // genera factura

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
