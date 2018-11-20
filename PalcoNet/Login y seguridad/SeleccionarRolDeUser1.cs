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

namespace PalcoNet.Login_y_seguridad
{
    public partial class SeleccionarRolDeUser1 : volver
    {
        String user;
        LOGIN anterior;

        public SeleccionarRolDeUser1(LOGIN anterior1, String usuario)
        {
            user = usuario;
            anterior = anterior1;
            InitializeComponent();
            cargarDatosVista();
        }

        public class ComboboxRol
        {
            public string Text { get; set; }
            public object Value { get; set; }
        }

        private void cargarDatosVista()
        {
            DataSet myDataSet = LoginSQL.ObtenerRoles(user);
            int indice = 0;
            string nombreRol;
            label4.Text = user;

            while (indice < DBConsulta.tamanioDataSet(myDataSet))
            {
                nombreRol = myDataSet.Tables[0].Rows[indice][0].ToString();
                comboBoxRol.Items.Add(nombreRol);
                indice++;
            }
            comboBoxRol.Items.Insert(0, "Seleccione un rol");
            comboBoxRol.SelectedIndex = 0;
        }

        private void volver_boton_Click_1(object sender, EventArgs e)
        {
            anterior.Show();
            this.Close();
        }

        private void SeleccionarRolDeUser1_Load(object sender, EventArgs e)
        {

        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            if (comboBoxRol.SelectedItem.ToString() == "Seleccione un rol")
            {
                MessageBox.Show("Seleccione un rol para continuar");
                return;
            }
            String rolSeleccionado = comboBoxRol.SelectedItem.ToString();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
