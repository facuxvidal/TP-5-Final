using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class OrdenDeServicio
    {
        public OrdenDeServicio()
        {

        }
        public OrdenDeServicio(int numeroOrden, bool esPrioridad, DateTime fechaCreacion, DateTime fechaEntrega, string estado, string origen, string destino, long cuit)
        {
            NumeroOrden = numeroOrden;
            EsPrioridad = esPrioridad;
            FechaCreacion = fechaCreacion;
            FechaEntrega = fechaEntrega;
            Estado = estado;
            Origen = origen;
            Destino = destino;
            CUIT = cuit;
        }

        public int NumeroOrden { get; set; }
        public bool EsPrioridad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public String Estado { get; set; }
        public String Origen { get; set; }
        public String Destino { get; set; }
        public long CUIT { get; set; }

        public static void ConsultarSeguimiento(string numero_orden, string cuit)
        {
            string path = Path.GetFullPath("..\\..\\..\\OrdenesDeServicio.txt");
            FileInfo FI = new FileInfo(path);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(path);
            string es_prioridad = "No es Urgente";
            int contador_lineas = 0;
            int contador_orden = 0;
            string no_encontro = "¡No existe la Orden de Servicio consultada!";
            string resumen_orden = "";
            bool corresponde = true;
            if (lineas.Length > 0)
            {
                while (!SR.EndOfStream)
                {
                    SR.ReadLine();
                    var valores_orden = lineas[contador_lineas].Split('|');
                    // Si la orden corresponde al cliente
                    {
                        // Si encuentra el Numero de Orden
                        if (valores_orden[0] == numero_orden)
                        {
                            if (cuit == valores_orden[7])
                            {
                                if (bool.Parse(valores_orden[1]))
                                {
                                    es_prioridad = "Urgente";
                                }

                                resumen_orden = $"------------------------------------\nREPORTE DE ESTADO DE N°ORDEN DE SERVICIO {numero_orden}\n------------------------------------\n";
                                resumen_orden += $"Estado: {valores_orden[4]} \nOrigen: {valores_orden[5]} \nDestino: {valores_orden[6]} \nTipo De Servicio: {es_prioridad}";
                                contador_orden++;
                                break;
                            }
                            else
                            {
                                corresponde = false;
                            }
                        }
                    }
                    contador_lineas++;
                }

                if (contador_orden != 0)
                {
                    Console.WriteLine(resumen_orden);
                }
                else if (corresponde)
                {
                    Console.WriteLine($"------------------------------------\n{no_encontro}");
                }
                else
                {
                    Console.WriteLine("------------------------------------\nLa orden de servicio consultada corresponde a otro cliente. ¡No podemos mostrar estos datos!");
                }
            }
            else
            {
                Console.WriteLine("------------------------------------\n¡No se encontraron Ordenes de Servicios cargadas en el sistema!\n------------------------------------");
            }
            SR.Close();
        }


        public string ToFormat()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", NumeroOrden, EsPrioridad, FechaCreacion, FechaEntrega, Estado, Origen, Destino, CUIT);
        }
    }
}
