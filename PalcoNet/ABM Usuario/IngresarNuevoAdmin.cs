using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Globalization;
using System.Data.SqlClient;
using PalcoNet.Support;

namespace PalcoNet.ABM_Usuario
{
    public partial class IngresarNuevoAdmin : Form
    {
        ABMUSUARIO exx;
        public IngresarNuevoAdmin(ABMUSUARIO ex)
        {
            exx = ex;
            InitializeComponent();
        }

        //BOTON VOLVER EN REALIDAD
        private void buttonCliente_Click(object sender, EventArgs e)
        {
            exx.Show();
            this.Close();
        }

        private void buttonEmpresa_Click(object sender, EventArgs e)
        {
            Abm_Empresa_Espectaculo.EliminarEmpresa form = new Abm_Empresa_Espectaculo.EliminarEmpresa();
            form.Show();
            this.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void botoncrear_Click(object sender, EventArgs e)
        {
            if (textBoxcontra.Text != textBoxrepecontra.Text) {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }
            string comando = "INSERT INTO SQLEADOS.Usuario(usuario_nombre, usuario_password, usuario_administrador) VALUES ('"+textBoxNombre.Text+"' , '"+textBoxcontra.Text+"', 1);";
            DBConsulta.modificarDatosDeDB(comando);
        }

       
    }
}
