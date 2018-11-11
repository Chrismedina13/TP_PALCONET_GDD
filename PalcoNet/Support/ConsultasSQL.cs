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

namespace PalcoNet.Support
{
    class ConsultasSQL
    {
        internal static bool existeCuit(string cuit)
        {
            String empresaRS = null;
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            SqlCommand empresaHabilitada = new SqlCommand("SELECT empresa_razon_social FROM [GD2C2018].[SQLEADOS].[Empresa] WHERE empresa_cuit = @cuit and empresa_estado = 1");
            empresaHabilitada.Parameters.AddWithValue("cuit", cuit);
            empresaHabilitada.Connection = connection;
            connection.Open();
            SqlDataReader reader = empresaHabilitada.ExecuteReader();
            while (reader.Read())
            {
                empresaRS = reader["empresa_razon_social"].ToString();
            }
            connection.Close();
            return empresaRS != null;
        }

        internal static void AgregarEmpresa(string razonSocial, string cuit, string ciudad, string mail, string telefono, int usuario, DateTime fecha)
        {

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            SqlCommand addEmpresaCommand = new SqlCommand("insert into [GD2C2018].[SQLEADOS].[Empresa] (empresa_razon_social,empresa_cuit,empresa_ciudad,empresa_email,empresa_telefono,empresa_usuario,empresa_fecha_creacion) values (@razonSocial,@cuit,@ciudad,@mail,@telefono,@usuario,@fecha)");
            addEmpresaCommand.Parameters.AddWithValue("razonSocial", razonSocial);
            addEmpresaCommand.Parameters.AddWithValue("cuit", cuit);
            addEmpresaCommand.Parameters.AddWithValue("ciudad", ciudad);
            addEmpresaCommand.Parameters.AddWithValue("mail", mail);
            addEmpresaCommand.Parameters.AddWithValue("telefono", telefono);
            addEmpresaCommand.Parameters.AddWithValue("usuario", usuario);
            addEmpresaCommand.Parameters.AddWithValue("fecha", fecha);

            addEmpresaCommand.Connection = connection;
            connection.Open();
            int registrosModificados = addEmpresaCommand.ExecuteNonQuery();
            connection.Close();
            if (registrosModificados > 0) MessageBox.Show("Empresa ingresada correctamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error al cargar registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        internal static void AgregarDomicilio(string calle, int numeroCalle, int piso, string dto, string localidad, int codigoPostal, string razonSocial,string cuit)
        {

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            SqlCommand addDomicilioCommand = new SqlCommand("insert into [GD2C2018].[SQLEADOS].[Domicilio] (domicilio_calle,domicilio_numero,domicilio_piso,domicilio_dto,domicilio_localidad,domicilio_codigo_postal,domicilio_empresa_razon_social,domicilio_empresa_cuit) values (@calle,@numeroCalle,@piso,@dto,@localidad,@codigoPostal,@razonSocial,@cuit)");
            addDomicilioCommand.Parameters.AddWithValue("calle", calle);
            addDomicilioCommand.Parameters.AddWithValue("numeroCalle", numeroCalle);
            addDomicilioCommand.Parameters.AddWithValue("piso", piso);
            addDomicilioCommand.Parameters.AddWithValue("dto", dto);
            addDomicilioCommand.Parameters.AddWithValue("localidad", localidad);
            addDomicilioCommand.Parameters.AddWithValue("codigoPostal", codigoPostal);
            addDomicilioCommand.Parameters.AddWithValue("razonSocial", razonSocial);
            addDomicilioCommand.Parameters.AddWithValue("cuit", cuit);

            addDomicilioCommand.Connection = connection;
            connection.Open();
            int registrosModificados = addDomicilioCommand.ExecuteNonQuery();
            connection.Close();
            if (registrosModificados > 0) MessageBox.Show("Domicilio ingresado correctamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error al cargar registro Domicilio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        internal static void cargarGriddEmpresa(DataGridView dgv, string razonSocial, string cuit, string mail)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            connection.Open();
            try
            {
                String query = "SELECT [empresa_razon_social],[empresa_cuit],[empresa_email],[empresa_ciudad],[empresa_telefono],[empresa_usuario] FROM [GD2C2018].[SQLEADOS].[Empresa] where [empresa_razon_social] like '" + razonSocial + "%' and [empresa_cuit] like '" + cuit + "%' and [empresa_email] like '" + mail + "%' ";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el DataGridView: " + ex.ToString());
            }
            connection.Close();
        }



    }
}
