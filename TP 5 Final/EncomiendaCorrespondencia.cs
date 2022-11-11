using System;
using System.Collections.Generic;
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

    }
}
