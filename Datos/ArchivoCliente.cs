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
                StreamWriter sw = new StreamWriter(ruta, true);
                sw.WriteLine(cliente.ToString());
                sw.Close();
                return true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Cliente> Leer()
        {
            throw new NotImplementedException();
        }

        public Cliente Mapear(string linea)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(List<Cliente> List)
        {
            throw new NotImplementedException();
        }
    }
}
