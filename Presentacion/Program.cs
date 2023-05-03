using Entidades;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var cliente = new Cliente();
            //cliente.Id=int.Parse(Console.ReadLine());
            //cliente.Nombre=Console.ReadLine();
            //cliente.Apellido=Console.ReadLine();
            //cliente.Telefono=Console.ReadLine();
            //cliente.Correo=Console.ReadLine();

            //ArchivoCliente ar = new ArchivoCliente();
            //ar.Guardar(cliente);

            var login = new Login();
            login.Usuario = Console.ReadLine();
            login.Contraseña = Console.ReadLine();
            login.CorreoElectronico = Console.ReadLine();

            ArchivoLogin al = new ArchivoLogin();
            al.Guardar(login);
        }
    }
}
