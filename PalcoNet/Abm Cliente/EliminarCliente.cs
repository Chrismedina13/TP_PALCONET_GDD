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
        ABMCliente clie;
        public EliminarCliente(ABMCliente abm)
        {
            clie = abm;
            InitializeComponent();
        }
        

        /*CARGA LA TABLA, COMIENZA SIN NADA PORQUE NO HAY NADA PARA MOSTRAR, AUNQUE SE PODRÍA TAMBIÉN
         PONER POR DEFAULT QUE ME PONGA TODOS, PERO PARA EVITAR QUE SE TARDE SEGUNDOS EN ENTRAR MEJOR QUE
         COMIENCE SIN NADA*/

        private void EliminarCliente_Load(object sender, EventArgs e)
        {
        }

      

        private void eliminar_empresa_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            clie.Show();
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

        public bool esVacio(String n)
        {
            return n == "";
        }


        /* BOTON BUSCAR*/
        private void button1_Click(object sender, EventArgs e)
        {
            String error = "";
            if (esVacio(textBoxDNI.Text.Trim()) && esVacio(textBoxEmail.Text.Trim()) && esVacio(textBoxApellido.Text.Trim()) && esVacio(textBoxNombre.Text.Trim()))
            {
                MessageBox.Show("Usted no ha puesto ningún criterio de busquedad. Rellene los campos por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                if (!textBoxNombre.Text.Trim().Equals("") && !AyudaExtra.esStringLetra(textBoxNombre.Text.Trim()) || !textBoxApellido.Text.Trim().Equals("") && !AyudaExtra.esStringLetra(textBoxApellido.Text.Trim()))
                {
                    error += "Los campos Nombre y Apellido no pueden contener numeros\n";
      //              MessageBox.Show("Los campos Nombre y Apellido no pueden contener numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //              return;
                }
                if (!textBoxDNI.Text.Trim().Equals("") && !AyudaExtra.esStringNumerico(textBoxDNI.Text.Trim())) {
                    error += "El campo numero de documento no puede contener letras\n";
          //          MessageBox.Show("El campo numero de documento no puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
                }
                if (error != "") {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dataGridView1.DataSource = null;
                String nombre="", apellido="", email="", numeroDNI="";
                if (!esVacio(textBoxDNI.Text.Trim())) {
                    numeroDNI = textBoxDNI.Text.Trim();
                }
                if (!esVacio(textBoxEmail.Text.Trim())) {
                    email = textBoxEmail.Text.Trim();
                }

                if (!esVacio(textBoxNombre.Text.Trim()))
                {
                    nombre = textBoxNombre.Text.Trim();
                }
                if (!esVacio(textBoxApellido.Text.Trim()))
                {
                    apellido = textBoxApellido.Text.Trim();
                }
                DataTable ds = new DataTable();
                DBConsulta.conexionAbrir();
                ds = DBConsulta.buscarClienteSegunCriterios3(nombre, apellido, numeroDNI, email);
                configuracionGrilla(dataGridView1, ds);
                DBConsulta.conexionCerrar();
                
     //           consultasSQLCliente.llenarDGVCliente(dataGridView1, nombre, apellido, numeroDNI, email);

       /*         DialogResult = DialogResult.OK;  */
                return;
            }
        }

        //Configura el tamanio de cada Columna
        private static void configuracionGrilla(DataGridView dgv, DataTable source)
        {
            dgv.DataSource = source;
            DataGridViewColumn column = dgv.Columns[0];
            column.Width = 50;
            DataGridViewColumn column1 = dgv.Columns[1];
            column1.Width = 60;
            DataGridViewColumn column2 = dgv.Columns[2];
            column2.Width = 130;
            DataGridViewColumn column3 = dgv.Columns[3];
            column3.Width = 100;
            DataGridViewColumn column4 = dgv.Columns[4];
            column4.Width = 100;
            DataGridViewColumn column5 = dgv.Columns[5];
            column4.Width = 90;
            return;
        }

        /*BOTON DAR DE BAJA, LA BAJA ES LÓGICA*/
        private void btnModificar_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No has buscado a ningún usuario aún", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String userId = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
       //         DBConsulta.darDeBajaUser(Int32.Parse(user));
                String comando =  "UPDATE SQLEADOS.Usuario SET usuario_estado = 0 WHERE usuario_Id = "+userId;
                DBConsulta.AbrirCerrarModificarDB(comando);
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                
       /*         DialogResult = DialogResult.OK;
        * */
          //      Close();
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

        private void volver_boton_Click_1(object sender, EventArgs e)
        {
            clie.Show();
            this.Close();
        }

        //LIMPIAR CRITERIOS
        private void button1_Click_1(object sender, EventArgs e)
        {
            textBoxApellido.Text = "";
            textBoxDNI.Text = "";
            textBoxEmail.Text = "";
            textBoxNombre.Text = "";
        }

    }
}
