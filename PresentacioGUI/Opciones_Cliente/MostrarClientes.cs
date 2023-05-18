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
        int datoTabla;
        public MostrarClientes()
        {
            InitializeComponent();
            CargarGrilla(); 
            if (servicioCliente.Mostrar() == null)
            {
            }
            else
            {
                datoTabla = int.Parse(GrillaClientes.Rows[0].Cells[0].Value.ToString());
            }
            //datoTabla = int.Parse(GrillaClientes.Rows[0].Cells[0].Value.ToString());
            GrillaClientes.CellClick += GrillaClientes_CellClick;
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
        void Eliminar()
        {
            if (servicioCliente.Mostrar() == null)
            {
                MessageBox.Show("NO HAY CLIENTES PARA ELIMINAR", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (datoTabla != -1)
            {
                string msg = servicioCliente.Eliminar(datoTabla);
                GrillaClientes.Rows.Clear();
                GrillaClientes.Refresh();
                MessageBox.Show(msg);
                CargarGrilla();

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
            EditarCliente editarCliente = new EditarCliente(datoTabla);
            try
            {
                if (servicioCliente.Mostrar() == null)
                {
                    MessageBox.Show("NO HAY CLIENTES PARA EDITAR", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    editarCliente.txtId.Text = GrillaClientes.CurrentRow.Cells[0].Value.ToString().Replace(" ", "");
                    editarCliente.txtNombre.Text = GrillaClientes.CurrentRow.Cells[1].Value.ToString();
                    editarCliente.txtApellido.Text = GrillaClientes.CurrentRow.Cells[2].Value.ToString();
                    editarCliente.txtTelefono.Text = GrillaClientes.CurrentRow.Cells[3].Value.ToString();
                    editarCliente.txtCorreo.Text = GrillaClientes.CurrentRow.Cells[4].Value.ToString(); ;
                    editarCliente.ShowDialog();
                    RefrescarGrilla();
                }
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


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void GrillaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = e.RowIndex;
            DataGridViewRow fila = GrillaClientes.Rows[pos];
            datoTabla = int.Parse(fila.Cells[0].Value.ToString());
        }

        private void GrillaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
