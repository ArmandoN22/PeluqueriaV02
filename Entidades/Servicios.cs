﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Servicios
    {
        public Servicios()
        {
        }

        public Servicios(int id_Servicio, string nombre, double precio)
        {
            Id_Servicio = id_Servicio;
            Nombre = nombre;
            Precio = precio;
        }

        public int Id_Servicio { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }
}
