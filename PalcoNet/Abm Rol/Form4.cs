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
using System.Globalization;


namespace PalcoNet.ABM_Rol
{
    public partial class Form4 : Form
    {
        SqlConnection coneccion;
        SqlDataReader data;
        SqlCommand cargarRoles, eliminar, eliminar2, codigoRol;

        public Form4()
        {
            InitializeComponent();

            coneccion = Support.ConsultasSQL.conectar();
            coneccion.Open();
            cargarRoles = new SqlCommand("SQLeados.cargarRolesHabilitados", coneccion);

            cargarRoles.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(cargarRoles);
            DataTable tablaRoles = new DataTable();

            coneccion.Close();
            adapter.Fill(tablaRoles);
            comboBox2.DataSource = tablaRoles;
            comboBox2.DisplayMember = "Rol_nombre";
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             DialogResult dialogResult = MessageBox.Show("Esta seguro que desea deshabilitar el rol seleccionado?", "Eliminar Rol", MessageBoxButtons.YesNo);
             if (dialogResult == DialogResult.Yes)
             {

                 string nombre = comboBox2.Text.ToString();
                 coneccion.Open();
                 codigoRol = new SqlCommand("SQLeados.codigoRol", coneccion);
                 codigoRol.CommandType = CommandType.StoredProcedure;
                 codigoRol.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                 var resultado = codigoRol.Parameters.Add("@Valor", SqlDbType.Int);
                 resultado.Direction = ParameterDirection.ReturnValue;
                 data = codigoRol.ExecuteReader();
                 

                 var codi = resultado.Value;
                 int rol = (int)codi;
                 data.Close();
                 //inhabilitar rol


                 eliminar = new SqlCommand("SQLeados.inhabilitarRol", coneccion);
                 eliminar.CommandType = CommandType.StoredProcedure;
                 eliminar.Parameters.Add("@codigo", SqlDbType.Int).Value = rol;
                 eliminar.ExecuteNonQuery();
                
                 //quitar RPU


                 eliminar2 = new SqlCommand("SQLeados.inhabilitarRolPorUsuario", coneccion);
                 eliminar2.CommandType = CommandType.StoredProcedure;
                 eliminar2.Parameters.Add("@codigo", SqlDbType.Int).Value = rol;
                 eliminar2.ExecuteNonQuery();
                 coneccion.Close();

                


                 String mensaje = "El rol se ha eliminado exitosamente";
                 String caption = "Rol eliminado";
                 MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);

                 ABM_Rol.Form1 form1 = new ABM_Rol.Form1();
                 this.Close();
                 form1.Show();
             }           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ABM_Rol.Form1 form1 = new ABM_Rol.Form1();
            this.Close();
            form1.Show();
        }

    }
}
