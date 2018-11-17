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
    class ConsultaGeneral {
        internal static bool esVacio(String n)
        {
            return n == "";
        }
    }

    class ConsultasSQL {
        public static SqlConnection conectar()
        {
            return new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
        }

        public void cerrarConeccion(SqlConnection sql)
        {
            sql.Close();
            return;
        }

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

        internal static void darDeBaja(DataGridView dgv, string usuario)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            connection.Open();
            try
            {
                String query = "UPDATE [GD2C2018].[SQLEADOS].[Usuario] SET usuario_estado = 0 WHERE usuario_username LIKE " + usuario;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo dar de baja al usuario: "+ usuario);
            }
            connection.Close();
            return;
        }

        internal static bool nombreUsuarioDisponible(String nombre, bool casoEspecial) {
            SqlConnection sql = conectar();
            String RS = null;
            try
            {
                SqlCommand buscarUserConEseNombre = new SqlCommand("SELECT count(*) from [GD2C2018].[SQLEADOS].[Usuario] where WHERE usuario_username LIKE " + nombre);
                buscarUserConEseNombre.Connection = sql;
                sql.Open();

                SqlDataReader reader = buscarUserConEseNombre.ExecuteReader();
                while (reader.Read())
                {
                    RS = reader[0].ToString();
                }
                sql.Close();
                if (Convert.ToInt32(RS) > 0)
                {
                    return false;
                }
                return true;
                   
            }
            catch (Exception)
            {
                MessageBox.Show("No se realizó la conexión con la base de datos");
                casoEspecial = true;
                
                return true;
            }
        }

        /*Crea un usuario y devuelve su ID si todo va bien*/
        internal static int crearUser(String nombre, String apellido, bool caso, String contra)
        {
            string nombreUserCreado ="";
            bool creado = false;
            int i = 0, iniciado = 0;
            

            while (!creado)
            {
                /* CREA USUARIOS NUEVOS EN FORMATO <nombre>_<apellido>, SI EXISTEN, EMPIEZA A PONERLES UN NUMERO EL CUAL SE VA INCREMENTANDO
                 SI CONTINUAN LAS CONCIDENCIAS*/
                if (iniciado == 0)
                {
                    nombreUserCreado = nombre.ToLower().Replace(" ", "_") + "_" + apellido.ToLower().Replace(" ", "_");
                    iniciado++;
                }
                else {
                    nombreUserCreado = nombre.ToLower().Replace(" ", "_") + "_" + apellido.ToLower().Replace(" ", "_") + i.ToString();
                    i++;
                }
                /*El caso especial es por si ocurre un error en la conexión. Si hay se aborta todo*/
                if (nombreUsuarioDisponible(nombreUserCreado, caso))
                {
                    creado = true;
                }
            }
            if (caso == false) {
                return crearUnNuevoUserConNombre(nombreUserCreado, contra, "3", "Cliente");
            }
            return 0;
        }

        internal static int crearUnNuevoUserConNombre(String nombre, String contra, String rol, String tipo) {
            if (contra == "")
            {
                contra = "(SELECT TOP 1 HASHBYTES('SHA2_256', (select top 1 STR(10000000*RAND(convert(varbinary, newid()))) magic_number)))";
            }            
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            SqlCommand addUserCommand = new SqlCommand("insert into [GD2C2018].[SQLEADOS].[Usuario] (usuario_username,usuario_password,usuario_rol,usuario_tipo) values (@nombre,@contra,@rol,@tipo)");
            addUserCommand.Parameters.AddWithValue("nombre", nombre);
            addUserCommand.Parameters.AddWithValue("contra", contra);
            addUserCommand.Parameters.AddWithValue("rol", rol);
            addUserCommand.Parameters.AddWithValue("tipo", tipo);

            addUserCommand.Connection = connection;
            connection.Open();
            int registrosModificados = addUserCommand.ExecuteNonQuery();
            
            if (registrosModificados > 0) {
                connection.Close();

                MessageBox.Show("El usuario fue ingresado correctamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SqlConnection connection1 = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
                SqlCommand buscarID = new SqlCommand("SELECT usuario_Id FROM [GD2C2018].[SQLEADOS].[Usuario] where usuario_username LIKE " + nombre);

                buscarID.Connection = connection1;
                connection1.Open();
                SqlDataReader reader = buscarID.ExecuteReader();
                String RS = null;
                while (reader.Read())
                {
                    RS = reader[0].ToString();
                }
                connection1.Close();
                return Convert.ToInt32(RS);
            }           
            else 
            {
                MessageBox.Show("Error al cargar registro Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
                
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
        public void cargarGriddEmpresa(DataGridView dgv, string razonSocial, string cuit, string mail)
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

        internal static void llenarDGVCliente(DataGridView dgv, string nombre, string apellido, string numeroDNI, string mail)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            connection.Open();
            try
            {
                String query = "SELECT [usuario_username],[cliente_nombre],[cliente_apellido],[cliente_tipo_documento],[cliente_numero_documento] FROM [GD2C2018].[SQLEADOS].[Cliente] where [cliente_nombre] like '%" + nombre + "%' or [cliente_apellido] like '%" + apellido + "%' or [cliente_email] like '" + mail + "%' or [cliente_numero_documento] = " + numeroDNI;
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
            return;
        }

        public static void cargarGriddCliente(DataGridView dgv, string nombre, string apellido, string numeroDNI, string mail)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            connection.Open();
            try
            {
                String query = "SELECT [usuario_username],[cliente_nombre],[cliente_apellido],[cliente_tipo_documento],[cliente_numero_documento] FROM [GD2C2018].[SQLEADOS].[cliente] c JOIN [GD2C2018].[SQLEADOS].[usuario] u on u.usuario_Id = c.cliente_usuario and u.usuario_estado = 1  where ([cliente_nombre] like '%" + nombre + "%' and [cliente_apellido] like '%" + apellido + "%' and [cliente_email] like '" + mail + "%') or [cliente_numero_documento] = " + numeroDNI;
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
        /* ESTO NO ES USADO
        internal static void cargarGriddCliente(DataGridView dgv, string nombre, string apellido, string nroDNI, string mail)
        {
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            connection.Open();
            try
            {
                String query = "SELECT [cliente_nombre],[cliente_apellido],[cliente_numero_documento],[cliente_email],[usuario_username] FROM [GD2C2018].[SQLEADOS].[Cliente] where [cliente_nombre] like '%" + nombre + "%' and [cliente_apellido] like '%" + apellido + "%' and [cliente_email] like '%" + mail + "%' and [cliente_numero_documento] = " + Int32.Parse(nroDNI);
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