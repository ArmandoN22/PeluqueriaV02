using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Citas
    {
        public Citas()
        {
            Servicios = new List<Servicios> ();
        }

        public Citas(int idCita, DateTime fecha, Cliente cliente, Empleado empleado, List<Servicios> servicios)
        {
            IdCita = idCita;
            Fecha = fecha;
            this.cliente = cliente;
            Empleado = empleado;
            Servicios = servicios;
        }

        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }

        Cliente cliente { get; set; }
        Empleado Empleado { get; set; }
        List<Servicios> Servicios { get; set; }

        public override string ToString()
        {
            return $"{IdCita};{Fecha};{cliente.Id};{Empleado.Id}";
        }
    }

}
