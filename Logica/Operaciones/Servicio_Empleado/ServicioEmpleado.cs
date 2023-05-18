using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Logica
{
    public class ServicioEmpleado : ICrud<Empleado>
    {

        ArchivoEmpleado archivoEmpleado;

        public ServicioEmpleado()
        {
            archivoEmpleado = new ArchivoEmpleado();
        }

        public List<Empleado> GetList()
        {
            List<Empleado> ListaEmpleado = archivoEmpleado.Leer();
            if (ListaEmpleado == null)
            {
                return null;
            }
            else
            {
                return ListaEmpleado;
            }
        }

        public string Actualizar(Empleado tipo, string id_tipo)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int tipo)
        {
            throw new NotImplementedException();
        }

        public string Guardar(Empleado empleado)
        {
            if (GetList() == null)
            {
                archivoEmpleado.Guardar(empleado);
                return $"Empleado Guardado Correctamente con nombre: {empleado.Nombre}";
            }
            else if (Exist(empleado))
            {
                return "ID Repetido";
            }
            else
            {
                archivoEmpleado.Guardar(empleado);
                return $"Empleado Guardado Correctamente con nombre: {empleado.Nombre}";
            }
        }

        bool Exist(Empleado empleado)
        {
            try
            {
                //puedes usar var
                //item es un cliente de la lista
                Empleado exist = GetList().FirstOrDefault(item => item.Id == empleado.Id);
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


        public List<Empleado> Mostrar()
        {
            return archivoEmpleado.Leer();
        }
    }
}
