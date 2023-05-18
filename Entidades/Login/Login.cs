using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Login
    {
        public Login()
        {
        }

        public Login(string usuario, string contraseña, string correoElectronico)
        {
            Usuario = usuario;
            Contraseña = contraseña;
            CorreoElectronico = correoElectronico;
        }

        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string CorreoElectronico { get; set; }

        public override string ToString()
        {
            return $"{Usuario};{Contraseña};{CorreoElectronico}";
        }
    }
}
