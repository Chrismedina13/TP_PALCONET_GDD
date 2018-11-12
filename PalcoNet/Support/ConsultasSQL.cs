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
    class ConsultasSQL {
        internal static void AgregarDomicilio(string calle, int numeroCalle, int piso, string dto, string localidad, int codigoPostal, string razonSocial, string cuit, string tipo_documento, string numeroDocumento)
        {

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            SqlCommand addDomicilioCommand = new SqlCommand("insert into [GD2C2018].[SQLEADOS].[Domicilio] (domicilio_calle,domicilio_numero,domicilio_piso,domicilio_dto,domicilio_localidad,domicilio_codigo_postal,domicilio_empresa_razon_social,domicilio_empresa_cuit,domicilio_cliente_tipo_documento,domicilio_cliente_numero_documento) values (@calle,@numeroCalle,@piso,@dto,@localidad,@codigoPostal,@razonSocial,@cuit,@tipo_documento,@numeroDocumento)");
            addDomicilioCommand.Parameters.AddWithValue("calle", calle);
            addDomicilioCommand.Parameters.AddWithValue("numeroCalle", numeroCalle);
            addDomicilioCommand.Parameters.AddWithValue("piso", piso);
            addDomicilioCommand.Parameters.AddWithValue("dto", dto);
            addDomicilioCommand.Parameters.AddWithValue("localidad", localidad);
            addDomicilioCommand.Parameters.AddWithValue("codigoPostal", codigoPostal);
            addDomicilioCommand.Parameters.AddWithValue("razonSocial", razonSocial);
            addDomicilioCommand.Parameters.AddWithValue("cuit", cuit);
            addDomicilioCommand.Parameters.AddWithValue("tipo_documento", tipo_documento);
            addDomicilioCommand.Parameters.AddWithValue("numeroDocumento", Convert.ToInt32(numeroDocumento));
            
            

            addDomicilioCommand.Connection = connection;
            connection.Open();
            int registrosModificados = addDomicilioCommand.ExecuteNonQuery();
            connection.Close();
            if (registrosModificados > 0) MessageBox.Show("Domicilio ingresado correctamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error al cargar registro Domicilio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static bool existeCuit(string cuit, string tipo)
        {
            String RS = null;
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            SqlCommand tipoHabilitada = new SqlCommand("SELECT cliente_cuit FROM [GD2C2018].[SQLEADOS].["+tipo+"] WHERE "+tipo+"_cuit = @cuit and "+tipo+"_estado = 1");
            tipoHabilitada.Parameters.AddWithValue("cuit", cuit);
            tipoHabilitada.Connection = connection;
            connection.Open();
            SqlDataReader reader = tipoHabilitada.ExecuteReader();
            while (reader.Read())
            {
                RS = reader[tipo+"_cuit"].ToString();
            }
            connection.Close();
            return RS != null;

        }
    }
    class ConsultasSQLEmpresa : ConsultasSQL
    {
      /*  
       * internal bool existeCuit(string cuit)
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
        */
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

    class consultasSQLCliente : ConsultasSQL
    {
        internal static void cargarGriddCliente(DataGridView dgv, string nombre, string apellido, string numeroDNI, string mail)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            connection.Open();
            try
            {
                String query = "SELECT [usuario_username],[cliente_nombre],[cliente_apellido],[cliente_tipo_documento],[cliente_numero_documento] FROM [GD2C2018].[SQLEADOS].[Empresa] where [cliente_nombre] like '%" + nombre + "%' or [cliente_apellido] like '%" + apellido + "%' or [cliente_email] like '" + mail + "%' or [cliente_numero_documento] = "+ numeroDNI;
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
        /*
        internal bool existeCUILCliente(string cuit) { 
            String clienteRS = null;
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            SqlCommand clienteHabilitada = new SqlCommand("SELECT cliente_cuit FROM [GD2C2018].[SQLEADOS].[Cliente] WHERE cliente_cuit = @cuit and cliente_estado = 1");
            clienteHabilitada.Parameters.AddWithValue("cuit", cuit);
            clienteHabilitada.Connection = connection;
            connection.Open();
            SqlDataReader reader = clienteHabilitada.ExecuteReader();
            while (reader.Read())
            {
                clienteRS = reader["cliente_cuit"].ToString();
            }
            connection.Close();
            return clienteRS != null;
        }
         */

        internal static void AgregarCliente(string nombre, string apellido, string tipo_documento, string nro_documento,
            int usuario, string mail, string datos_tarjeta, int puntaje, int estado, string cuit, string telefono, DateTime fecha_nacimiento,
            DateTime fecha_creacion)
        {

            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            SqlCommand addClienteCommand = new SqlCommand("insert into [GD2C2018].[SQLEADOS].[Cliente] (cliente_nombre,cliente_apellido,cliente_usuario,cliente_tipo_documento,cliente_numero_documento,cliente_fecha_nacimiento,cliente_fecha_creacion,cliente_datos_tarjeta,cliente_puntaje,cliente_email,cliente_telefono,cliente_estado,cliente_cuit) values (@nombre,@apellido,@user,@tipo_documento,@nro_documento,@fecha_nacimiento,@fecha_creacion, @datos_tarjeta, @puntaje, @mail, @telefono, @estado, @cuit)");            
            addClienteCommand.Parameters.AddWithValue("nombre", nombre);
            addClienteCommand.Parameters.AddWithValue("apellido", apellido);
            addClienteCommand.Parameters.AddWithValue("user", usuario);
            addClienteCommand.Parameters.AddWithValue("tipo_documento", tipo_documento);
            addClienteCommand.Parameters.AddWithValue("nro_documento", Convert.ToInt32(nro_documento));
            addClienteCommand.Parameters.AddWithValue("mail", mail);
            addClienteCommand.Parameters.AddWithValue("datos_tarjeta", datos_tarjeta);
            addClienteCommand.Parameters.AddWithValue("puntaje", puntaje);
            addClienteCommand.Parameters.AddWithValue("estado", estado);
            addClienteCommand.Parameters.AddWithValue("cuit", cuit);
            addClienteCommand.Parameters.AddWithValue("telefono", telefono);
            addClienteCommand.Parameters.AddWithValue("fecha_nacimiento", fecha_nacimiento);
            addClienteCommand.Parameters.AddWithValue("fecha_creacion", fecha_creacion);


            addClienteCommand.Connection = connection;
            connection.Open();
            int registrosModificados = addClienteCommand.ExecuteNonQuery();
            connection.Close();
            if (registrosModificados > 0) MessageBox.Show("Empresa ingresada correctamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error al cargar registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
