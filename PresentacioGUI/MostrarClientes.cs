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
    public partial class MostrarClientes : Form
    {
        ServicioCliente servicioCliente = new ServicioCliente();

        public MostrarClientes()
        {
            InitializeComponent();
            CargarGrilla();
        }

        void CargarGrilla()
        {
            if (servicioCliente.Mostrar() == null)
            {
                MessageBox.Show("NO HAY CLIENTES REGISTRADOS", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var item in servicioCliente.Mostrar())
                {
                    GrillaClientes.Rows.Add(item.Id, item.Nombre, item.Apellido, item.Telefono,
                    item.Correo);
                }
            }

        }

        private void MostrarClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        public void Editar()
        {
            EditarCliente editarCliente = new EditarCliente();
            try
            {
                editarCliente.txtId.Text = GrillaClientes.CurrentRow.Cells[0].Value.ToString();
                editarCliente.txtNombre.Text = GrillaClientes.CurrentRow.Cells[1].Value.ToString();
                editarCliente.txtApellido.Text = GrillaClientes.CurrentRow.Cells[2].Value.ToString();
                editarCliente.txtTelefono.Text = GrillaClientes.CurrentRow.Cells[3].Value.ToString();
                editarCliente.txtCorreo.Text = GrillaClientes.CurrentRow.Cells[4].Value.ToString(); ;
                editarCliente.ShowDialog();
                RefrescarGrilla();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void RefrescarGrilla()
        {
            GrillaClientes.Rows.Clear();
            GrillaClientes.Refresh();
            CargarGrilla();
        }

        private void GrillaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
