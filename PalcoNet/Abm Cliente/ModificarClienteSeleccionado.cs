using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data;
using PalcoNet.Support;

namespace PalcoNet.Abm_Cliente
{
    public partial class ModificarClienteSeleccionado : volver
    {
        string usuarioSeleccionado;
        public ModificarClienteSeleccionado()
        {
            InitializeComponent();
        }

        private void ModificarClienteSeleccionado_Load(object sender, EventArgs e)
        {
            usuarioSeleccionado = ModificarCliente.userAModificar;
            this.ObtenerDatos_load();
        }

        private void ObtenerDatos_load() {
            SqlConnection connections = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            connections.Open();

            try
            {
         //       SqlCommand queryS = new SqlCommand("SELECT TOP 1 cliente_nombre, cliente_apellido, cliente_datos_tarjeta, cliente_email, cliente_telefono, cliente_estado, domicilio_calle, domicilio_numero, domicilio_piso, domicilio_dto, domicilio_localidad, domicilio_codigo_postal  FROM [GD2C2018].[SQLEADOS].[Usuario] JOIN [GD2C2018].[SQLEADOS].[Domicilio] ON domicilio_cliente_tipo_documento = cliente_tipo_documento AND domicilio_cliente_numero_documento = cliente_numero_documento WHERE usuario_username LIKE " + usuarioSeleccionado + " AND  usuario_estado = 1");
               string query = "SELECT TOP 1 cliente_nombre, cliente_apellido, cliente_datos_tarjeta, cliente_email, cliente_telefono, domicilio_calle, domicilio_numero, domicilio_piso, domicilio_dto, domicilio_localidad, domicilio_codigo_postal, usuario_estado  FROM [GD2C2018].[SQLEADOS].[Usuario] JOIN [GD2C2018].[SQLEADOS].[Usuario] ON usuario_Id = cliente_usuario JOIN [GD2C2018].[SQLEADOS].[Domicilio] ON domicilio_cliente_tipo_documento = cliente_tipo_documento AND domicilio_cliente_numero_documento = cliente_numero_documento WHERE usuario_username LIKE " + usuarioSeleccionado + " AND  usuario_estado = 1";

       //        SqlDataAdapter da = new SqlDataAdapter(query, connections);
               SqlCommand oCmd = new SqlCommand(query, connections);

       //        DataTable dt = new DataTable();
       //        da.Fill(dt);

               using (SqlDataReader oReader = oCmd.ExecuteReader())
               {
                   while (oReader.Read())
                   {
                       textBoxEmail.Text = oReader["cliente_email"].ToString();
                       textBoxTarjeta.Text = oReader["cliente_datos_tarjeta"].ToString();
                       txtHabilitado.Text = oReader["usuario_estado"].ToString();
                       textBoxApellido.Text = oReader["cliente_apellido"].ToString();
                       textBoxNombre.Text = oReader["cliente_nombre"].ToString();
                       textBoxCalle.Text = oReader["domicilio_calle"].ToString();
                       textBoxCodigoPostal.Text = oReader["domicilio_codigo_postal"].ToString();
                       textBoxDto.Text = oReader["domicilio_dto"].ToString();
                       textBoxNroCalle.Text = oReader["domicilio_numero"].ToString();
                       textBoxLocalidad.Text = oReader["domicilio_localidad"].ToString();
                       textBoxTelefono.Text = oReader["cliente_telefono"].ToString();
                       textBoxPiso.Text = oReader["domicilio_piso"].ToString();
                   }
                   connections.Close();
               }  

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo obtener los datos");
            }
            connections.Close();
           
            

        }

        private void ModificarClienteSeleccionado_Load_1(object sender, EventArgs e)
        {

        }

        // BOTON MODIFICAR LOS DATOS DEL CLIENTE
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            connection.Open();
            try
            {
                String query = "UPDATE [GD2C2018].[SQLEADOS].[Cliente], [GD2C2018].[SQLEADOS].[Usuario] SET cliente_nombre = " + textBoxNombre +", cliente_apellido = " + textBoxApellido +", cliente_datos_tarjeta = " + textBoxTarjeta +", cliente_email = "+ textBoxEmail + ", cliente_telefono = "+ textBoxTelefono +", domicilio_calle =" +textBoxCalle +",domicilio_numero =" +textBoxNroCalle+", domicilio_piso = "+textBoxPiso+", domicilio_dto = "+textBoxDto+", domicilio_localidad = "+ textBoxLocalidad+", domicilio_codigo_postal = "+textBoxCodigoPostal+", usuario_estado = "+txtHabilitado+" WHERE usuario_username LIKE " + usuarioSeleccionado;
                MessageBox.Show("Se han modificado los datos para: " + usuarioSeleccionado);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo modificar al usuario: " + usuarioSeleccionado);
            }
            connection.Close();
            return;
        }
        

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
