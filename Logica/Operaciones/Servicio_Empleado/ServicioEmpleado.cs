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

        public string Actualizar(Empleado empleado_new, string id_empleado)
        {
            var lista = Mostrar();
            Empleado empleado_old = lista.FirstOrDefault(item => item.Id == int.Parse(id_empleado));
            if (lista == null)
            {
                return "Lista vacia";
            }
            else if (empleado_old == null)
            {
                return "No se encontro el id";
            }
            else if (Exist(empleado_new) && empleado_new.Id != int.Parse(id_empleado))
            {
                return "El empleado ingresado ya existe.";
            }
            else
            {
                empleado_old.Id = empleado_new.Id;
                empleado_old.Nombre = empleado_new.Nombre;
                empleado_old.Apellido = empleado_new.Apellido;
                empleado_old.Telefono = empleado_new.Telefono;
                empleado_old.Direccion = empleado_new.Direccion;
                empleado_old.FechaContratacion = empleado_new.FechaContratacion;
                empleado_old.Salario = empleado_new.Salario;
                archivoEmpleado.Modificar(lista);
                return "Se ha modificado el empleado";
            }
        }

        public string Eliminar(int id_empleado)
        {
            try
            {

                var lista = Mostrar();
                int pos = lista.FindIndex(item => item.Id == id_empleado);
                string nombre = lista[pos].Nombre;
                lista.RemoveAt(pos);
                archivoEmpleado.Modificar(lista);
                return $"Se Elimino Correctamente el empleado con nombre: {nombre}";


            }
            catch (Exception)
            {
                return "Error!!";
            }
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
