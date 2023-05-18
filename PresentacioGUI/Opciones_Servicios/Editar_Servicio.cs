using Entidades;
using Logica;
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
    public partial class Editar_Servicio : Form
    {
        ServicioServicios servicioServicios = new ServicioServicios();  
        int idtabla;
        public Editar_Servicio(int id)
        {
            InitializeComponent();
            idtabla = id;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Servicios servicio = new Servicios(int.Parse(txtId.Text.Replace(" ", "")), txtNombre.Text, float.Parse(txtPrecio.Text));
            var msg = servicioServicios.Actualizar(servicio, idtabla.ToString());

            var mostrar = new MostrarServicios();
            mostrar.RefrescarGrilla();

            MessageBox.Show(msg);
            if (msg == "Se ha modificado el servicio")
            {
                Hide();
            }
            else
            {
                txtId.Text = string.Empty;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
