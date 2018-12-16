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
        ABMEmpresa em;
        public EliminarEmpresa(ABMEmpresa empresa)
        {
            em = empresa;
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
            em.Show();
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
            String razonSocial = textBoxRazonSocial.Text;
            String cuit = textBoxCuit.Text;
            String email = textBoxMail.Text;

            if (textBoxRazonSocial.Text.Trim() == "" | textBoxCuit.Text.Trim() == "" | textBoxMail.Text.Trim() == "")
            {
                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!ConsultasSQLEmpresa.existeCuit(textBoxCuit.Text))
            {
                MessageBox.Show("La empresa ingresada ya esta dado de baja o no existe. Para darlo de alta ingrese en Modificar empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var respuesta = MessageBox.Show("¿Estas seguro?", "Confirme borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {

                    ConsultasSQLEmpresa.darDeBajaEmpresa(razonSocial,cuit,email);
                    this.limpiarCuadrosDeTexto();
                    ConsultasSQLEmpresa.cargarGriddEmpresa(dataGriddView1, "", "", "");
                }
                else return;
            }




        }

        private void limpiarCuadrosDeTexto()
        {
            textBoxRazonSocial.Text = "";
            textBoxMail.Text = "";
            textBoxCuit.Text = "";
            
        }

        private void dataGriddView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCuit_KeyUp(object sender, KeyEventArgs e)
        {

            ConsultasSQLEmpresa.cargarGriddEmpresa(dataGriddView1, textBoxRazonSocial.Text, textBoxCuit.Text, textBoxMail.Text);
        }

        private void txtMail_KeyUp(object sender, KeyEventArgs e)
        {

            ConsultasSQLEmpresa.cargarGriddEmpresa(dataGriddView1, textBoxRazonSocial.Text, textBoxCuit.Text, textBoxMail.Text);
        }

        private void txtRazonSocial_KeyUp(object sender, KeyEventArgs e)
        {

            ConsultasSQLEmpresa.cargarGriddEmpresa(dataGriddView1, textBoxRazonSocial.Text, textBoxCuit.Text, textBoxMail.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxCuit.Text = "";
            textBoxMail.Text = "";
            textBoxRazonSocial.Text = "";
        }

     

    }
}
