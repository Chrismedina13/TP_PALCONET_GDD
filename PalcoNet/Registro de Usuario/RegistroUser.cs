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
using PalcoNet.Abm_Cliente;
using PalcoNet.Abm_Empresa_Espectaculo;


namespace PalcoNet.Registro_de_Usuario
{
    public partial class RegistroUser : Form
    {
        public bool huboerror = false;
        private Inicio login;
        public RegistroUser(Inicio ini)
       {
           login = ini;
           InitializeComponent();
        }

        private void RegistroUser_Load(object sender, EventArgs e)
        {
            String query = "SELECT rol_nombre FROM SQLEADOS.Rol where rol_id > 3";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            for (int i = 0; i < dt.Rows.Count; i++) {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }

            //LOS BOTONES CLIENTE Y EMPRESA SE VUELVEN INVISIBLES SI NO ESTÁN HABILITADOS
            if (!esRolHabilitado("Cliente"))
            {
                botonCliente.Visible = false;
            }
            if (!esRolHabilitado("Empresa"))
            {
                buttonEmpresa.Visible = false;
            }
        }

        private bool esRolHabilitado(String tipo) {
            String query = "SELECT COUNT(*) FROM SQLEADOS.Rol where rol_nombre LIKE '" + tipo + "' AND rol_estado = 1";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            return dt.Rows[0][0].ToString() == "1";
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
        
        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void cambiarEstadoError() {
            huboerror = true;
        }

        //REGISTRAR NUEVO CLIENTE
        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            AltaCliente aclien = new AltaCliente(this, true, null, false);
            aclien.Show();
            this.Close();
            return;
        }

        private void rolHabilitado(String rol) {
            String rolHabilitado = "SELECT CASE WHEN rol_estado = 1 THEN 'SI' ELSE 'NO' END AS 'Habilitado' FROM SQLEADOS.Rol where rol_nombre like '"+rol+"'";
        }


        public void terminar() {
            login.Show();
            this.Close();
        }

        //CREAR EMPRESA
        private void button1_Click_1(object sender, EventArgs e)
        {
            AltaEmpresa aemp = new AltaEmpresa(null, false, this);
            aemp.Show();
            this.Hide();
            return;
        }

        private void buttonRol_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("No has seleccionado un rol aún");
                return;
            }
            String rol = comboBox1.SelectedItem.ToString();
            ABM_Usuario.IngresarNuevoAdmin ad = new ABM_Usuario.IngresarNuevoAdmin(null, false, false, this, rol);
            ad.Show();
            this.Hide();
        }
    }
}
