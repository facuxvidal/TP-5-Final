﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class EncomiendaCorrespondencia
    {
        public EncomiendaCorrespondencia(int numeroIdentificacion, float peso)
        {
            NumeroIdentificacion = numeroIdentificacion;
            Peso = peso;
        }

        public int NumeroIdentificacion { get; set; }
        // public String Descripcion { get; set; }
        public float Peso { get; set; }
        public String CartaDePorte { get; set; }

    }
}
