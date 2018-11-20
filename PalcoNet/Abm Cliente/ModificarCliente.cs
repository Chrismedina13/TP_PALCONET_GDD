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

namespace PalcoNet.Abm_Cliente
{
    public partial class ModificarCliente : volver
    {
        public static String userAModificar;

        public ModificarCliente()
        {
            InitializeComponent();
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void btt_buscar_Click(object sender, EventArgs e)
        {
            if (ConsultaGeneral.esVacio(textBoxDNI.Text.Trim()) && ConsultaGeneral.esVacio(textBoxEmail.Text.Trim()) && ConsultaGeneral.esVacio(textBoxApellido.Text.Trim()) && ConsultaGeneral.esVacio(textBoxNombre.Text.Trim()))
            {
                MessageBox.Show("Usted no ha puesto ningún criterio de busquedad. Rellene los campos por favor");
                return;
            }
            else
            {
                String nombre = "", apellido = "", email = "", numeroDNI = "";
                if (!ConsultaGeneral.esVacio(textBoxDNI.Text.Trim()))
                {
                    numeroDNI = textBoxDNI.Text;
                }
                if (!ConsultaGeneral.esVacio(textBoxEmail.Text.Trim()))
                {
                    email = textBoxEmail.Text;
                }

                if (!ConsultaGeneral.esVacio(textBoxNombre.Text.Trim()))
                {
                    nombre = textBoxNombre.Text;
                }
                if (!ConsultaGeneral.esVacio(textBoxApellido.Text.Trim()))
                {
                    apellido = textBoxApellido.Text;
                }
                consultasSQLCliente.llenarDGVCliente(dataGridView1, nombre, apellido, numeroDNI, email);

                /*         DialogResult = DialogResult.OK;  */
                return;
            }
        }

        // MODIFICA AL USER SELECIONADO, ABRIENDO UNA VENTANA NUEVA
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No has buscado a ningún usuario aún");
                return;
            }
            else
            {
                String user = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                ModificarClienteSeleccionado mcs = new ModificarClienteSeleccionado();
                userAModificar = user;
                mcs.Show();
                
              //  ConsultasSQL.darDeBaja(dataGridView1, user);
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

                /*         DialogResult = DialogResult.OK;
                 * */
                Close();
            }
        }
    }
}
