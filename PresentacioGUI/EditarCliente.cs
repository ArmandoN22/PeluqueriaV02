using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Logica;
using System.Windows.Forms;

namespace PresentacioGUI
{
    public partial class EditarCliente : Form
    {
        ServicioCliente servicioCliente = new ServicioCliente();
        int idTabla;
        public EditarCliente(int id)
        {
            InitializeComponent();
            idTabla = id;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(int.Parse(txtId.Text.Replace(" ", "")), txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtCorreo.Text);
            var msg = servicioCliente.Actualizar(cliente, idTabla.ToString());

            var mostrar = new MostrarClientes();         
            mostrar.RefrescarGrilla();

            MessageBox.Show(msg);
            if(msg == "Se ha modificado el cliente")
            {
                Hide();
            }
            else
            {
                txtId.Text = string.Empty;
            }
        }



        private void EditarCliente_Load(object sender, EventArgs e)
        {
           
        }
    }
}
