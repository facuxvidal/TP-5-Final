using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class EncomiendaCorrespondencia
    {
        public EncomiendaCorrespondencia(int numeroIdentificacion, decimal peso)
        {
            NumeroIdentificacion = numeroIdentificacion;
            Peso = peso;
        }

        public int NumeroIdentificacion { get; set; }
        public decimal Peso { get; set; }


        public static string ConsultaRegionPorUbicacion(string localidad_origen, string localidad_destino, string provincia_origen, string provincia_destino)
        {
            string rsp = "";
            List<string> RegionSur = new List<string>();
            List<string> RegionCentro = new List<string>();
            List<string> RegionNorte = new List<string>();
            List<string> RegionMetropolitana = new List<string>();

            string provincias_por_region = Path.GetFullPath("..\\..\\..\\ProvinciasXRegion.txt");
            FileInfo FI = new FileInfo(provincias_por_region);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(provincias_por_region);
            int contador_lineas = 0;
            int contador_provincias = 1;

            while (!SR.EndOfStream)
            {
                SR.ReadLine();
                var provincias = lineas[contador_lineas].Split('|');

                if (provincias[0] == "REGION SUR")
                {
                    int total_provincias_por_region = provincias.Count();
                    foreach (var provincia in provincias)
                    {
                        if (total_provincias_por_region != contador_provincias)
                        {
                            RegionSur.Add(provincias[contador_provincias]);
                            contador_provincias++;
                        }
                    }

                }
                if (provincias[0] == "REGION CENTRO")
                {
                    int total_provincias_por_region = provincias.Count();
                    foreach (var provincia in provincias)
                    {
                        if (total_provincias_por_region != contador_provincias)
                        {
                            RegionCentro.Add(provincias[contador_provincias]);
                            contador_provincias++;
                        }
                    }
                }
                if (provincias[0] == "REGION NORTE")
                {
                    int total_provincias_por_region = provincias.Count();
                    foreach (var provincia in provincias)
                    {
                        if (total_provincias_por_region != contador_provincias)
                        {
                            RegionNorte.Add(provincias[contador_provincias]);
                            contador_provincias++;
                        }
                    }
                }
                if (provincias[0] == "REGION METROPOLITANA")
                {
                    int total_provincias_por_region = provincias.Count();
                    foreach (var provincia in provincias)
                    {
                        if (total_provincias_por_region != contador_provincias)
                        {
                            RegionMetropolitana.Add(provincias[contador_provincias]);
                            contador_provincias++;
                        }
                    }
                }
                contador_provincias = 1;
                contador_lineas++;
            }
            SR.Close();


            if (localidad_origen == localidad_destino)
            {
                rsp = "LOCAL";
            }
            else if (provincia_origen == provincia_destino)
            {
                rsp = "PROVINCIAL";
            }
            else if ((RegionSur.Contains(provincia_origen) && RegionSur.Contains(provincia_destino))
                || (RegionCentro.Contains(provincia_origen) && RegionCentro.Contains(provincia_destino))
                || (RegionMetropolitana.Contains(provincia_origen) && RegionMetropolitana.Contains(provincia_destino))
                || (RegionNorte.Contains(provincia_origen) && RegionNorte.Contains(provincia_destino)))
            {
                rsp = "REGIONAL";
            }
            else if (!((RegionSur.Contains(provincia_origen) && RegionSur.Contains(provincia_destino))
                || (RegionCentro.Contains(provincia_origen) && RegionCentro.Contains(provincia_destino))
                || (RegionMetropolitana.Contains(provincia_origen) && RegionMetropolitana.Contains(provincia_destino))
                || (RegionNorte.Contains(provincia_origen) && RegionNorte.Contains(provincia_destino))))
            {
                rsp = "NACIONAL";
            }

            return rsp;
        }

        public static string ConsultaRegionPorUbicacionInternacional(string provincia_origen, string provincia_destino)
        {
            string rsp = "";
            List<string> RegionSur = new List<string>();
            List<string> RegionCentro = new List<string>();
            List<string> RegionNorte = new List<string>();
            List<string> RegionMetropolitana = new List<string>();

            string provincias_por_region = Path.GetFullPath("..\\..\\..\\ProvinciasXRegion.txt");
            FileInfo FI = new FileInfo(provincias_por_region);
            StreamReader SR = FI.OpenText();
            string[] lineas = File.ReadAllLines(provincias_por_region);
            int contador_lineas = 0;
            int contador_provincias = 1;

            while (!SR.EndOfStream)
            {
                SR.ReadLine();
                var provincias = lineas[contador_lineas].Split('|');

                if (provincias[0] == "REGION SUR")
                {
                    int total_provincias_por_region = provincias.Count();
                    foreach (var provincia in provincias)
                    {
                        if (total_provincias_por_region != contador_provincias)
                        {
                            RegionSur.Add(provincias[contador_provincias]);
                            contador_provincias++;
                        }
                    }

                }
                if (provincias[0] == "REGION CENTRO")
                {
                    int total_provincias_por_region = provincias.Count();
                    foreach (var provincia in provincias)
                    {
                        if (total_provincias_por_region != contador_provincias)
                        {
                            RegionCentro.Add(provincias[contador_provincias]);
                            contador_provincias++;
                        }
                    }
                }
                if (provincias[0] == "REGION NORTE")
                {
                    int total_provincias_por_region = provincias.Count();
                    foreach (var provincia in provincias)
                    {
                        if (total_provincias_por_region != contador_provincias)
                        {
                            RegionNorte.Add(provincias[contador_provincias]);
                            contador_provincias++;
                        }
                    }
                }
                if (provincias[0] == "REGION METROPOLITANA")
                {
                    int total_provincias_por_region = provincias.Count();
                    foreach (var provincia in provincias)
                    {
                        if (total_provincias_por_region != contador_provincias)
                        {
                            RegionMetropolitana.Add(provincias[contador_provincias]);
                            contador_provincias++;
                        }
                    }
                }
                contador_provincias = 1;
                contador_lineas++;
            }
            SR.Close();

            // El único caso que sería provincial es si el origen es Buenos Aires, fuera de CABA. 
            // En caso de que sea CABA, no habría costo de envio nacional previo al internacional.
            if (provincia_origen == provincia_destino)
            {
                rsp = "";
            }
            else if ((RegionSur.Contains(provincia_origen) && RegionSur.Contains(provincia_destino))
                || (RegionCentro.Contains(provincia_origen) && RegionCentro.Contains(provincia_destino))
                || (RegionMetropolitana.Contains(provincia_origen) && RegionMetropolitana.Contains(provincia_destino))
                || (RegionNorte.Contains(provincia_origen) && RegionNorte.Contains(provincia_destino)))
            {
                rsp = "REGIONAL";
            }
            else if (!((RegionSur.Contains(provincia_origen) && RegionSur.Contains(provincia_destino))
                || (RegionCentro.Contains(provincia_origen) && RegionCentro.Contains(provincia_destino))
                || (RegionMetropolitana.Contains(provincia_origen) && RegionMetropolitana.Contains(provincia_destino))
                || (RegionNorte.Contains(provincia_origen) && RegionNorte.Contains(provincia_destino))))
            {
                rsp = "NACIONAL";
            }
            else
            {
                rsp = "";
            }

            return rsp;
        }
    }
}
