using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PalcoNet.Login_y_seguridad;

namespace PalcoNet
{
    public partial class CambiarContra : Form
    {
        SqlConnection coneccion;
        SqlCommand cambiar;
        String nom;

        public CambiarContra(String nombre)
        {
            nom = nombre;
            InitializeComponent();
            coneccion = PalcoNet.Support.Conexion.conectar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PalcoNet.Explorador f2 = new PalcoNet.Explorador();
            f2.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != textBox2.Text) {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }
            
            coneccion.Open();
            cambiar = new SqlCommand("[SQLeados].actualizarContra", coneccion);
           cambiar.CommandType = CommandType.StoredProcedure;
           cambiar.Parameters.Add("@user", SqlDbType.VarChar).Value = Usuario.username;
           cambiar.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBox2.Text;
           cambiar.ExecuteNonQuery();

           String mensaje = "La password se ha cambiado correctamente";
           String caption = "Password cambiada";
           MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);

           PalcoNet.Explorador f2 = new PalcoNet.Explorador();
           f2.Show();
           this.Close();
        }

        private void CambiarContra_Load(object sender, EventArgs e)
        {
            labelUser.Text = nom;
        }
    }
}
