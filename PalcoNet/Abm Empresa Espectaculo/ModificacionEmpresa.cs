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
    public partial class ModificacionEmpresa : Form
    {
        public ModificacionEmpresa()
        {
            InitializeComponent();
        }

        private void ModificacionEmpresa_Load(object sender, EventArgs e)
        {
            ConsultasSQLEmpresa.cargarGriddEmpresaModificar(dataGridView1, "", "", "");
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
        }

        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                textBoxRazonSocial.Text = row.Cells["empresa_razon_social"].Value.ToString();
                textBoxCuit.Text = row.Cells["empresa_cuit"].Value.ToString();
                textBoxMail.Text = row.Cells["empresa_email"].Value.ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            String razonSocial = textBoxRazonSocial.Text;
            String cuit = textBoxCuit.Text;
            String email = textBoxMail.Text;

            if (textBoxRazonSocial.Text.Trim() == "" | textBoxCuit.Text.Trim() == "" | textBoxMail.Text.Trim() == "")
            {
                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                    ModificarEmpresaElegida form = new ModificarEmpresaElegida(razonSocial, email, cuit);
                    form.Show();
                    this.limpiarCuadrosDeTexto();
                    ConsultasSQLEmpresa.cargarGriddEmpresa(dataGridView1, "", "", "");
                    this.Close();
                
            }

        }

        private void limpiarCuadrosDeTexto()
        {
            textBoxRazonSocial.Text = "";
            textBoxMail.Text = "";
            textBoxCuit.Text = "";

        }

        private void txtCuit_KeyUp(object sender, KeyEventArgs e)
        {

            ConsultasSQLEmpresa.cargarGriddEmpresa(dataGridView1, textBoxRazonSocial.Text, textBoxCuit.Text, textBoxMail.Text);
        }

        private void txtMail_KeyUp(object sender, KeyEventArgs e)
        {

            ConsultasSQLEmpresa.cargarGriddEmpresa(dataGridView1, textBoxRazonSocial.Text, textBoxCuit.Text, textBoxMail.Text);
        }

        private void txtRazonSocial_KeyUp(object sender, KeyEventArgs e)
        {

            ConsultasSQLEmpresa.cargarGriddEmpresa(dataGridView1, textBoxRazonSocial.Text, textBoxCuit.Text, textBoxMail.Text);
        }
    }
}
