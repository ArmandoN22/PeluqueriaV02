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

        public MostrarServicios()
        {
            InitializeComponent();
            CargarGrilla();
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

        private void GrillaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
