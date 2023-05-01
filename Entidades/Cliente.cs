using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Persona
    {
        public Cliente()
        {
        }


        public Cliente(int id, string nombre, string apellido, string telefono, string correo) : base(id, nombre, apellido, telefono)
        {
            Correo = correo;
        }

        public string Correo { get; set; }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Apellido};{Telefono};{Correo}";
        }

    }
}
