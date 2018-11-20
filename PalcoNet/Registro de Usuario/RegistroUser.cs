using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Login_y_seguridad;
using PalcoNet.Support;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class RegistroUser : Form
    {
        public RegistroUser()
       {
           InitializeComponent();
           llenarComboBox();
        }

        private void llenarComboBox() {
            DataSet myDataSet = LoginSQL.ObtenerRolesSinAdmin();
            int indice = 0;
            string nombreRol;

            while (indice < DBConsulta.tamanioDataSet(myDataSet))
            {
                nombreRol = myDataSet.Tables[0].Rows[indice][0].ToString();
                comboRoles.Items.Add(nombreRol);
                indice++;
            }
            comboRoles.Items.Insert(0, "Seleccione un rol");
            comboRoles.SelectedIndex = 0;
        }

        private void RegistroUser_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreUser_TextChanged(object sender, EventArgs e)
        {

        }

        //BOTON CLIENTE
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private bool comprobarSiDatosEstanLlenos() {
            if (txtNombreUser.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtContra.Text.Trim() == "" || txtRepContra.Text.Trim()=="")
            {
                MessageBox.Show("Ingrese nombre de contraseña en ambos campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtContra.Text.Trim() != txtRepContra.Text.Trim()) {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboRoles.SelectedIndex ==  0)
            {
                MessageBox.Show("Debe seleccionar un rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            if (comprobarSiDatosEstanLlenos())
            {
                DateTime myDateTime = DateTime.Now;
                String sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                String comandoPrincipal = "INSERT INTO SQLEADOS.Usuario (usuario_nombre, usuario_password,usuario_tipo, usuario_fecha_creacion) values (" + txtNombreUser.Text.Trim() + ", " + txtContra.Text.Trim() + ", " + comboRoles.SelectedItem.ToString() + ", " + sqlFormattedDate + ")";
                String rolID = consultarROLIDBuscaod(comboRoles.SelectedItem.ToString());
                String comandoUserXRol = "INSERT INTO SQLEADOS.UserXRol(userXRol_rol, userXRol_usuario) Select " + rolID + ", usuario_Id from SQLEADOS.Rol, SQLEADOS.Usuario where usuario_nombre LIKE " + txtNombreUser.Text.Trim();
             
                bool nombreUserDisponible = true;
                if (!RegistroSQL.nombreUserDisponible(txtNombreUser.Text.Trim()))
                {
                    nombreUserDisponible = false;
                }

            }
            return;
        }

        private static String consultarROLIDBuscaod(String rol) {
            String query = "SELECT rol_Id from SQLEADOS.Rol where rol_nombre LIKE " + rol;
            DataSet res = DBConsulta.ConectarConsulta(query);
            return res.Tables[0].Rows[0][0].ToString();
        }
    }
}
