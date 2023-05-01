using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacioGUI
{
    public partial class RegistrarUsuarios : Form
    {
        public RegistrarUsuarios()
        {
            InitializeComponent();
        }

        private void btnVoler_Click(object sender, EventArgs e)
        {
            Salir();
        }

        void Salir()
        {
            this.Close();
            Login login = new Login();
        }

        private void RegistrarUsuarios_Load(object sender, EventArgs e)
        {

        }

    }

    //HOLA MUNDO
}
