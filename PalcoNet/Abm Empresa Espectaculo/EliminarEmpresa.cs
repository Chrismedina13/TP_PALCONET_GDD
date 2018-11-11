using System;
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
            ConsultasSQL.cargarGriddEmpresa(dataGridView1, "", "", "");
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
        }


        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                textBoxRazonSocial .Text = row.Cells["empresa_razon_social"].Value.ToString();
                textBoxCuit.Text = row.Cells["empresa_cuit"].Value.ToString();
                textBoxMail.Text = row.Cells["empresa_email"].Value.ToString();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
