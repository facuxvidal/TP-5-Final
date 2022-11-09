using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class OrdenDeServicio
    {
        public int NumeroOrden { get; set; }
        public bool EsPrioridad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public String Estado { get; set; } // Entregado, En curso, Cancelado
        
        public void ConsultarSeguimiento()
        {

        }
    }
}
