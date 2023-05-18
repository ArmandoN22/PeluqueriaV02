using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ArchivoServicio : IArchivo<Servicios>
    {
        string ruta = "servicios.txt";
        public bool Guardar(Servicios servicio)
        {
            try
            {
                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(servicio.ToString());
                writer.Close();
                return true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Servicios> Leer()
        {
            try
            {
                StreamReader reader = new StreamReader(ruta);
                List<Servicios> list = new List<Servicios>();
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

        public Servicios Mapear(string linea)
        {
            try
            {
                var servicio = new Servicios();
                var aux = linea.Split(';');

                servicio.Id_Servicio = int.Parse(aux[0]);
                servicio.Nombre = aux[1];
                servicio.Precio = float.Parse(aux[2]);
                return servicio;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Modificar(List<Servicios> servicios)
        {
            try
            {

                if (servicios.Count == 0 && File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
                else
                {
                    StreamWriter sw = new StreamWriter(ruta, false);
                    foreach (var servicio in servicios)
                    {
                        sw.WriteLine(servicio.ToString());
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
