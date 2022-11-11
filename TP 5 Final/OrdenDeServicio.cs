using System;
using System.Collections.Generic;
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
        public OrdenDeServicio(int numeroOrden, bool esPrioridad, DateTime fechaCreacion, DateTime fechaEntrega, string estado)
        {
            NumeroOrden = numeroOrden;
            EsPrioridad = esPrioridad;
            FechaCreacion = fechaCreacion;
            FechaEntrega = fechaEntrega;
            Estado = estado;
        }

        public int NumeroOrden { get; set; }
        public bool EsPrioridad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public String Estado { get; set; } // Entregado, En curso, Cancelado
        
        public void ConsultarSeguimiento()
        {

        }


        public string ToFormat()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}", NumeroOrden, EsPrioridad, FechaCreacion, FechaEntrega, Estado);
        }
    }
}
