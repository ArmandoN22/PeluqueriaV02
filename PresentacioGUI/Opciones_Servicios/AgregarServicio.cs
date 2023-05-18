using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Entidades;
using System.Windows.Forms;

namespace PresentacioGUI
{
    public partial class AgregarServicio : Form
    {
        ServicioServicios servicioServicios = new ServicioServicios();

        public AgregarServicio()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        void Guardar()
        {
            if (txtId.Text == "" || txtNombre.Text == "" || txtPrecio.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Servicios servicios = new Servicios();
                    servicios.Id_Servicio = int.Parse(txtId.Text);
                    servicios.Nombre = txtNombre.Text;
                    servicios.Precio = float.Parse(txtPrecio.Text);
                    var mensaje = servicioServicios.Guardar(servicios);
                    MessageBox.Show(mensaje.ToUpper(), "Regristro Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiar();
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void Limpiar()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
