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
    public partial class Explorador : Form
    {
        string rol;

        SqlConnection coneccion;
        SqlCommand cargarfun, cargaradmin;
        public Explorador()
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
            ABM_Usuario.ABMUSUARIO abmUser = new ABM_Usuario.ABMUSUARIO(this);
            abmUser.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
    //        ABM_Rol.ABMROL abmRol = new ABM_Rol.ABMROL();
    //        abmRol.Show();
    //        this.Hide();
        }

        private void realizarAccion(String nombre)
        {
            if (nombre.Equals("ABM de Rol"))
            {
                ABM_Rol.ABMROL formRol = new ABM_Rol.ABMROL(this);
                formRol.Show();
                this.Hide();
            }

            if (nombre.Equals("Registro de usuarios"))
            {
                ABM_Usuario.ABMUSUARIO formUser = new ABM_Usuario.ABMUSUARIO(this);
                formUser.Show();
                this.Hide();
            }
        }

        //VOLVER, SI ENTRO POR AQUI, SOLO CONTINUA AL EXPLORADOR
        private void button2_Click_1(object sender, EventArgs e)
        {
            PalcoNet.CambiarContra frm3 = new PalcoNet.CambiarContra(Usuario.username);
            frm3.Show();
            this.Close();
        }


        //CERRAR SECION
        private void button1_Click_1(object sender, EventArgs e)
        {
            Usuario.username = "";
            Usuario.Rol = "";
            this.Close();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            realizarAccion(e.Item.Text);
        }

    }
}
