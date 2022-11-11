using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class SolicitudDeServicio
    {
        List<OrdenDeServicio> OrdenesDeServicio = new List<OrdenDeServicio>();

        public SolicitudDeServicio(int numeroOrdenServicio, DateTime fecha)
        {
            NumeroOrdenServicio = numeroOrdenServicio;
            Fecha = fecha;
        }

        public int NumeroOrdenServicio { get; set; }
        public DateTime Fecha { get; set; }
        public String TipoDeRetiro { get; set; }
        public String TipoDeEntrega { get; set; }
        public String Destino { get; set; }
        public String Origen { get; set; }

        public OrdenDeServicio GenerarOrdenDeServicio(int nro_orden_servicio, bool es_prioridad, DateTime fecha_creacion, DateTime fecha_entrega, string estado, string origen, string destino)
        {
            string path = Path.GetFullPath("..\\..\\..\\OrdenesDeServicio.txt");
            FileInfo FI = new FileInfo(path);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(path);
            int contador_lineas = 0;
            if (lineas.Length > 0)
            {
                while (!SR.EndOfStream)
                {
                    SR.ReadLine();
                    var valores_orden = lineas[contador_lineas].Split('|');
                    OrdenesDeServicio.Add(new OrdenDeServicio { 
                                                                NumeroOrden = int.Parse(valores_orden[0]), 
                                                                EsPrioridad = bool.Parse(valores_orden[1]), 
                                                                FechaCreacion = DateTime.Parse(valores_orden[2]),
                                                                FechaEntrega = DateTime.Parse(valores_orden[3]),
                                                                Estado = valores_orden[4],
                                                                Origen = valores_orden[5],
                                                                Destino = valores_orden[6]
                    });
                    contador_lineas++;
                }
            }
            SR.Close();

            OrdenDeServicio orden = new OrdenDeServicio(nro_orden_servicio, es_prioridad, fecha_creacion, fecha_entrega.AddDays(7), estado, origen, destino);
            OrdenesDeServicio.Add(orden);

            StreamWriter SW = new StreamWriter(path);
            foreach (OrdenDeServicio nuevo_orden in OrdenesDeServicio)
            {
                SW.WriteLine(nuevo_orden.ToFormat());
            }
            SW.Close();

            return orden;
        }

    }
}
