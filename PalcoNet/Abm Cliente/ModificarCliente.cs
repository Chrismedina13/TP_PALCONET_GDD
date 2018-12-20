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
        ABMCliente cliente;
        //CRITERIOS ANTERIORES ANTES DE MODIFICAR UNO PUNTUAL
        String nombre, apellido, numeroDNI, email;
        public ModificarCliente(ABMCliente cl)
        {
            nombre = "";
            apellido = nombre;
            numeroDNI = apellido;
            email = numeroDNI;
            cliente = cl;
            InitializeComponent();
        }

        private void ModificarCliente_Load_1(object sender, EventArgs e)
        {
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public bool esVacio(String n)
        {
            return n == "";
        }

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

        //Buscador a partir de criterios
        private void btt_buscar_Click(object sender, EventArgs e)
        {
            String error = "";
            if (esVacio(textBoxDNI.Text.Trim()) && esVacio(textBoxEmail.Text.Trim()) && esVacio(textBoxApellido.Text.Trim()) && esVacio(textBoxNombre.Text.Trim()))
            {
                MessageBox.Show("Usted no ha puesto ningún criterio de busquedad. Rellene los campos por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!textBoxNombre.Text.Trim().Equals("") && !AyudaExtra.esStringLetra(textBoxNombre.Text.Trim()) || !textBoxApellido.Text.Trim().Equals("") && !AyudaExtra.esStringLetra(textBoxApellido.Text.Trim()))
                {
                    error += "Los campos Nombre y Apellido no pueden contener numeros\n";
                    MessageBox.Show("Los campos Nombre y Apellido no pueden contener numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!textBoxDNI.Text.Trim().Equals("") && !AyudaExtra.esStringNumerico(textBoxDNI.Text.Trim()))
                {
                    error += "El campo numero de documento no puede contener letras\n";
          //          MessageBox.Show("El campo numero de documento no puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
                }
                if (error != "") {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dataGridView1.DataSource = null;
                if (!esVacio(textBoxDNI.Text.Trim()))
                {
                    numeroDNI = textBoxDNI.Text.Trim();
                }
                if (!esVacio(textBoxEmail.Text.Trim()))
                {
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
                BusquedadYLlenarGrilla();
            }
        }

        public void BusquedadYLlenarGrilla() {
            DataTable ds = new DataTable();
            //BUSCAR
            DBConsulta.conexionAbrir();

            ds = DBConsulta.buscarClienteSegunCriterios2(nombre, apellido, numeroDNI, email);
            DBConsulta.conexionCerrar();
            configuracionGrilla(dataGridView1, ds);
            return;
        }

        // MODIFICA AL USER SELECIONADO, ABRIENDO UNA VENTANA NUEVA
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No has buscado a ningún usuario aún", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                String user = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                int userID = Convert.ToInt32(user);
                ModificarClienteSeleccionado mod = new ModificarClienteSeleccionado(userID, this);
                mod.Show();
            }
        }

        private void volver_boton_Click_1(object sender, EventArgs e)
        {
            cliente.Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //LIMPIAR CRITERIOS
            textBoxApellido.Text = "";
            textBoxDNI.Text = "";
            textBoxEmail.Text = "";
            textBoxNombre.Text = "";
        }


    }
}
