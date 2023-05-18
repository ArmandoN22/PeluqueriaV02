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

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
