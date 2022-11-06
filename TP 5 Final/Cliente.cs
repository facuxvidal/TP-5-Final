using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class Cliente
    {
        public Cliente()
        {

        }

        public Cliente(string nombre, string apellido, int cuit, int numerodedocumento, string direccion, int telefono, string correo_electronico, bool es_corporativo, string usuario, string contraseña)
        {
            Nombre = nombre;
            Apellido = apellido;
            CUIT = cuit;
            NumeroDeDocumento = numerodedocumento;
            Direccion = direccion;
            Telefono = telefono;
            CorreoElectronico = correo_electronico;
            EsCorporativo = es_corporativo;
            Usuario = usuario;
            Contraseña = contraseña;
        }

        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public long CUIT { get; set; }
        public int NumeroDeDocumento { get; set; }
        public String Direccion { get; set; }
        public int Telefono { get; set; }
        public String CorreoElectronico { get; set; }
        public bool EsCorporativo { get; set; }
        public String Usuario { get; set; }
        public String Contraseña { get; set; }

        public Cliente LogIn()
        {
            string usuario;
            string contraseña;
            string rsp_intento_login = "";
            bool bandera = true;
            Cliente cliente = new Cliente();
            while (bandera)
            {
                Console.WriteLine("Inicie sesion con su usuario y contraseña");
                Console.Write("Usuario: ");
                usuario = Console.ReadLine().Trim();
                Console.Write("Contraseña: ");
                contraseña = Console.ReadLine().Trim();

                string ubicacion_archivo = Path.GetFullPath("..\\..\\..\\Clientes.txt");
                FileInfo FI = new FileInfo(ubicacion_archivo);
                StreamReader SR = FI.OpenText();
                string[] lineas = File.ReadAllLines(ubicacion_archivo);
                int contador_lineas = 0;
                while (!SR.EndOfStream)
                {
                    SR.ReadLine();
                    var valores_cliente = lineas[contador_lineas].Split('|');

                    if (valores_cliente[8] != usuario || valores_cliente[9] != contraseña)
                    {
                        rsp_intento_login = "------------------------------------\nERROR - Usuario Inexistente o Contraseña erronea. Intente nuevamente!\n------------------------------------";
                    }
                    else
                    {
                        rsp_intento_login = "";
                        bandera = false;
                        cliente = Cargar(valores_cliente);
                        //cliente.Nombre = valores_cliente[0];
                        //cliente.Apellido = valores_cliente[1];
                        //cliente.CUIT = long.Parse(valores_cliente[2]);
                        //cliente.NumeroDeDocumento = int.Parse(valores_cliente[3]);
                        //cliente.Direccion = valores_cliente[4];
                        //cliente.Telefono = int.Parse(valores_cliente[5]);
                        //cliente.CorreoElectronico = valores_cliente[6];
                        //cliente.EsCorporativo = bool.Parse(valores_cliente[7]);
                        //cliente.Usuario = valores_cliente[8];
                        //cliente.Contraseña = valores_cliente[9];
                        SR.Close();
                        break; // Una vez que lo encuentra, cargo las propiedades del cliente y detengo el trabajo
                    }
                    contador_lineas++;
                }
                if (rsp_intento_login.Length > 0)
                {
                    Console.WriteLine(rsp_intento_login);
                }
            }
            return cliente;
        }

        private Cliente Cargar(string[] datos_a_cargar)
        {
            Cliente cliente = new Cliente
            {
                Nombre = datos_a_cargar[0],
                Apellido = datos_a_cargar[1],
                CUIT = long.Parse(datos_a_cargar[2]),
                NumeroDeDocumento = int.Parse(datos_a_cargar[3]),
                Direccion = datos_a_cargar[4],
                Telefono = int.Parse(datos_a_cargar[5]),
                CorreoElectronico = datos_a_cargar[6],
                EsCorporativo = bool.Parse(datos_a_cargar[7]),
                Usuario = datos_a_cargar[8],
                Contraseña = datos_a_cargar[9]
            };
            return cliente;
        }

        public void MostrarDatos()
        {

        }

    }
}