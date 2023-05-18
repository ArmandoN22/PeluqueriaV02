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
    public partial class MostrarEmpleados : Form
    {
        ServicioEmpleado servicioEmpleado = new ServicioEmpleado();
        int datoTabla;

        public MostrarEmpleados()
        {
            InitializeComponent();
            CargarGrilla();
            if (servicioEmpleado.Mostrar() == null)
            {
            }
            else
            {
                datoTabla = int.Parse(GrillaEmpleados.Rows[0].Cells[0].Value.ToString());
            }
            GrillaEmpleados.CellClick += GrillaEmpleados_CellClick;
        }

        void CargarGrilla()
        {
            if (servicioEmpleado.Mostrar() == null)
            {
                MessageBox.Show("NO HAY EMPLEADOS REGISTRADOS", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var item in servicioEmpleado.Mostrar())
                {
                    GrillaEmpleados.Rows.Add(item.Id, item.Nombre, item.Apellido, item.Telefono,
                    item.Direccion, item.FechaContratacion, item.Salario);
                }
            }

        }

        private void GrillaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void RefrescarGrilla()
        {
            GrillaEmpleados.Rows.Clear();
            GrillaEmpleados.Refresh();
            CargarGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }
        
        public void Editar()
        {
            Editar_Empleados editarEmpleados = new Editar_Empleados(datoTabla);
            try
            {
                if (servicioEmpleado.Mostrar() == null)
                {
                    MessageBox.Show("NO HAY EMPLEADOS PARA EDITAR", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    editarEmpleados.txtId.Text = GrillaEmpleados.CurrentRow.Cells[0].Value.ToString().Replace(" ", "");
                    editarEmpleados.txtNombre.Text = GrillaEmpleados.CurrentRow.Cells[1].Value.ToString();
                    editarEmpleados.txtApellido.Text = GrillaEmpleados.CurrentRow.Cells[2].Value.ToString();
                    editarEmpleados.txtTelefono.Text = GrillaEmpleados.CurrentRow.Cells[3].Value.ToString();
                    editarEmpleados.txtDireccion.Text = GrillaEmpleados.CurrentRow.Cells[4].Value.ToString();
                    editarEmpleados.dtpFecha.Text = GrillaEmpleados.CurrentRow.Cells[5].Value.ToString();
                    editarEmpleados.txtSalario.Text = GrillaEmpleados.CurrentRow.Cells[6].Value.ToString();
                    editarEmpleados.ShowDialog();
                    RefrescarGrilla();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        void Eliminar() {
            if (servicioEmpleado.Mostrar() == null)
            {
                MessageBox.Show("NO HAY EMPLEADOS PARA ELIMINAR", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (datoTabla != -1)
            {
                string msg = servicioEmpleado.Eliminar(datoTabla);
                GrillaEmpleados.Rows.Clear();
                GrillaEmpleados.Refresh();
                MessageBox.Show(msg);
                CargarGrilla();

            }

        }

        private void GrillaEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = e.RowIndex;
            DataGridViewRow fila = GrillaEmpleados.Rows[pos];
            datoTabla = int.Parse(fila.Cells[0].Value.ToString());
        }
    }
}
