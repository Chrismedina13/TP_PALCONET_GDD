﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Support;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class EliminarEmpresa : Form
    {
        public EliminarEmpresa()
        {
            InitializeComponent();
        }

        private void eliminar_empresa_Load(object sender, EventArgs e)
        {
            ConsultasSQLEmpresa.cargarGriddEmpresa(dataGriddView1, "", "", "");
            dataGriddView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
        }


        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGriddView1.SelectedRows.Count > 0)
            {
                var row = dataGriddView1.SelectedRows[0];
                textBoxRazonSocial .Text = row.Cells["empresa_razon_social"].Value.ToString();
                textBoxCuit.Text = row.Cells["empresa_cuit"].Value.ToString();
                textBoxMail.Text = row.Cells["empresa_email"].Value.ToString();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxRazonSocial_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCuit_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void dataGriddView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
