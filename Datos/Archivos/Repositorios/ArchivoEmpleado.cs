using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ArchivoEmpleado : IArchivo<Empleado>
    {
        string ruta = "empleado.txt";
        public bool Guardar(Empleado empleado)
        {
            try
            {
                StreamWriter sw = new StreamWriter(ruta, true);
                sw.WriteLine(empleado.ToString());
                sw.Close();
                return true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Empleado> Leer()
        {
            try
            {
                StreamReader reader = new StreamReader(ruta);
                List<Empleado> list = new List<Empleado>();
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

        public Empleado Mapear(string linea)
        {
            try
            {
                var empleado = new Empleado();
                var aux = linea.Split(';');

                empleado.Id = int.Parse(aux[0]);
                empleado.Nombre = aux[1];
                empleado.Apellido = aux[2];
                empleado.Telefono = aux[3];
                empleado.Direccion = aux[4];
                empleado.FechaContratacion = DateTime.Parse(aux[5]);
                empleado.Salario = double.Parse(aux[6]);
                return empleado;
            }
            catch (Exception)
            {

                return null;
            }
        }

        

        public bool Modificar(List<Empleado> Empleados)
        {
            try
            {

                if (Empleados.Count == 0 && File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
                else
                {
                    StreamWriter sw = new StreamWriter(ruta, false);
                    foreach (var empleado in Empleados)
                    {
                        sw.WriteLine(empleado.ToString());
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
