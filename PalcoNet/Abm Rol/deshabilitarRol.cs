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
using PalcoNet.Support;


namespace PalcoNet.ABM_Rol
{
    public partial class deshabilitarRol : Form
    {
        SqlConnection coneccion;
        SqlDataReader data;
        SqlCommand cargarRoles, eliminar, eliminar2, codigoRol;
        ABMROL roles;
        public deshabilitarRol(ABMROL rol)
        {
            roles = rol;
            InitializeComponent();

            
        }

        public void cargar() {
            String status = "SELECT ROL.rol_nombre FROM SQLEADOS.ROL WHERE rol_Id > 1 AND rol_estado = 1";
            DBConsulta.conexionAbrir();
            DataTable dt = DBConsulta.obtenerConsultaEspecifica(status);
            DBConsulta.conexionCerrar();

            //coneccion = PalcoNet.Support.Conexion.conectar();
            //coneccion.Open();
            //cargarRoles = new SqlCommand("SQLeados.cargarRolesHabilitados", coneccion);

            //cargarRoles.CommandType = CommandType.StoredProcedure;

            //SqlDataAdapter adapter = new SqlDataAdapter(cargarRoles);
            //DataTable tablaRoles = new DataTable();

            //coneccion.Close();
            //adapter.Fill(tablaRoles);
            comboBoxRoles.DataSource = dt;
            comboBoxRoles.DisplayMember = "Rol_nombre";
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             DialogResult dialogResult = MessageBox.Show("Esta seguro que desea deshabilitar el rol seleccionado?", "Eliminar Rol", MessageBoxButtons.YesNo);
             if (dialogResult == DialogResult.Yes)
             {

                 string nombre = comboBoxRoles.Text.ToString();
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

                


                 String mensaje = "El rol se ha inhabilitado exitosamente";
                 String caption = "Rol inhabilitado";
                 MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);

        //         ABM_Rol.ABMROL form1 = new ABM_Rol.ABMROL();
        //         this.Close();
        //         form1.Show();
             }           
        }
        //VOLVER
        private void button5_Click(object sender, EventArgs e)
        {
            roles.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //DESHABILITAR ROL
        private void button2_Click(object sender, EventArgs e)
        {
       //     int currentMyComboBoxIndex = comboBoxRoles.SelectedIndex;
            string current = this.comboBoxRoles.GetItemText(this.comboBoxRoles.SelectedItem);
            String comando = "UPDATE SQLEADOS.Rol SET rol_estado = 0 WHERE rol_nombre LIKE '" + current +"'";
            
            DBConsulta.AbrirCerrarModificarDB(comando);
            
            //QUITAR EL ROL A TODAS LOS USUARIOS QUE LO TENINA POR ESTAR INHABILITADO
            String query = "SELECT rol_Id FROM SQLEADOS.Rol where rol_nombre LIKE '" + current + "'";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            comando = "DELETE FROM SQLEADOS.UsuarioXRol WHERE usuarioXRol_rol = "+dt.Rows[0][0].ToString();
            DBConsulta.AbrirCerrarModificarDB(comando);
            MessageBox.Show("El rol " + current + " fue inhabilitado");
            cargar();
            return;
        }

    }
}
