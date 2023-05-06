using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ArchivoCliente : IArchivo<Cliente>
    {
        string ruta = "cliente.txt";
        public bool Guardar(Cliente cliente)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(cliente.ToString());
                writer.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public object Guardar(Login usuario)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> Leer()
        {
            try
            {
                StreamReader reader = new StreamReader(ruta);
                List<Cliente> list = new List<Cliente>();
                while (!reader.EndOfStream)
                {
                    string linea = reader.ReadLine();
                    list.Add(Mapear(linea));
                }
                reader.Close();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Cliente Mapear(string linea)
        {
            try
            {
                var cliente = new Cliente();
                var aux = linea.Split(';');

                cliente.Id = int.Parse(aux[0]);
                cliente.Nombre = aux[1];
                cliente.Apellido = aux[2];
                cliente.Telefono = aux[3];
                cliente.Correo = aux[4];
                return cliente;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Modificar(List<Cliente> Clientes)
        {
            try
            {

                if (Clientes.Count == 0 && File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
                else
                {
                    StreamWriter sw = new StreamWriter(ruta, false);
                    foreach (var cliente in Clientes)
                    {
                        sw.WriteLine(cliente.ToString());
                    }
                    sw.Close();
                }
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
