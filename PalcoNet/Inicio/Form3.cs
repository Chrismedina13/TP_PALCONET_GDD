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

namespace PalcoNet
{
    public partial class Form3 : Form
    {
        SqlConnection coneccion;
        SqlCommand cambiar;
        public Form3()
        {
            InitializeComponent();
            coneccion = Support.ConsultasSQL.conectar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PalcoNet.Form2 f2 = new PalcoNet.Form2();
            f2.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            coneccion.Open();
            cambiar = new SqlCommand("[SQLeados].actualizarContra", coneccion);
           cambiar.CommandType = CommandType.StoredProcedure;
           cambiar.Parameters.Add("@user", SqlDbType.VarChar).Value = Usuario.username;
           cambiar.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBox2.Text;
           cambiar.ExecuteNonQuery();

           String mensaje = "La password se ha cambiado correctamente";
           String caption = "Password cambiada";
           MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);

           PalcoNet.Form2 f2 = new PalcoNet.Form2();
           f2.Show();
           this.Close();
        }
    }
}
