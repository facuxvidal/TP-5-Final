using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class CuentaCliente
    {
        public int CUIT { get; set; }
        public decimal Saldo { get; set; }
        public decimal FacturacionPaga { get; set; }
        public decimal FacturacionImpaga { get; set; }
        public int ServiciosTotalesCumplidos { get; set; }
        public int ServiciosPendientesAFacturar { get; set; }

        public void ActualizarSaldo()
        {

        }
        public string ConsultarSaldo(Cliente cliente)
        {
            string ubicacion_archivo = Path.GetFullPath("..\\..\\..\\CuentaCliente.txt");
            FileInfo FI = new FileInfo(ubicacion_archivo);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(ubicacion_archivo);
            int contador_lineas = 0;
            string rsp_consulta_saldo = "";
            while (!SR.EndOfStream)
            {
                SR.ReadLine();
                var datos_cuenta_cliente = lineas[contador_lineas].Split('|');
                
                if (cliente.CUIT == long.Parse(datos_cuenta_cliente[0]))
                {
                    rsp_consulta_saldo = "";
                    Console.WriteLine($"------------------------------------\nESTADO DE CUENTA DE {cliente.Nombre} {cliente.Apellido}\n------------------------------------");
                    Console.WriteLine($"Facturacion Paga: ${datos_cuenta_cliente[2]} \nFacturacion Impaga: ${datos_cuenta_cliente[3]} \nServicios Cumplidos: {datos_cuenta_cliente[4]} \nServicios Pendientes a Facturar: {datos_cuenta_cliente[5]}");
                    Console.WriteLine($"------------------------------------\nSALDO FINAL: ${datos_cuenta_cliente[1]}\n------------------------------------");
                    break; // si encuentra la info del cliente, le devolvemos toda su informacion en pantalla
                }
                else
                {
                    rsp_consulta_saldo = "Lo sentimos pero no contamos con informacion de la cuenta asociada a su CUIT";
                    //Console.WriteLine(rsp_consulta_saldo);
                }
                contador_lineas++;
            }
            return rsp_consulta_saldo;
        }

    }
}
