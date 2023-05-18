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
    public partial class FormularioMenu : Form
    {
        public FormularioMenu()
        {
            InitializeComponent();
            PersonalizacionDesing();
        }

        private void PersonalizacionDesing()
        {
            panelEmpleadoSubMenu.Visible = false;
            panelServicioSubMenu.Visible = false;
            panelClienteSubMenu.Visible = false;

        }

        private void OcultarSubMenu()
        {
            if (panelEmpleadoSubMenu.Visible == true)
                panelEmpleadoSubMenu.Visible = false;
            if (panelServicioSubMenu.Visible == true)
                panelServicioSubMenu.Visible = false;
            if (panelClienteSubMenu.Visible == true)
            {
                panelClienteSubMenu.Visible = false;
            }
        }

        private void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                OcultarSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        #region Empleados

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelEmpleadoSubMenu);
        }


        private void btnAgregarEmpleados_Click(object sender, EventArgs e)
        {
            FormulariosFijo(new AgregarEmpleados());
            OcultarSubMenu();
        }

        private void btnMostrarEmpleados_Click(object sender, EventArgs e)
        {
            FormulariosFijo(new MostrarEmpleados());
            OcultarSubMenu();
        }
        #endregion

        #region Servicios
        private void btnServicios_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelServicioSubMenu);
        }

        private void btnAgregarServicios_Click(object sender, EventArgs e)
        {
            FormulariosFijo(new AgregarServicio());
            OcultarSubMenu();
        }

        private void btnMostrarServicios_Click(object sender, EventArgs e)
        {
            FormulariosFijo(new MostrarServicios());
            OcultarSubMenu();
        }

        #endregion

        #region Clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelClienteSubMenu);
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FormulariosFijo(new AgregarCliente());
            OcultarSubMenu();
        }

        private void btnMostrarClientes_Click(object sender, EventArgs e)
        {
            FormulariosFijo(new MostrarClientes());
            OcultarSubMenu();
        }
        #endregion

        public Form formActivo = null;
        public void FormulariosFijo(Form formHijo)
        {
            if (formActivo != null)
                formActivo.Close();
            formActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelFormularioFijo.Controls.Add(formHijo);
            panelFormularioFijo.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }
    }
}
