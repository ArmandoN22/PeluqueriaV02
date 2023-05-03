using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Logica
{
    public class ServicioCliente : ICrud<Cliente>
    {
        List<Cliente> ListaCliente;
        ArchivoCliente archivoCliente = new ArchivoCliente();

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

                var estado = archivoCliente.Guardar(cliente);
                if (ListaCliente != null)
                {
                    VerificarId(cliente);
                }

                return estado ? $"CLIENTE GUARDADO CON NOMBRE: {cliente.Nombre}" :
                $"ERROR AL GUARDAR EL CLIENTE :{cliente.Nombre.ToUpper()}";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string VerificarId(Cliente cliente)
        {
            string estado = "No";
            try
            {

                foreach (var item in ListaCliente)
                {
                    if (cliente.Id.Equals(item.Id))
                    {
                        estado = "Si";

                    }
                }

            }
            catch (Exception e)
            {

                return e.Message;
            }
            return estado;
        }

        public List<Cliente> Mostrar()
        {
            return archivoCliente.Leer();
        }
    }
}
