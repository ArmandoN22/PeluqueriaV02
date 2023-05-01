using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public interface IArchivo<Tipo>
    {
        bool Guardar(Tipo tipo);
        List<Tipo> Leer();
        Tipo Mapear(string linea);
        bool Modificar(List<Tipo> List);
    }
}
