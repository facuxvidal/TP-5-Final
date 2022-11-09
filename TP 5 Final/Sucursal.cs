using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class Sucursal
    {
        public Sucursal(string descripcion, List<string> localidad, List<string> provincias)
        {
            Descripcion = descripcion;
            Localidad = localidad;
            Provincias = provincias;
        }

        public String Descripcion { get; set; } // VIEDMA
        public int NumeroDeSucursal { get; set; } // 01
        public List<String> Localidad { get; set; } // EL CONDOR - EL JUNCAL - EL PASO - LA BOCA - VIEDMA
        public String Region { get; set; } // SUR

        public List<String> Provincias { get; set; }

        //Lista provincias por sucursal

        /*List<string> Viedma = new List<string>();
        List<string> Cordoba = new List<string>();
        List<string> Resistencia = new List<string>();
        List<string> CABA = new List<string>();
        Viedma.Add("TIERRA DEL FUEGO");
                    Viedma.Add("CHUBUT");
                    Viedma.Add("RIO NEGRO");
                    Viedma.Add("SANTA CRUZ");
                    Viedma.Add("LA PAMPA");
                    Cordoba.Add("ENTRE RIOS");
                    Cordoba.Add("CORDOBA");
                    Cordoba.Add("SANTA FE");
                    Cordoba.Add("SAN LUIS");
                    Cordoba.Add("SAN JUAN");
                    Cordoba.Add("MENDOZA");
                    Cordoba.Add("LA RIOJA");
                    Resistencia.Add("CHACO");
                    Resistencia.Add("MISIONES");
                    Resistencia.Add("CORRIENTES");
                    Resistencia.Add("SANTIAGO DEL ESTERO");
                    Resistencia.Add("FORMOSA");
                    Resistencia.Add("JUJUY");
                    Resistencia.Add("SALTA");
                    Resistencia.Add("TUCUMAN");
                    Resistencia.Add("CATAMARCA");
                    CABA.Add("CABA");
                    CABA.Add("BUENOS AIRES");*/

    }
}
