using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.IO;

namespace Logica
{
    public class ServicioCliente : ICrud<Cliente>
    {
        ArchivoCliente archivoCliente;


        public ServicioCliente()
        {
            archivoCliente = new ArchivoCliente();
        }

        public string Eliminar(int id_cliente)
        {
            try
            {
                var lista = Mostrar();
                int pos = lista.FindIndex(item => item.Id == id_cliente);
                string nombre = lista[pos].Nombre;
                lista.RemoveAt(pos);
                archivoCliente.Modificar(lista);
                return $"Se Elimino Correctamente el cliente con nombre: {nombre}";
            }
            catch (Exception)
            {  
                return "Error!!";
            }
            
        }

        public string Guardar(Cliente cliente)
        {
            try
            {
                if (Mostrar() == null)
                {
                    archivoCliente.Guardar(cliente);
                    return $"Guardado Correctamente con nombre: {cliente.Nombre}";
                }
                else if(Exist(cliente))
                {
                    return "ID Repetido";
                }
                else
                {
                    archivoCliente.Guardar(cliente);
                    return $"Guardado Correctamente con nombre: {cliente.Nombre}";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        bool Exist(Cliente cliente)
        {
            try
            {
                //puedes usar var
                //item es un cliente de la lista
                Cliente exist = Mostrar().FirstOrDefault(item => item.Id == cliente.Id);
                if(exist == null)
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

        public List<Cliente> Mostrar()//GetList
        {
            List<Cliente> ListaCliente = archivoCliente.Leer();
            if (ListaCliente == null)
            {
                return null;
            }
            else
            {
                return ListaCliente;
            }
        }

        public string Actualizar(Cliente cliente_new, string id_cliente)
        {
            var lista = Mostrar();
            Cliente cliente_old = lista.FirstOrDefault(item => item.Id == int.Parse(id_cliente));
            if (lista == null)
            {
                return "Lista vacia";
            }else if (cliente_old == null)
            {
                return "No se encontro el id";
            }
            else if (Exist(cliente_new) && cliente_new.Id != int.Parse(id_cliente))
            {
                return "El cliente ingresado ya existe.";
            }
            else
            {
                cliente_old.Id = cliente_new.Id;
                cliente_old.Nombre = cliente_new.Nombre;
                cliente_old.Apellido = cliente_new.Apellido;
                cliente_old.Telefono = cliente_new.Telefono;
                cliente_old.Correo = cliente_new.Correo;
                archivoCliente.Modificar(lista);
                return "Se ha modificado el cliente";
            }
        }
    }
}
