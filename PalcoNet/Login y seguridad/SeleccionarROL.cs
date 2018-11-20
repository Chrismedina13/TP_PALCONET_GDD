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
    public partial class SeleccionarROL : volver

    {
        String user;
        public class ComboboxRol
        {
            public string Text { get; set; }
            public object Value { get; set; }
        }

        public override string ToString()
        {
            return Text;
        }

        private void Test()
        {
            ComboboxRol item = new ComboboxRol();
            item.Text = "Rol a seleccionar";
            item.Value = 12;

            comboBoxRol.Items.Add(item);

            comboBoxRol.SelectedIndex = 0;

            MessageBox.Show((comboBoxRol.SelectedItem as ComboboxRol).Value.ToString());
        }

        public SeleccionarROL(String usuario)
        {
            user = usuario;
            InitializeComponent();
        }

        private void SeleccionarROL_Load(object sender, EventArgs e)
        {
            DataSet myDataSet = LoginSQL.ObtenerRoles(user);
 
            comboBoxRol.DataSource = myDataSet.Tables[0].DefaultView;
            comboBoxRol.DisplayMember = "Rol a seleccionar";

            comboBoxRol.BindingContext = this.BindingContext;
        }

        private void volver_boton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Boton Ingresar
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxRol.SelectedItem.ToString() == "") {
                MessageBox.Show("Seleccione un rol para continuar");
                return;
            }
            String rolSeleccionado = comboBoxRol.SelectedItem.ToString();
        }
    }
}
