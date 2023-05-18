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
    public partial class Editar_Empleados : Form
    {
        ServicioEmpleado servicioempleado = new ServicioEmpleado();
        int idtabla;
        public Editar_Empleados(int id)
        {
            InitializeComponent();
            idtabla = id;
        }

        private void Editar_Empleados_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado(int.Parse(txtId.Text.Replace(" ", "")), txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, DateTime.Parse(dtpFecha.Text), double.Parse(txtSalario.Text));
            var msg = servicioempleado.Actualizar(empleado, idtabla.ToString());

            var mostrar = new MostrarEmpleados();
            mostrar.RefrescarGrilla();

            MessageBox.Show(msg);
            if (msg == "Se ha modificado el empleado")
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
