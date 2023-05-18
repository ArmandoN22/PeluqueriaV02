using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicioServicios : ICrud<Servicios>
    {
        ArchivoServicio archivoServicio;

        public ServicioServicios()
        {
            archivoServicio = new ArchivoServicio();
        }

        public List<Servicios> GetList()
        {
            List<Servicios> ListaServicios = archivoServicio.Leer();
            if (ListaServicios == null)
            {
                return null;
            }
            else
            {
                return ListaServicios;
            }
        }

        public string Actualizar(Servicios tipo, string id_tipo)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int tipo)
        {
            throw new NotImplementedException();
        }

        public string Guardar(Servicios servicio)
        {
            try
            {
                if (GetList() == null)
                {
                    archivoServicio.Guardar(servicio);
                    return $"Servicio Guardado Correctamente con nombre: {servicio.Nombre}";
                }
                else if (Exist(servicio))
                {
                    return "ID Repetido";
                }
                else
                {
                    archivoServicio.Guardar(servicio);
                    return $"Servicio Guardado Correctamente con nombre: {servicio.Nombre}";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public bool Exist(Servicios servicio)
        {
            try
            {
                //puedes usar var
                //item es un cliente de la lista
                Servicios exist = GetList().FirstOrDefault(item => item.Id_Servicio == servicio.Id_Servicio);
                if (exist == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Servicios> Mostrar()
        {
            return archivoServicio.Leer();
        }
    }
}
