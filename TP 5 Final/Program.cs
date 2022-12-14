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
                bool vuelvo_atras = true;
                do
                {
                    string rsp_principal = Menu.MostrarPrincipal();
                    if (rsp_principal == "1")
                    {
                        Random numero_orden_servicio = new Random();
                        SolicitudDeServicio solicitud = new SolicitudDeServicio(numero_orden_servicio.Next(), DateTime.Now.Date, cliente.CUIT.ToString());
                        List<EncomiendaCorrespondencia> encomiendas = new List<EncomiendaCorrespondencia>();

                        decimal peso = 0;
                        int contador_encomiendas = 0;
                        string rsp_encomiendas = Menu.MostrarConsultaEncomiendas();
                        do
                        {
                            string rsp_consulta_peso = Menu.MostrarConsultaPeso(contador_encomiendas);
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
                                    Console.WriteLine("Hasta luego!");
                                    Console.WriteLine("Muchas gracias por utilizar nuestra aplicación! Esperamos verlo pronto!");
                                    Console.WriteLine("Presione [Enter] para salir");
                                    Console.ReadLine();
                                    Environment.Exit(0);
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
                        string pais_internacional;
                        bool entrega_domicilio;
                        bool retiro_domicilio;
                        bool es_internacional;
                        string ubicacion = "";
                        string precio_internacional = "";

                        Console.WriteLine("------------------------------------\nSELECCIONAR ORIGEN");
                        // Consulta direcion de Entrega o Retiro de ORIGEN
                        string provincia_origen = Menu.MostrarConsultaProvincia("ORIGEN");
                        string localidad_origen = Menu.MostrarConsultaLocalidadXProvincia(provincia_origen);

                        string retiro_o_entrega_origen = Menu.MostrarConsultaRetiroEntrega("En sucursal", "A domicilio", "Recoleccion");
                        solicitud.TipoDeRetiro = retiro_o_entrega_origen;
                        if (retiro_o_entrega_origen == "A domicilio")
                        {
                            // Pidiendo que lo pasen a buscar por casa
                            retiro_domicilio = true;
                            direccion_origen = Menu.MostrarConsultaDireccionNacional("ORIGEN");
                            origen = $"{direccion_origen}, {localidad_origen.ToUpper()}, {provincia_origen}";
                        }
                        else
                        {
                            retiro_domicilio = false;
                            // Si no elegiste provincia que tenga sucursal, te va a decir que lo entregues en Agente Oficial Externo más cercano
                            if (provincia_origen != "CHACO" && provincia_origen != "RIO NEGRO" && provincia_origen != "CORDOBA" && provincia_origen != "CABA" && provincia_origen != "BUENOS AIRES")
                            {
                                origen = $"Agente Oficial Externo de {localidad_origen}, {provincia_origen}";
                            }
                            else
                            {
                                // Si la provincia tiene sucursal, te va a mandar a ella
                                switch (provincia_origen)
                                {
                                    case "CHACO":
                                        {
                                            origen = $"Sucursal de RESISTENCIA, {provincia_origen}";
                                            break;
                                        }
                                    case "RIO NEGRO":
                                        {
                                            origen = $"Sucursal de VIEDMA, {provincia_origen}";
                                            break;
                                        }
                                    case "CORDOBA":
                                        {
                                            origen = $"Sucursal de CORDOBA, {provincia_origen}";
                                            break;
                                        }
                                    case "CABA":
                                        {
                                            origen = $"Sucursal de CABA, {provincia_origen}";
                                            break;
                                        }
                                    case "BUENOS AIRES":
                                        {
                                            origen = $"Sucursal de CABA, {provincia_origen}";
                                            break;
                                        }
                                }
                            }
                        }
                        solicitud.Origen = $"{origen}";


                        Console.WriteLine("------------------------------------\nSELECCIONAR DESTINO");
                        // Consulta si el DESTINO es Nacional o Internacional
                        string pais_destino = Menu.MostrarConsultaInternacional();
                        string localidad_destino = "";
                        // Consulta direcion de entrega o retiro DESTINO
                        string provincia_destino = "";

                        if (pais_destino == "Nacional")
                        {
                            // Si no es Internacional
                            es_internacional = false;
                            string retiro_o_entrega_destino = Menu.MostrarConsultaRetiroEntrega("En sucursal", "A domicilio", "Entrega");
                            solicitud.TipoDeEntrega = retiro_o_entrega_destino;
                            if (retiro_o_entrega_destino == "A domicilio")
                            {
                                entrega_domicilio = true;
                                provincia_destino = Menu.MostrarConsultaProvincia("DESTINO");
                                localidad_destino = Menu.MostrarConsultaLocalidadXProvincia(provincia_destino);
                                direccion_destino = Menu.MostrarConsultaDireccionNacional("DESTINO");
                                destino = $"{direccion_destino}, {localidad_destino.ToUpper()}, {provincia_destino}";
                                solicitud.Destino = destino;
                            }
                            else
                            {
                                entrega_domicilio = false;
                                provincia_destino = Menu.MostrarConsultaProvincia("DESTINO");
                                localidad_destino = Menu.MostrarConsultaLocalidadXProvincia(provincia_destino);
                                if (provincia_destino != "CHACO" && provincia_destino != "RIO NEGRO" && provincia_destino != "CORDOBA" && provincia_destino != "CABA" && provincia_destino != "BUENOS AIRES")
                                {
                                    destino = $"{localidad_destino.ToUpper()}, {provincia_destino}";
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
                        // Si es Internacional
                        else
                        {
                            es_internacional = true;
                            entrega_domicilio = true;
                            solicitud.TipoDeEntrega = "A domicilio";
                            region_internacional = Menu.MostrarConsultaRegionInternacional();
                            pais_internacional = Menu.MostrarConsultaPaisInternacional(region_internacional);
                            direccion_internacional = Menu.MostrarConsultaDireccionInternacional();
                            destino = $"{direccion_internacional}, {pais_internacional}";
                            solicitud.Destino = destino;
                            ubicacion = region_internacional;
                        }

                        Tarifa tarifa = new Tarifa(es_internacional, urgente, retiro_domicilio, entrega_domicilio);

                        // Si ubicacion esta vacio es porque es un pedido Nacional
                        // En este caso, consultamos en que a que region corresponde enviar el pedido, si es LOCAL, PROVINCIAL, REGIONAL o NACIONAL
                        // En el caso de ser un pedido Internacional, ubicacion toma el valor de PAISES LIMITROFES, AMERICA LATINA, AMERICA DEL NORTE, EUROPA o ASIA
                        if (ubicacion == "")
                        {
                            ubicacion = EncomiendaCorrespondencia.ConsultaRegionPorUbicacion(localidad_origen, localidad_destino, provincia_origen, provincia_destino);
                            Tarifa.Calcular(tarifa, encomiendas, ubicacion, "");
                        }
                        else // Calculamos precio por peso de la encomienda/s segun Region: LOCAL,PROVINCIAL,REGIONAL,NACIONAL.
                        {
                            precio_internacional = EncomiendaCorrespondencia.ConsultaRegionPorUbicacionInternacional(provincia_origen, "CABA");
                            Tarifa.Calcular(tarifa, encomiendas, ubicacion, precio_internacional);
                        }
                        


                        // Muestra resumen y pide confirmación
                        string confirmacion = Menu.MostrarResumenPedido(contador_encomiendas, tarifa.MontoTotal, origen, destino);
                        if (confirmacion == "1")
                        {
                            OrdenDeServicio orden = solicitud.GenerarOrdenDeServicio(solicitud.NumeroOrdenServicio, tarifa.RecargoUrgente, solicitud.Fecha, solicitud.Fecha.AddDays(7), "En curso", solicitud.Origen, solicitud.Destino, cliente.CUIT);
                            Factura factura = new Factura();
                            factura.GenerarFactura(tarifa.MontoTotal, contador_encomiendas, cliente.CUIT);
                            Console.WriteLine($"------------------------------------\n¡SE HA GENERADO UN NUEVO PEDIDO CON N°ORDEN DE SERVICIO: {orden.NumeroOrden}, MUCHAS GRACIAS POR UTILIZAR NUESTRO SISTEMA!");
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------\n¡HA CANCELADO EL REGISTRO DE NUEVO PEDIDO!");
                            string rsp_consulta_salir = Menu.MostrarConsultaDeseaSalir();
                            if (rsp_consulta_salir == "1")
                            {
                                vuelvo_atras = false;
                                Console.WriteLine("Hasta luego!");
                                Console.WriteLine("Muchas gracias por utilizar nuestra aplicación! Esperamos verlo pronto!");
                                Console.WriteLine("Presione [Enter] para salir");
                                Console.ReadLine();
                            }
                        }
                    }
                    else if (rsp_principal == "2")
                    {
                        // Pedimos fechas para consultar facturas creadas en ese periodo de fechas
                        List<DateTime> fecha_a_consultar = Menu.MostrarConsultaFechas();
                        Factura.ConsultarFacturas(cliente, fecha_a_consultar);
                        // Mostramos estado general de la cuenta
                        Factura.ConsultarSaldo(cliente, fecha_a_consultar);
                        string rsp_consulta_salir = Menu.MostrarConsultaDeseaSalir();
                        if (rsp_consulta_salir == "1")
                        {
                            vuelvo_atras = false;
                            Console.WriteLine("Hasta luego!");
                            Console.WriteLine("Muchas gracias por utilizar nuestra aplicación! Esperamos verlo pronto!");
                            Console.WriteLine("Presione [Enter] para salir");
                            Console.ReadLine();
                        }
                    }
                    else if (rsp_principal == "3")
                    {
                        // Mostrar estado de pedido ingresando un numero, buscando en txt
                        string numero_orden = Menu.MostrarConsutaSeguimiento();
                        OrdenDeServicio.ConsultarSeguimiento(numero_orden, cliente.CUIT.ToString());
                        // Si numero pedido es erróneo, debe consultarte si querés salir.
                        string rsp_consulta_salir = Menu.MostrarConsultaDeseaSalir();
                        if (rsp_consulta_salir == "1")
                        {
                            Console.WriteLine("Hasta luego!");
                            Console.WriteLine("Muchas gracias por utilizar nuestra aplicación! Esperamos verlo pronto!");
                            Console.WriteLine("Presione [Enter] para salir");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                    else if (rsp_principal == "4")
                    {
                        vuelvo_atras = false;
                        Console.WriteLine("Hasta luego!");
                        Console.WriteLine("Muchas gracias por utilizar nuestra aplicación! Esperamos verlo pronto!");
                        Console.WriteLine("Presione [Enter] para salir");
                        Console.ReadLine();
                    }
                } while (vuelvo_atras);
            }
        }
    }
}
