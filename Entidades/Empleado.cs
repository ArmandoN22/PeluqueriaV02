using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado : Persona
    {
        public Empleado()
        {
        }


        public Empleado(int id, string nombre, string apellido, string telefono, string direccion, DateTime fechaContratacion, double salario) : base(id, nombre, apellido, telefono)
        {
            Direccion = direccion;
            FechaContratacion = fechaContratacion;
            Salario = salario;
        }

        public string Direccion { get; set; }
        public DateTime FechaContratacion { get; set; }
        public double Salario { get; set; }
    }
}
