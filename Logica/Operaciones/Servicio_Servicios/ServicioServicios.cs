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

        public string Actualizar(Servicios servicio_new, string id_servicios)
        {
            var lista = Mostrar();
            Servicios servicio_old = lista.FirstOrDefault(item => item.Id_Servicio == int.Parse(id_servicios));
            if (lista == null)
            {
                return "Lista vacia";
            }
            else if (servicio_old == null)
            {
                return "No se encontro el id";
            }
            else if (Exist(servicio_new) && servicio_new.Id_Servicio != int.Parse(id_servicios))
            {
                return "El servicio ingresado ya existe.";
            }
            else
            {
                servicio_old.Id_Servicio = servicio_new.Id_Servicio;
                servicio_old.Nombre = servicio_new.Nombre;
                servicio_old.Precio = servicio_new.Precio;
                archivoServicio.Modificar(lista);
                return "Se ha modificado el servicio";
            }
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
