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
        List<Servicios> ListaServicios;
        ArchivoServicio archivoServicio = new ArchivoServicio();

        public string Actualizar(Servicios tipo, Servicios tipoDos)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(Servicios tipo)
        {
            throw new NotImplementedException();
        }

        public string Guardar(Servicios servicio)
        {
            try
            {

                var estado = archivoServicio.Guardar(servicio);
                if (ListaServicios != null)
                {
                    VerificarId(servicio);
                }

                return estado ? $"SERVICIO GUARDADO CON NOMBRE: {servicio.Nombre}" :
                $"ERROR AL GUARDAR EL SERVICIO :{servicio.Nombre.ToUpper()}";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string VerificarId(Servicios servicio)
        {
            string estado = "No";
            try
            {

                foreach (var item in ListaServicios)
                {
                    if (servicio.Id_Servicio.Equals(item.Id_Servicio))
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

        public List<Servicios> Mostrar()
        {
            return archivoServicio.Leer();
        }
    }
}
