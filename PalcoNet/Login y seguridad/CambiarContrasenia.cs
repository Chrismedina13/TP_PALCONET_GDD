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
using PalcoNet.Support;

namespace PalcoNet
{
    public partial class CambiarContra : Form
    {
        SqlConnection coneccion;
        SqlCommand cambiar;
        String nom;
        Explorador exx;
        bool deInicio;
        Inicio ini;
        public CambiarContra(String nombre, Explorador ex, Inicio i, bool vieneDeInicio)
        {
            if(vieneDeInicio) {
                ini = i;
            }
            deInicio = vieneDeInicio;
            exx = ex;
            nom = nombre;
            InitializeComponent();
            coneccion = PalcoNet.Support.Conexion.conectar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (deInicio)
            {
                ini.Show();
                this.Close();
            }
            else {
                exx.Show();
                this.Close();
            }
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

           String nombre = Usuario.username;
           String comando = "SELECT usuario_primer_ingreso FROM SQLEADOS.Usuario where usuario_nombre LIKE '" + nombre + "'";
           DBConsulta.conexionAbrir();
           DataTable dt = DBConsulta.obtenerConsultaEspecifica(comando);
           DBConsulta.conexionCerrar();
           //ES TIPO BIT, 1 SIGNIFICA QUE ES SU PRIMER INGRESO
           string COSO = dt.Rows[0][0].ToString();
           if (COSO == "True")
           {
               DBConsulta.conexionAbrir();
               comando = "UPDATE SQLEADOS.Usuario SET usuario_primer_ingreso = 0  where usuario_nombre LIKE '" + nombre + "'";
               DBConsulta.modificarDatosDeDB(comando);
               DBConsulta.conexionCerrar();
           }
            

           exx.Show();
           this.Close();
        }

        private void CambiarContra_Load(object sender, EventArgs e)
        {
            labelUser.Text = nom;
        }
    }
}
