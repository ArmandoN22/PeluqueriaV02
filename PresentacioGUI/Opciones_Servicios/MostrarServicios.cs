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
    public partial class MostrarServicios : Form
    {
        ServicioServicios servicioServicios = new ServicioServicios();
        int datoTabla;
        public MostrarServicios()
        {
            InitializeComponent();
            CargarGrilla();
            datoTabla = int.Parse(GrillaServicios.Rows[0].Cells[0].Value.ToString());
            GrillaServicios.CellClick += GrillaServicios_CellClick;
        }

        void CargarGrilla()
        {
            if (servicioServicios.Mostrar() == null)
            {
                MessageBox.Show("NO HAY SERVICIOS REGISTRADOS", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var item in servicioServicios.Mostrar())
                {
                    GrillaServicios.Rows.Add(item.Id_Servicio, item.Nombre, item.Precio);
                }
            }
        }

        public void RefrescarGrilla()
        {
            GrillaServicios.Rows.Clear();
            GrillaServicios.Refresh();
            CargarGrilla();
        }

        private void GrillaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        public void Editar()
        {
            Editar_Servicio editarServicio = new Editar_Servicio(datoTabla);
            try
            {
                editarServicio.txtId.Text = GrillaServicios.CurrentRow.Cells[0].Value.ToString().Replace(" ", "");
                editarServicio.txtNombre.Text = GrillaServicios.CurrentRow.Cells[1].Value.ToString();
                editarServicio.txtPrecio.Text = GrillaServicios.CurrentRow.Cells[2].Value.ToString();
                editarServicio.ShowDialog();
                RefrescarGrilla();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void GrillaServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = e.RowIndex;
            DataGridViewRow fila = GrillaServicios.Rows[pos];
            datoTabla = int.Parse(fila.Cells[0].Value.ToString());
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        void Eliminar()
        {
            if (datoTabla != -1)
            {
                string msg = servicioServicios.Eliminar(datoTabla);
                GrillaServicios.Rows.Clear();
                GrillaServicios.Refresh();
                MessageBox.Show(msg);
                CargarGrilla();

            }
        }
    }
}
