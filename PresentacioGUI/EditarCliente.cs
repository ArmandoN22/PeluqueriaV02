﻿using System;
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
        public EditarCliente()
        {
            InitializeComponent();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        int Id;

        private void EditarCliente_Load(object sender, EventArgs e)
        {
            Id = int.Parse(txtId.Text);
            txtId.Enabled = false;
        }
    }
}
