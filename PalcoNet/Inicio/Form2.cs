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
using System.Configuration;

namespace PalcoNet
{
    public partial class Form2 : Form
    {
        string rol;

        SqlConnection coneccion;
        SqlCommand cargarfun, cargaradmin;

        public Form2()
        {
            rol = Usuario.Rol;
            InitializeComponent();
            coneccion = PalcoNet.Support.Conexion.conectar();
            coneccion.Open();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.Text = rol;
            if (rol.Equals("Administrativo"))
            {
                cargaradmin = new SqlCommand("[SQLeados].listarFuncionalidades", coneccion);
                cargaradmin.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cargaradmin.ExecuteReader();
                List<string> funcionalidades = new List<string>();

                while (reader.Read())
                {
                    funcionalidades.Add(reader.GetValue(0).ToString());
                }
                reader.Close();

                listarFuncionalidades(funcionalidades);
            }
            else
            {

                cargarfun = new SqlCommand("[SQLeados].FuncionalidadesPorRol", coneccion);
                cargarfun.Parameters.Add("@Rol", SqlDbType.VarChar).Value = rol;
                cargarfun.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cargarfun.ExecuteReader();
                List<string> funcionalidades = new List<string>();

                while (reader.Read())
                {
                    funcionalidades.Add(reader.GetValue(0).ToString());
                }
                reader.Close();

                listarFuncionalidades(funcionalidades);
            }
        }

        private void listarFuncionalidades(List<String> func)
        {
            int size = func.Count();
            for (int i = 0; i < size; i++)
            {
                var aux = new ListViewItem(func[i]);
                listView1.Items.Add(aux);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ABM_Usuario.Form2 abmUser = new ABM_Usuario.Form2();
            abmUser.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ABM_Rol.Form1 abmRol = new ABM_Rol.Form1();
            abmRol.Show();
            this.Hide();
        }

        private void realizarAccion(String nombre)
        {
            if (nombre.Equals("ABM de Rol"))
            {
                ABM_Rol.Form1 formRol = new ABM_Rol.Form1();
                formRol.Show();
                this.Close();
            }

            if (nombre.Equals("Registro de usuarios"))
            {
                ABM_Usuario.Form2 formUser = new ABM_Usuario.Form2();
                formUser.Show();
                this.Close();

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PalcoNet.Form3 frm3 = new PalcoNet.Form3();
            frm3.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Usuario.username = "";
            Usuario.Rol = "";
            PalcoNet.Form1 f1 = new PalcoNet.Form1();
            this.Close();
            f1.Show();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            realizarAccion(e.Item.Text);
        }

    }
}
