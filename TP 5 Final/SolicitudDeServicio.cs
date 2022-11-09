using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5_Final
{
    public class SolicitudDeServicio
    {
        public SolicitudDeServicio(int numeroOrdenServicio, DateTime fecha)
        {
            NumeroOrdenServicio = numeroOrdenServicio;
            Fecha = fecha;
        }

        public int NumeroOrdenServicio { get; set; }
        public DateTime Fecha { get; set; }
        public String TipoDeRetiro { get; set; }
        public String TipoDeEntrega { get; set; } // Entrega/Retiro en puerta o en sucursal. Codear "Elegir Tipo de Servicio"
        public String Destino { get; set; }
        public String Origen { get; set; }

        public void GenerarOrdenDeServicio()
        {
            // el cliente solicita solicitud, se valida condinciones (peso dentro del rango) y se crea orden de servicio
        }
    }
}
