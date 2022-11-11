using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class Factura
    {
        List<Factura> Facturas = new List<Factura>();

        public Factura()
        {

        }

        public Factura(String numeroFactura, decimal precioFinal, int unidades, DateTime fechaCreacion, DateTime fechaVencimiento, String estado, long cuit)
        {
            NumeroFactura = numeroFactura;
            PrecioFinal = precioFinal;
            Unidades = unidades;
            FechaCreacion = fechaCreacion;
            FechaVencimiento = fechaVencimiento;
            Estado = estado;
            CUIT = cuit;
        }

        public String NumeroFactura { get; set; }
        public decimal PrecioFinal { get; set; }
        public int Unidades { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public String Estado { get; set; }
        public long CUIT { get; set; }

        public Factura GenerarFactura(decimal precio_final, int unidades, long CUIT)
        {
            string path = Path.GetFullPath("..\\..\\..\\Facturas.txt");
            FileInfo FI = new FileInfo(path);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(path);
            int contador_lineas = 0;
            if (lineas.Length > 0)
            {
                while (!SR.EndOfStream)
                {
                    SR.ReadLine();
                    var valores_factura = lineas[contador_lineas].Split('|');
                    Facturas.Add(new Factura
                    {
                        NumeroFactura = valores_factura[0],
                        PrecioFinal = decimal.Parse(valores_factura[1]),
                        Unidades = int.Parse(valores_factura[2]),
                        FechaCreacion = DateTime.Parse(valores_factura[3]),
                        FechaVencimiento = DateTime.Parse(valores_factura[4]),
                        Estado = valores_factura[5],
                        CUIT = long.Parse(valores_factura[6])
                    });
                    contador_lineas++;
                }
            }
            SR.Close();

            Random numero_random = new Random();
            string numero_factura = $"0001-{numero_random.Next()}";
            Factura factura = new Factura(numero_factura, precio_final, unidades, DateTime.Now.Date, DateTime.Now.Date.AddDays(30), "Impaga", CUIT);
            Facturas.Add(factura);

            StreamWriter SW = new StreamWriter(path);
            foreach (Factura nueva_factura in Facturas)
            {
                SW.WriteLine(nueva_factura.ToFormat());
            }
            SW.Close();

            return factura;
        }

        public static void ConsultarFacturas(Cliente cliente, List<DateTime> fecha_a_consultar)
        {
            string path = Path.GetFullPath("..\\..\\..\\Facturas.txt");
            FileInfo FI = new FileInfo(path);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(path);
            int contador_lineas = 0;
            int contador_cuit = 0;
            string no_encontro = "¡No se encontraron facturas asociadas a su cuenta!";
            string resumen_factuacion = "";
            if (lineas.Length > 0)
            {
                Console.WriteLine($"------------------------------------\nREPORTE DE FACTURACION DEL CLIENTE {cliente.Nombre} {cliente.Apellido} ENTRE {fecha_a_consultar[0].ToString().Substring(0, 10)} y {fecha_a_consultar[1].ToString().Substring(0, 10)}\n------------------------------------");
                while (!SR.EndOfStream)
                {
                    SR.ReadLine();
                    var valores_factura = lineas[contador_lineas].Split('|');
                    // Si encuentra el Cuit
                    if (long.Parse(valores_factura[6]) == cliente.CUIT)
                    {
                        // Si la fecha desde esta entre las dos fechas guardadas y la fecha hasta tambien

                        if (fecha_a_consultar[0] <= DateTime.Parse(valores_factura[3]) && fecha_a_consultar[1] >= DateTime.Parse(valores_factura[3]))
                        {
                            resumen_factuacion += $"N° Factura: {valores_factura[0]} \nPrecio Total: ${valores_factura[1]} \nUnidades: {valores_factura[2]} \nFecha Desde: {valores_factura[3].ToString().Substring(0, 10)} \nFecha Hasta: {valores_factura[4].ToString().Substring(0, 10)} \nEstado: {valores_factura[5]}\n************************************\n";
                            contador_cuit++;
                        }
                        
                        /*if (Between(fecha_a_consultar[0], DateTime.Parse(valores_factura[3]), DateTime.Parse(valores_factura[4])) &&
                       Between(fecha_a_consultar[1], DateTime.Parse(valores_factura[3]), DateTime.Parse(valores_factura[4])))
                        {
                            resumen_factuacion += $"N° Factura: {valores_factura[0]} \nPrecio Total: ${valores_factura[1]} \nUnidades: {valores_factura[2]} \nFecha Desde: {valores_factura[3].ToString().Substring(0, 10)} \nFecha Hasta: {valores_factura[4].ToString().Substring(0, 10)} \nEstado: {valores_factura[5]}\n************************************\n";
                            contador_cuit++;
                        }*/

                    }
                    contador_lineas++;
                }

                if (contador_cuit != 0)
                {
                    Console.WriteLine(resumen_factuacion);
                }
                else
                {
                    Console.WriteLine(no_encontro);
                }
            }
            else
            {
                Console.WriteLine("------------------------------------\n¡No se encontraron facturas cargadas en el sistema!\n------------------------------------");
            }
            SR.Close();
        }

        private static bool Between(DateTime input, DateTime date1, DateTime date2)
        {
            return (input <= date1 && input >= date2);
        }

        public string ToFormat()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", NumeroFactura, PrecioFinal, Unidades, FechaCreacion, FechaVencimiento, Estado, CUIT);
        }
    }
}
