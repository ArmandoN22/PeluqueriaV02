using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CitaServicios
    {
        public string IdCitaFK { get; set; }
        public string IdServiciosFK { get; set; }
        public int Cantidad { get; set; }
    }
}
