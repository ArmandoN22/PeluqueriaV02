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

        

        public List<Cliente> GetList()
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

        public string Actualizar(Cliente tipo, Cliente tipoDos)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(Cliente tipo)
        {
            throw new NotImplementedException();
        }

        public string Guardar(Cliente cliente)
        {
            try
            {
                if (GetList() == null)
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
                Cliente exist = GetList().FirstOrDefault(item => item.Id == cliente.Id);
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

        public List<Cliente> Mostrar()
        {
            return archivoCliente.Leer();
        }

        public string Actualizar(Cliente tipo, string id_tipo)
        {
            throw new NotImplementedException();
        }
    }
}
