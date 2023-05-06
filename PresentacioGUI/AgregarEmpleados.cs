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
    public partial class AgregarEmpleados : Form
    {
        ServicioEmpleado servicioEmpleado = new ServicioEmpleado();

        public AgregarEmpleados()
        {
            InitializeComponent();
        }


        //DataTime FecgaContratacion = new DataTime.Today;
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
            if (txtId.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" || txtTelefono.Text == "" || txtDireccion.Text == "" || dtpFecha.Text == "" || txtSalario.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Empleado empleado = new Empleado();
                    empleado.Id = int.Parse(txtId.Text);
                    empleado.Nombre = txtNombre.Text;
                    empleado.Apellido = txtApellido.Text;
                    empleado.Telefono = txtTelefono.Text;
                    empleado.Direccion = txtDireccion.Text;
                    empleado.FechaContratacion = DateTime.Parse(dtpFecha.Text);
                    empleado.Salario = double.Parse(txtSalario.Text);
                    var mensaje = servicioEmpleado.Guardar(empleado);
                    MessageBox.Show(mensaje.ToUpper(), "Regristro Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Limpiar(this, panelEstudiantes);
                    //IdCreciente();
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
            txtApellido.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            dtpFecha.Text = string.Empty;
            txtSalario.Text = string.Empty;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
