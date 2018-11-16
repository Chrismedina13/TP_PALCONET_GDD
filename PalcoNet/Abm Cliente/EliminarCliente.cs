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
    public partial class EliminarCliente : volver
    {
        public EliminarCliente()
        {
            InitializeComponent();
        }
        

        /*CARGA LA TABLA, COMIENZA SIN NADA PORQUE NO HAY NADA PARA MOSTRAR, AUNQUE SE PODRÍA TAMBIÉN
         PONER POR DEFAULT QUE ME PONGA TODOS, PERO PARA EVITAR QUE SE TARDE SEGUNDOS EN ENTRAR MEJOR QUE
         COMIENCE SIN NADA*/
        private void EliminarCliente_Load(object sender, EventArgs e)
        {
            consultasSQLCliente.llenarDGVCliente(dataGridView1, "", "", "", "");
            
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
        }

      

        private void eliminar_empresa_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* BOTON BUSCAR */

        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                
                textBoxEmail.Text = row.Cells["cliente_email"].Value.ToString();
                textBoxApellido.Text = row.Cells["cliente_apellido"].Value.ToString();
                textBoxNombre.Text = row.Cells["cliente_nombre"].Value.ToString();
                textBoxDNI.Text = row.Cells["cliente_cliente_numero_documento"].Value.ToString();
            }
        }

        private bool esVacio(String n)
        {
            return n == "";
        }


        /* BOTON BUSCAR*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (esVacio(textBoxDNI.Text.Trim()) && esVacio(textBoxEmail.Text.Trim()) && esVacio(textBoxApellido.Text.Trim()) && esVacio(textBoxNombre.Text.Trim()))
            {
                MessageBox.Show("Usted no ha puesto ningún criterio de busquedad. Rellene los campos por favor");
                return;
            }
            else {
                String nombre="", apellido="", email="", numeroDNI="";
                if (!esVacio(textBoxDNI.Text.Trim())) {
                    numeroDNI = textBoxDNI.Text;
                }
                if (!esVacio(textBoxEmail.Text.Trim())) {
                    email = textBoxEmail.Text;
                }

                if (!esVacio(textBoxNombre.Text.Trim()))
                {
                    nombre = textBoxNombre.Text;
                }
                if (!esVacio(textBoxApellido.Text.Trim()))
                {
                    apellido = textBoxApellido.Text;
                }
                consultasSQLCliente.llenarDGVCliente(dataGridView1, nombre, apellido, numeroDNI, email);

       /*         DialogResult = DialogResult.OK;  */
                return;
            }
        }

        /*BOTON DAR DE BAJA, LA BAJA ES LÓGICA*/
        private void btnModificar_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No has buscado a ningún usuario aún");
                return;
            }
            else
            {
                String user = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                ConsultasSQL.darDeBaja(dataGridView1, user);
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

       /*         DialogResult = DialogResult.OK;
        * */
                Close();
            }
        }

        private void dataGridEliminarEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
