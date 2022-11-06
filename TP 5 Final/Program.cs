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
            string opcion_elegida;
            Console.WriteLine("------------------------------------\nBIENVENIDO\n------------------------------------");
            Cliente cliente = new Cliente();
            cliente = cliente.LogIn();
            Console.WriteLine($"Usuario: {cliente.Nombre} enocntrado!");

            //opcion_elegida = Menu.MostrarPrincipal();

            Console.ReadLine();
        }
    }
}
