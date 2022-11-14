using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

            // Al ser facturacion por mes, todas las facturas que se emitan en los dias del mes corriente, se venceran el ultimo dia del mes 
            DateTime hoy = DateTime.Now.Date;
            var dias_del_mes = DateTime.DaysInMonth(hoy.Year, hoy.Month);
            DateTime ultimo_dia_mes = new DateTime(hoy.Year, hoy.Month, dias_del_mes);

            Factura factura = new Factura(numero_factura, precio_final, unidades, hoy, ultimo_dia_mes, "Impaga", CUIT);
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
            string no_encontro = "";
            string resumen_factuacion = "";
            string reporte = $"------------------------------------\nREPORTE DE FACTURACION DEL CLIENTE {cliente.Nombre} {cliente.Apellido} ENTRE {fecha_a_consultar[0].ToString().Substring(0, 10)} y {fecha_a_consultar[1].ToString().Substring(0, 10)}\n------------------------------------";
            if (lineas.Length > 0)
            {
                while (!SR.EndOfStream)
                {
                    SR.ReadLine();
                    var valores_factura = lineas[contador_lineas].Split('|');
                    // Si no puso una fecha de inicio mayor a hoy
                    if (fecha_a_consultar[0] <= DateTime.Now)
                    {
                        if (fecha_a_consultar[0] <= fecha_a_consultar[1])
                        {
                            // Si encuentra el Cuit
                            if (long.Parse(valores_factura[6]) == cliente.CUIT)
                            {
                                // Si la fecha desde esta entre las dos fechas guardadas y la fecha hasta tambien
                                if (fecha_a_consultar[0] <= DateTime.Parse(valores_factura[3]) && fecha_a_consultar[1] >= DateTime.Parse(valores_factura[3]))
                                {
                                    Console.WriteLine(reporte);
                                    resumen_factuacion += $"N° Factura: {valores_factura[0]} \nPrecio Total: ${valores_factura[1]} \nUnidades: {valores_factura[2]} \nFecha Creacion: {valores_factura[3].ToString().Substring(0, 10)} \nFecha Vencimiento: {valores_factura[4].ToString().Substring(0, 10)} \nEstado: {valores_factura[5]}\n************************************\n";
                                    contador_cuit++;
                                }
                            }
                        }
                        else
                        {
                            no_encontro = "------------------------------------\n¡Usted debe seleccionar una fecha 'Desde' anterior a 'Hasta!";
                        }

                    }
                    else
                    {
                        no_encontro = "------------------------------------\n¡Usted debe seleccionar una fecha 'Desde' anterior a hoy!";
                    }
                    contador_lineas++;
                }

                if (contador_cuit != 0)
                {
                    Console.WriteLine(resumen_factuacion);
                }
                else
                {
                    if (fecha_a_consultar[0] > DateTime.Now || fecha_a_consultar[0] > fecha_a_consultar[1])
                    {
                        Console.WriteLine(no_encontro);
                    }
                    else
                    {
                        Console.WriteLine($"------------------------------------\nNo se encontraron facturas asociadas a su cuenta en el periodo de {fecha_a_consultar[0].ToString().Substring(0, 10)} - {fecha_a_consultar[1].ToString().Substring(0, 10)}");
                    }
                }
            }
            else
            {
                Console.WriteLine("------------------------------------\n¡No se encontraron Facturas cargadas en el sistema!");
            }
            SR.Close();
        }

        public static void ConsultarSaldo(Cliente cliente, List<DateTime> fecha_a_consultar)
        {
            string ubicacion_archivo = Path.GetFullPath("..\\..\\..\\Facturas.txt");
            FileInfo FI = new FileInfo(ubicacion_archivo);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(ubicacion_archivo);
            int contador_lineas = 0;
            int contador_pedidos_en_periodo = 0;
            decimal contador_pedidos = 0;
            decimal acumula_montos_pagos = 0;
            decimal acumula_montos_impagos = 0;
            decimal acumula_montos_pagos_en_periodo = 0;
            decimal acumula_montos_impagos_en_periodo = 0;
            while (!SR.EndOfStream)
            {
                SR.ReadLine();
                var valores_factura = lineas[contador_lineas].Split('|');

                if (cliente.CUIT == long.Parse(valores_factura[6]))
                {
                    if (fecha_a_consultar[0] <= DateTime.Parse(valores_factura[3]) && fecha_a_consultar[1] >= DateTime.Parse(valores_factura[3]))
                    {
                        // Sumamos facturas por periodo
                        if (valores_factura[5] == "Impaga")
                        {
                            acumula_montos_impagos_en_periodo += decimal.Parse(valores_factura[1]);
                        }
                        else if (valores_factura[5] == "Paga")
                        {
                            acumula_montos_pagos_en_periodo += decimal.Parse(valores_factura[1]);
                        }
                        contador_pedidos_en_periodo++;
                    }
                    // Sumamos facturas totales
                    if (valores_factura[5] == "Impaga")
                    {
                        acumula_montos_impagos += decimal.Parse(valores_factura[1]);
                    }
                    else if (valores_factura[5] == "Paga")
                    {
                        acumula_montos_pagos += decimal.Parse(valores_factura[1]);
                    }
                    contador_pedidos++;

                }
                contador_lineas++;
            }

            if (contador_pedidos != 0)
            {
                if (contador_pedidos_en_periodo != 0)
                {
                    Console.WriteLine($"------------------------------------\nSALDO DE CUENTA DE {cliente.Nombre} {cliente.Apellido} ENTRE {fecha_a_consultar[0].ToString().Substring(0, 10)} y {fecha_a_consultar[1].ToString().Substring(0, 10)}\n------------------------------------");
                    Console.WriteLine($"Facturacion Paga en Periodo: ${acumula_montos_pagos_en_periodo} \nFacturacion Impaga en Periodo: ${acumula_montos_impagos_en_periodo} \nServicios facturados en Periodo: {contador_pedidos_en_periodo}");
                }
                if (fecha_a_consultar[0] <= DateTime.Now && fecha_a_consultar[0] <= fecha_a_consultar[1])
                {
                    Console.WriteLine($"------------------------------------\nSALDO TOTAL DE CUENTA DE {cliente.Nombre} {cliente.Apellido}\n------------------------------------");
                    Console.WriteLine($"Total Facturacion Paga: ${acumula_montos_pagos} \nTotal Facturacion Impaga: ${acumula_montos_impagos} \nTotal Servicios facturados: {contador_pedidos}");
                }
            }


        }

        public string ToFormat()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", NumeroFactura, PrecioFinal, Unidades, FechaCreacion, FechaVencimiento, Estado, CUIT);
        }
    }
}
