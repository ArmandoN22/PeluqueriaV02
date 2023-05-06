using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface ICrud<Tipo>
    {
        string Guardar(Tipo tipo);
        List<Tipo> Mostrar();
        string Eliminar(int tipo);
        string Actualizar(Tipo tipo, string id_tipo);
    }
}
