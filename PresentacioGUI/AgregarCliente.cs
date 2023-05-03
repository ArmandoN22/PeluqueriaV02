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
    public partial class AgregarCliente : Form
    {
        ServicioCliente servicioCliente = new ServicioCliente();

        public AgregarCliente()
        {
            InitializeComponent();
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        void Guardar()
        {
            if (txtId.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" )
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = int.Parse(txtId.Text);
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Telefono = txtTelefono.Text;
                    cliente.Correo = txtCorreo.Text;
                    var mensaje = servicioCliente.Guardar(cliente);
                    MessageBox.Show(mensaje.ToUpper(), "Regristro Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Limpiar(this, panelEstudiantes);
                    //IdCreciente();
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
