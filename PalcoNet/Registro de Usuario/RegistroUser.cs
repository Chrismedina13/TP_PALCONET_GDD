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
        /*
        private bool comprobarSiDatosEstanLlenos() {
            if (txtNombreUser.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtContra.Text.Trim() == "" || txtRepContra.Text.Trim()=="")
            {
                MessageBox.Show("Ingrese la contraseña en ambos campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtContra.Text.Trim() != txtRepContra.Text.Trim()) {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
            
        }*/

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void cambiarEstadoError() {
            huboerror = true;
        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            AltaCliente aclien = new AltaCliente(this, true);
            aclien.Show();
            this.Close();
            return;
        }



        //CREAR EMPRESA
        private void button1_Click_1(object sender, EventArgs e)
        {
            AltaEmpresa aemp = new AltaEmpresa(0);
            aemp.Show();
            this.Close();
            return;
        }
    }
}
