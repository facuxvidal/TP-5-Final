using System;
using System.Collections.Generic;
using System.Linq;
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
                    SolicitudDeServicio solicitud = new SolicitudDeServicio(numero_orden_servicio.Next(),DateTime.Now);

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

                    bool urgente = Tarifa.consulta_urgencia();
                    string region_origen = Menu.MostrarConsutaCiudadOrigen();
                    string retiro_o_entrega = Menu.RetiroEntrega();


                    //bool retiro_domicilio, entrega_domicilio;
                    Console.WriteLine("Muchas gracias por utilizar nuestra aplicación! Esperamos verlo pronto!");
                    Console.WriteLine("Presione [Enter] para salir");
                    Console.ReadLine();
                }
                else if (rsp_principal == "2")
                {

                }
                else if (rsp_principal == "3")
                {

                }
                else if (rsp_principal == "4")
                {

                }
            }
        }
    }
}
