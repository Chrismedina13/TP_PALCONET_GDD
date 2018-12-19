using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data.SqlTypes;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.Media;

namespace PalcoNet.Support
{

    

    class ConsultaGeneral {
        internal static bool esVacio(String n)
        {
            return n == "";
        }

        internal static String fechaToString(DateTime fecha) {
            int anio = fecha.Year;
            int mes = fecha.Month;
            int dia = fecha.Day;
            int hora = fecha.Hour;
            int min = fecha.Minute;
            int seg = fecha.Second;

            return anio.ToString() +"/"+ mes.ToString()+"/" + dia.ToString() +" "+ hora.ToString()+":" + min.ToString() +":"+ seg.ToString();

        }
    }


    class Conexion
    {
        #region Atributos
        //LAPTOP-B6PL6D9G
        //\SQLSERVER2012
 //       private static String configuracionConexion = ConfigurationManager.AppSettings["conexionSQL"];
        private static SqlConnection conexion = new SqlConnection(@"Data source=.\SQLSERVER2012;Initial Catalog=GD2C2018;User id=gdEspectaculos2018;Password=gd2018");
        public static SqlConnection conexionObtener()
        {
            return conexion;
        }
        public static void conexionAbrir()
        {
            conexion.Open();
        }

        public static void conexionCerrar()
        {
            conexion.Close();
        }
        #endregion

        #region ConexionSQL
        
        public static SqlConnection conectar()
        {
            String contraREAL = "gd2018";
            String contraAnterior = "gdEspectaculos2018";
            return new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
        }

        public void cerrarConeccion(SqlConnection sql)
        {
            sql.Close();
            return;
        }


        public static SqlCommand consultaCrear(string consulta)
        {
            return new SqlCommand(consulta, conexionObtener());
        }

        public static int consultaEjecutar(SqlCommand consulta)
        {
            int resultado = 0;
            conexionAbrir();
            try
            {
                resultado = consulta.ExecuteNonQuery();
            }
            catch (Exception excepcion)
            {
                ventanaInformarErrorDatabase(excepcion);
            }
            conexionCerrar();
            return resultado;
        }

        public static DataSet consultaObtenerDatos(SqlCommand consulta)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta);
                dataAdapter.Fill(dataSet);
            }
            catch (Exception excepcion)
            {
                ventanaInformarErrorDatabase(excepcion);
            }
            return dataSet;
        }
            
        public static DataTable consultaObtenerTabla(SqlCommand consulta)
        {
            DataSet dataSet = consultaObtenerDatos(consulta);
            DataTable tabla = dataSet.Tables[0];
            return tabla;
        }

        public static List<string> consultaObtenerLista(SqlCommand consulta)
        {
            DataTable tabla = consultaObtenerTabla(consulta);
            List<string> columna = new List<string>();
            if (tabla.Rows.Count > 0)
                foreach (DataRow fila in tabla.Rows)
                    columna.Add(fila[0].ToString());
            return columna;
        }

        public static string consultaObtenerValor(SqlCommand consulta)
        {
            List<string> columna = consultaObtenerLista(consulta);
            if (columna.Count > 0)
                return columna[0];
            else
                return "";
        }

        public static DataRow consultaObtenerFila(SqlCommand consulta)
        {
            DataTable tabla = consultaObtenerTabla(consulta);
            if (tabla.Rows.Count > 0)
                return tabla.Rows[0];
            else
                return null;
        }

        public static bool consultaValorEsIgualA(string valor, int numero)
        {
            int resultado = Convert.ToInt32(valor);
            return resultado == numero;
        }

        public static bool consultaValorEsMayorA(string valor, int numero)
        {
            int resultado = Convert.ToInt32(valor);
            return resultado > numero;
        }

        public static bool consultaValorEsMenorA(string valor, int numero)
        {
            int resultado = Convert.ToInt32(valor);
            return resultado < numero;
        }

        public static bool consultaValorNoExiste(string valor)
        {
            return valor == "";
        }

        public static bool consultaValorExiste(string valor)
        {
            return valor != "";
        }

        #endregion

        #region Ventana

        public static void ventanaInformarErrorDatabase(Exception excepcion)
        {
            SystemSounds.Hand.Play();
            MessageBox.Show("ERROR EN LA BASE DE DATOS:\n" + excepcion.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ventanaInformarError(string mensaje)
        {
            SystemSounds.Hand.Play();
            MessageBox.Show("ERROR: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        public static void ventanaInformarExito(string mensaje)
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("AVISO: " + mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
        #endregion
    
    #region Clase-consultas-general
    class ConsultasSQL {


        internal static void AgregarDomicilio(string calle, int numeroCalle, int piso, string dto, string localidad, string codigoPostal, string tipoPersona)
        {
            DBConsulta.creacionNuevoDomicilio(calle, numeroCalle, piso, dto, localidad, codigoPostal, tipoPersona);
            /*
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand addDomicilioCommand = new SqlCommand("insert into [GD2C2018].[SQLEADOS].[Domicilio] (domicilio_calle,domicilio_numero,domicilio_piso,domicilio_dto,domicilio_localidad,domicilio_codigo_postal,domicilio_empresa_razon_social,domicilio_empresa_cuit,domicilio_cliente_tipo_documento,domicilio_cliente_numero_documento) values (@calle,@numeroCalle,@piso,@dto,@localidad,@codigoPostal,@razonSocial,@cuit,@tipo_documento,@numeroDocumento)");

            String addDomicilioCommands = "insert into [GD2C2018].[SQLEADOS].[Domicilio] (domicilio_calle,domicilio_numero,domicilio_piso,domicilio_dto,domicilio_localidad,domicilio_codigo_postal,domicilio_empresa_razon_social,domicilio_empresa_cuit,domicilio_cliente_tipo_documento,domicilio_cliente_numero_documento) values ('"+calle+"',"+numeroCalle+","+piso+",'"+dto+"','"+localidad+"','"+codigoPostal+"','"+razonSocial+"','"+cuit+"','"+tipo_documento+"',"+numeroDocumento+")";
            DBConsulta.ModificarDB(addDomicilioCommands);
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
       */
        }

        internal static bool existeCuit(string cuit, string tipo)
        {
            String RS = null;
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand tipoHabilitada = new SqlCommand("SELECT " + tipo + "_cuit FROM [GD2C2018].[SQLEADOS].[" + tipo + "] WHERE " + tipo + "_cuit = @cuit");
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
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            connection.Open();
            try
            {
                String query = "UPDATE [GD2C2018].[SQLEADOS].[Usuario] SET usuario_estado = 0 WHERE usuario_nombre LIKE " + usuario;
                DBConsulta.ModificarDB(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo dar de baja al usuario: "+ usuario +"\n\nMOTIVO: "+ex.ToString());
            }
            connection.Close();
            return;
        }


        internal static bool nombreUserDisponible(String nombre)
        {
            String query = String.Format("SELECT usuario_nombre FROM SQLEADOS.Usuario where usuario_nombre like '" + nombre + "'");
            DataSet usersEncontrados = DBConsulta.ConectarConsulta(query);
            if (DBConsulta.dataSetVacio(usersEncontrados))
            {
                MessageBox.Show("Usuario Disponible");
                return true; // NO ENCONTRO NADA, NO HACE NADA
            }
            return false;
        }

        /*Crea un usuario y devuelve su ID si todo va bien*/
        internal static int crearUser(String nombreUserCreado, bool caso, String contra, String rol)
        {
            if (caso == false) 
            {
                // Es mejor que se encarge DBConsulta a traves de un Store Prodecure para la accion,
                //Ahorro lineas de codigo de esta forma 
                return DBConsulta.creacionNuevoUser(nombreUserCreado, contra, rol);
            }
            return 0;
        }

        #region Funcion crear nuevo user DESCARTADA NO BORRAR
        /*
        internal static int crearUnNuevoUserConNombre(String nombre, String contra, String rol, String tipo) {
            String addUserCommand = "insert into [GD2C2018].[SQLEADOS].[Usuario] (usuario_nombre,usuario_password,usuario_rol,usuario_tipo, usuario_fecha_creacion) values ('"+nombre+"','"+contra+"',"+rol+",'"+tipo+"',"+ConsultaGeneral.fechaToString(fecha)+")";
            
            try {
                
                DBConsulta.ModificarDB(addUserCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo ingresar el usuario:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            try
            {
                String algo = "SELECT usuario_Id FROM [GD2C2018].[SQLEADOS].[Usuario] where usuario_nombre LIKE " + nombre + " AND SQLEADOS.func_coincide_fecha_creacion(usuario_fecha_creacion, " + ConsultaGeneral.fechaToString(fecha) + "= 1)";
                DataSet ds = DBConsulta.ConectarConsulta(algo);
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener el ID del user ingresado:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
         */
        #endregion
    }
    #endregion

    #region ConsultaEmpresa
    class ConsultasSQLEmpresa : ConsultasSQL
    {

        internal static void darDeBajaEmpresa(String razonSocial, String cuit,String email)
        {
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand deleteEmpresaCommand = new SqlCommand("UPDATE [GD2C2018].[SQLEADOS].[Empresa] SET empresa_estado = 0 where empresa_razon_social = @razonSocial and empresa_cuit = @cuit and empresa_email = @email ");
            deleteEmpresaCommand.Parameters.AddWithValue("razonSocial", razonSocial);
            deleteEmpresaCommand.Parameters.AddWithValue("cuit", cuit);
            deleteEmpresaCommand.Parameters.AddWithValue("email", email);

            deleteEmpresaCommand.Connection = connection;
            connection.Open();
            int FilasAfectadas = deleteEmpresaCommand.ExecuteNonQuery();

            if (FilasAfectadas > 0)
            {
                MessageBox.Show("La empresa ha sido dado de baja exitosamente", "La base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("No se pudo dar de baja el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            connection.Close();
        }


        internal static bool existeCuit(string cuit)
        {
            String empresaRS = null;
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
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
        
        internal static void AgregarEmpresa(string razonSocial, string cuit, string ciudad, string mail, string telefono, int usuario, String fecha)
        {

            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand addEmpresaCommand = new SqlCommand("insert into [GD2C2018].[SQLEADOS].[Empresa] (empresa_razon_social,empresa_cuit,empresa_ciudad,empresa_email,empresa_telefono,empresa_usuario,empresa_fecha_creacion) values (@razonSocial,@cuit,@ciudad,@mail,@telefono,@usuario,@fecha)");
            addEmpresaCommand.Parameters.AddWithValue("razonSocial", razonSocial);
            addEmpresaCommand.Parameters.AddWithValue("cuit", cuit);
            addEmpresaCommand.Parameters.AddWithValue("ciudad", ciudad);
            addEmpresaCommand.Parameters.AddWithValue("mail", mail);
            addEmpresaCommand.Parameters.AddWithValue("telefono", telefono);
            addEmpresaCommand.Parameters.AddWithValue("usuario", usuario);
            addEmpresaCommand.Parameters.AddWithValue("fecha", fecha);

            String comando = "insert into [GD2C2018].[SQLEADOS].[Empresa] (empresa_razon_social,empresa_cuit,empresa_ciudad,empresa_email,empresa_telefono,empresa_usuario,empresa_fecha_creacion) values ('"+razonSocial+"','"+cuit+"','"+ciudad+"','"+mail+"',"+telefono+","+usuario+",'"+fecha+"')";

            DBConsulta.modificarDatosDeDB(comando);
            /*
            addEmpresaCommand.Connection = connection;
            connection.Open();

            DBConsulta.conexionAbrir();
     //       SqlConnection connection = DBConsulta.obtenerConexion();



            int registrosModificados = addEmpresaCommand.ExecuteNonQuery();
            connection.Close();
            if (registrosModificados > 0) MessageBox.Show("Empresa ingresada correctamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error al cargar registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            */

        }

        internal static void cargarGriddEmpresa(DataGridView dgv, string razonSocial, string cuit, string mail)
        {
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            connection.Open();
            try
            {
                String query = "SELECT [empresa_razon_social],[empresa_cuit],[empresa_email],[empresa_ciudad],[empresa_telefono],[empresa_usuario] FROM [GD2C2018].[SQLEADOS].[Empresa] where empresa_estado = 1 and [empresa_razon_social] like '" + razonSocial + "%' and [empresa_cuit] like '" + cuit + "%' and [empresa_email] like '" + mail + "%' ";
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

        internal static void cargarGriddEmpresaModificar(DataGridView dgv, string razonSocial, string cuit, string mail)
        {
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            connection.Open();
            try
            {
                String query = "SELECT [empresa_razon_social],[empresa_cuit],[empresa_email],[empresa_ciudad],[empresa_telefono],[empresa_usuario],[empresa_estado] FROM [GD2C2018].[SQLEADOS].[Empresa] where [empresa_razon_social] like '" + razonSocial + "%' and [empresa_cuit] like '" + cuit + "%' and [empresa_email] like '" + mail + "%' ";
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


        internal static string[] getDatosEmpresa(string razonSocial, string cuit, string email)
        {
            String[] datos = new string[9];
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand getDatosClienteCommand = new SqlCommand("SELECT [empresa_ciudad],[empresa_telefono],[empresa_estado],[domicilio_calle],[domicilio_numero],[domicilio_piso],[domicilio_dto],[domicilio_localidad],[domicilio_codigo_postal] FROM [GD2C2018].[SQLEADOS].[Empresa],[GD2C2018].[SQLEADOS].[Domicilio] WHERE empresa_cuit = @cuit AND empresa_razon_social = @razonSocial and empresa_razon_social = domicilio_empresa_razon_social and empresa_cuit = domicilio_empresa_cuit");
            getDatosClienteCommand.Parameters.AddWithValue("razonSocial", razonSocial);
            getDatosClienteCommand.Parameters.AddWithValue("cuit", cuit);
            getDatosClienteCommand.Parameters.AddWithValue("email", email);
            getDatosClienteCommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = getDatosClienteCommand.ExecuteReader();
            while (reader.Read())
            {
                datos[0] = reader["empresa_ciudad"].ToString();
                datos[1] = reader["empresa_telefono"].ToString();
                datos[2] = reader["empresa_estado"].ToString();
                datos[3] = reader["domicilio_calle"].ToString();
                datos[4] = reader["domicilio_numero"].ToString();
                datos[5] = reader["domicilio_piso"].ToString();
                datos[6] = reader["domicilio_dto"].ToString();
                datos[7] = reader["domicilio_localidad"].ToString();
                datos[8] = reader["domicilio_codigo_postal"].ToString();
            }
            connection.Close();
            return datos;
        }

        internal static void modificarEmpresa(string razonSocial,String cuit,String ciudad,String mail,String telefono,int estado)
        {
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand updateEmpresaCommand = new SqlCommand("UPDATE [GD2C2018].[SQLEADOS].[Empresa] set empresa_ciudad = @ciudad, empresa_email = @mail, empresa_telefono = @telefono, empresa_estado = @estado WHERE empresa_razon_social = @razonSocial and empresa_cuit = @cuit");

            updateEmpresaCommand.Parameters.AddWithValue("razonSocial", razonSocial);
            updateEmpresaCommand.Parameters.AddWithValue("ciudad", ciudad);
            updateEmpresaCommand.Parameters.AddWithValue("cuit", cuit);
            updateEmpresaCommand.Parameters.AddWithValue("mail", mail);
            updateEmpresaCommand.Parameters.AddWithValue("telefono", telefono);
            updateEmpresaCommand.Parameters.AddWithValue("estado", estado);

            updateEmpresaCommand.Connection = connection;
            connection.Open();
            int FilasAfectadasClientes = updateEmpresaCommand.ExecuteNonQuery();

            if (FilasAfectadasClientes > 0)
            {
                MessageBox.Show("La empresa se ha modificado exitosamente.", "La base de datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("El registro que quiso modificar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            connection.Close();

        }

        internal static void modificarEmpresaDomicilio(string calle,int nroCalle,int piso,string dto,string localidad, string codPostal,string cuit,string razonSocial)
        {
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand updateEmpresadomicilo = new SqlCommand("UPDATE [GD2C2018].[SQLEADOS].[Domicilio] set domicilio_calle = @calle, domicilio_numero = @nroCalle, domicilio_piso = @piso, domicilio_dto = @dto, domicilio_localidad = @localidad , domicilio_codigo_postal = @codPostal WHERE domicilio_empresa_razon_social = @razonSocial and domicilio_empresa_cuit = @cuit");

            updateEmpresadomicilo.Parameters.AddWithValue("calle", calle);
            updateEmpresadomicilo.Parameters.AddWithValue("nroCalle", nroCalle);
            updateEmpresadomicilo.Parameters.AddWithValue("piso", piso);
            updateEmpresadomicilo.Parameters.AddWithValue("dto", dto);
            updateEmpresadomicilo.Parameters.AddWithValue("localidad", localidad);
            updateEmpresadomicilo.Parameters.AddWithValue("codPostal", codPostal);
            updateEmpresadomicilo.Parameters.AddWithValue("cuit", cuit);
            updateEmpresadomicilo.Parameters.AddWithValue("razonSocial", razonSocial);


            updateEmpresadomicilo.Connection = connection;
            connection.Open();
            int FilasAfectadasClientes = updateEmpresadomicilo.ExecuteNonQuery();
            connection.Close();

        }



    }
    #endregion

    #region consultaCliente
    class consultasSQLCliente : ConsultasSQL
    {
        internal static void llenarDGVCliente(DataGridView dgv, string nombre, string apellido, string numeroDNI, string mail)
        {
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
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
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
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
        #region ocultar
        
        internal bool existeCUILCliente(string cuit) { 
            String clienteRS = null;
            SqlConnection connection = new SqlConnection(@"Data source=.\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");
            SqlCommand clienteHabilitada = new SqlCommand("SELECT cliente_cuit FROM [GD2C2018].[SQLEADOS].[Cliente] WHERE cliente_cuit = @cuit");
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
         
        /*
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
        #endregion

        internal static void AgregarCliente(String nombre, String apellido, String tipo_documento, long nro_documento,
            String mail, String datos_tarjeta, String cuit, String telefono, String fecha_nacimiento, DateTime fecha_creacion)
        {
            DBConsulta.creacionNuevoCliente(nombre, apellido, tipo_documento, fecha_nacimiento, fecha_creacion.ToString("yyyy-MM-dd"), mail, cuit, nro_documento, telefono, datos_tarjeta);
            /*
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            String addClienteCommand = "insert into [GD2C2018].[SQLEADOS].[Cliente] (cliente_nombre,cliente_apellido,cliente_usuario,cliente_tipo_documento,cliente_numero_documento,cliente_fecha_nacimiento,cliente_fecha_creacion,cliente_datos_tarjeta,cliente_puntaje,cliente_email,cliente_telefono,cliente_estado,cliente_cuit) values ('" + nombre + "','" + apellido + "'," + usuario + ",'" + tipo_documento + "'," + nro_documento + "," + fecha_nacimiento + "," + ConsultaGeneral.fechaToString(fecha_creacion) + ", " + datos_tarjeta + "," + puntaje + ",'" + mail + "', " + telefono + ", " + estado + ", '" + cuit + "')";

            try {
                DBConsulta.ModificarDB(addClienteCommand);
                MessageBox.Show("Cliente ingresada correctamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar registro \n\n" +ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             * */
        }
    }
    #endregion

    #region LOGIN
    class LoginSQL : ConsultasSQL
    {
        public static int corroborarDatos(String user, String contra) {
            String query = String.Format("SELECT usuario_nombre, usuario_password, usuario_logins_fallidos, usuario_estado FROM GD2C2018.SQLEADOS.Usuario where usuario_nombre like '" + user + "'");
            DataSet usersEncontrados = DBConsulta.ConectarConsulta(query);
            if(DBConsulta.dataSetVacio(usersEncontrados)) {
              MessageBox.Show("No existe el usuario");
              return -1; // NO ENCONTRO NADA, NO HACE NADA
            }
            String nombreUser = usersEncontrados.Tables[0].Rows[0][0].ToString();
            byte[] pass = (byte[])usersEncontrados.Tables[0].Rows[0][1];
            String intentos_fallidos = usersEncontrados.Tables[0].Rows[0][2].ToString();
            String estadoUser = usersEncontrados.Tables[0].Rows[0][3].ToString();

            int nrointentos = Convert.ToInt32(intentos_fallidos);
            if (estadoUser == "0")
            {
                MessageBox.Show("Su usuario está bloqueado \nComuniquese con un administrador");
                //USER BLOQUEADO, NO SE HACE NADA PERO SE IMPOSIBILITA SU ENTRADA
                return -2;
            }
            else {
                if (!coincidenContrasenias(pass, contra))
                {
                    MessageBox.Show("Usuario o contraseña incorrecto\n\nLimite de tolerancia de intentos fallidos hasta ser bloqueado: 3 \nLogins fallidos cometidos por usted: " + (nrointentos++).ToString());
                    if (nrointentos < 3)
                    {
                        String subirIntentosFallidos = String.Format("UPDATE GD2C2018.SQLEADOS.Usuario SET usuario_logins_fallidos = usuario_logins_fallidos + 1 where usuario_nombre like  '" + user + "'");
                        DBConsulta.ModificarDB(subirIntentosFallidos);
                    }
                    else {
                        String subirIntentosFallidos = String.Format("UPDATE GD2C2018.SQLEADOS.Usuario SET usuario_estado = 0 where usuario_nombre like  '" + user + "'");
                        DBConsulta.ModificarDB(subirIntentosFallidos);
                    }
                    return 0; // DEBE SALTAR UNA VENTANA QUE MLA LA CONTRA Y EN CORRESPONDENCIA SUBE EL CONTADOR
                    // DE LOGIN
                }
                MessageBox.Show("Bienvenido: " + nombreUser);
                //Borrar todos los contadores de Logins fallidos para el usuario que ingresó
                String resetearCampoLoginsFallidos = String.Format("UPDATE GD2C2018.SQLEADOS.Usuario SET usuario_logins_fallidos = 0 where usuario_nombre like  '" + user + "'");
                DBConsulta.ModificarDB(resetearCampoLoginsFallidos);
                if (userTieneMasDe1Rol(ObtenerRoles(user)))
                {
                    // SIGNIFICA QUE EL USUARIO TIENE MAS DE 1 ROL, ABRE VENTANA DE SELECCION DE USER
                    return 2;
                }
                return 1; 
            }
        }

        public static byte[] loginEncriptarContraseña(String contrasenia)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding encoder = Encoding.UTF8;
                return hash.ComputeHash(encoder.GetBytes(contrasenia));
            }
        }

        private static byte[] obtenerContraRealEncriptada(String contraReal) {
            return Encoding.ASCII.GetBytes(contraReal);
        }

        public static bool coincidenContrasenias(byte[] contraseniaReal, String contrasenia)
        {
            byte[] contraseniaEncriptada = loginEncriptarContraseña(contrasenia);
            return contraseniaEncriptada.SequenceEqual(contraseniaReal);
        }

        public static bool userTieneMasDe1Rol(DataSet DS) {
            return DS.Tables[0].Rows.Count > 1;
        }

        public static DataSet ObtenerRolesSinAdmin()
        {
            String query = String.Format("Select distinct r.rol_nombre from SQLEADOS.Rol r where rol_Id > 0");
            return DBConsulta.ConectarConsulta(query);
        }

        public static DataSet ObtenerRoles(String user) {
            String query;
            if (user == "")
            {
                query = String.Format("Select distinct r.rol_nombre from SQLEADOS.Rol r");
            }
            else {
                query = String.Format("Select r.rol_nombre from SQLEADOS.Rol r JOIN SQLEADOS.UserXRol ux on ux.userXRol_rol = r.rol_Id JOIN SQLEADOS.Usuario u ON u.usuario_Id = ux.userXRol_usuario where u.usuario_nombre LIKE '" + user + "'");

            }
            return DBConsulta.ConectarConsulta(query);
        }
        
    }
    #endregion

    #region Registro
    class RegistroSQL : ConsultasSQL {
        
    }

    #endregion

    #region Estadistica

            /*ESTADISTICAS */

    class Estadisticas : ConsultasSQL
    {
        internal static void cargarGriddLocalidadesNoVendidas(DataGridView dataGridView1, Trimestre trimestre, decimal p)
        {
            SqlCommand command = new SqlCommand("");
            obtenerEstadistica(dataGridView1, trimestre, p, command);

        }

        internal static void cargarGriddClientesMasPuntosVencidos(DataGridView dataGridView1, Trimestre trimestre, decimal p)
        {
            SqlCommand command = new SqlCommand("");
            obtenerEstadistica(dataGridView1, trimestre, p, command);
        }

        internal static void cargarGriddClientesMeyorCompras(DataGridView dataGridView1, Trimestre trimestre, decimal año)
        {
            SqlCommand command = new SqlCommand("SELECT top 5 cl.cliente_nombre,cl.cliente_apellido,	SUM(c.compra_cantidad) as 'Cantidad comprada',	c.compra_cliente_numero_documento as 'Numero documento', c.compra_cliente_tipo_documento as 'TIPO DOCUMENTO',e.empresa_razon_social FROM SQLEADOS.Cliente cl JOIN SQLEADOS.Compra c ON c.compra_cliente_numero_documento = cl.cliente_numero_documento AND c.compra_cliente_tipo_documento = cl.cliente_tipo_documento JOIN SQLEADOS.ubicacionesXPublicidadComprada ub ON ub.ubxpcomp_compra = c.compra_id JOIN SQLEADOS.ubicacionXpublicacion u ON u.ubiXpubli_ID = ub.ubxpcom_ubicacionXPublicidad JOIN SQLEADOS.Publicacion p ON p.publicacion_codigo = u.ubiXpubli_Publicacion JOIN SQLEADOS.Empresa e ON e.empresa_usuario = p.publicacion_usuario_responsable where c.compra_fecha > @inicioFecha AND c.compra_fecha < @finFecha GROUP BY c.compra_cantidad, e.empresa_id, c.compra_cliente_numero_documento, c.compra_cliente_tipo_documento,e.empresa_razon_social,cl.cliente_nombre,cl.cliente_apellido ORDER BY SUM(c.compra_cantidad) DESC");
            obtenerEstadistica(dataGridView1, trimestre, año, command);
        }

        private static void obtenerEstadistica(DataGridView dataGridView1, Trimestre trimestre, decimal año, SqlCommand command)
        {
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            connection.Open();
            DateTime fechaIni = new DateTime(Convert.ToInt32(año), trimestre.mesInicio, trimestre.diaInicio);
            DateTime fechaFin = new DateTime(Convert.ToInt32(año), trimestre.mesFin, trimestre.diaFin);
            command.Parameters.AddWithValue("inicioFecha", fechaIni);
            command.Parameters.AddWithValue("finFecha", fechaFin);
            command.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = command;
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

    }
    #endregion

 # region CanjePuntos

    class CanjePuntos : ConsultasSQL
    {
   

        internal static string[] obtenerPuntaje(int usuario)
        {
            String[] datos = new string[5];
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand getDatosClienteCommand = new SqlCommand("select case when (sum(punt_puntaje) -(select sum(canje_puntos_gastados) from SQLEADOS.Canjes where canje_cliente_numero_documento = cliente_numero_documento and canje_cliente_tipo_documento = cliente_tipo_documento)) is null then 0 else sum(punt_puntaje) -(select sum(canje_puntos_gastados) from SQLEADOS.Canjes where canje_cliente_numero_documento = cliente_numero_documento and canje_cliente_tipo_documento = cliente_tipo_documento) end  as puntaje,cliente_apellido,cliente_nombre,cliente_tipo_documento,cliente_numero_documento from SQLEADOS.Cliente left join SQLEADOS.puntaje on punt_cliente_numero_documento = cliente_numero_documento and cliente_tipo_documento = punt_cliente_tipo_documento where cliente_usuario = 194 and GETDATE() < punt_fecha_vencimiento  group by cliente_apellido,cliente_nombre, cliente_tipo_documento, cliente_numero_documento");
            getDatosClienteCommand.Parameters.AddWithValue("usuario", usuario);
            getDatosClienteCommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = getDatosClienteCommand.ExecuteReader();
            while (reader.Read())
            {
                datos[0] = reader["cliente_tipo_documento"].ToString();
                datos[1] = reader["cliente_numero_documento"].ToString();
                datos[2] = reader["cliente_nombre"].ToString();
                datos[3] = reader["cliente_apellido"].ToString();
                datos[4] = reader["puntaje"].ToString();


            }
            connection.Close();
            return datos;
        }

        internal static void cargarGriddCanje(DataGridView dgv)
        {
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            connection.Open();
            try
            {
                String query = "SELECT [canj_producto],[canj_costo_puntaje] FROM [GD2C2018].[SQLEADOS].[canjeproducto]";
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

        internal static void canje(string ndocumento,string tdocumento,int gastado)
        {

            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand addCanje = new SqlCommand("insert into [GD2C2018].[SQLEADOS].[Canjes] (canje_cliente_tipo_documento,canje_cliente_numero_documento,canje_fecha,canje_puntos_gastados) values (@tdocumento,@ndocumento,GETDATE(),@gastado)");
            addCanje.Parameters.AddWithValue("ndocumento", ndocumento);
            addCanje.Parameters.AddWithValue("tdocumento", tdocumento);
            addCanje.Parameters.AddWithValue("gastado", gastado);

            addCanje.Connection = connection;
            connection.Open();
            int registrosModificados = addCanje.ExecuteNonQuery();
            connection.Close();
            if (registrosModificados > 0) MessageBox.Show("Canje realizado correctamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error al cargar registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }


    }

    #endregion



#region AltaPublicacion

    class GenerarPublicacion : ConsultasSQL {


        internal static string obtenerCodigoPublicacion()
        {
            String codigo;

            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand getCodigo = new SqlCommand("select (max(publicacion_codigo) + 1) as codigoMax from SQLEADOS.Publicacion");
            getCodigo.Connection = connection;
            connection.Open();
            SqlDataReader reader = getCodigo.ExecuteReader();
            reader.Read();
            
            codigo = reader["codigoMax"].ToString();
            
            connection.Close();
            return codigo;
        }


        internal static void llenarComboRubro(ComboBox comboRubro)
        {
            
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand llenarRubro = new SqlCommand("select rubro_descripcion from SQLEADOS.Rubro");
            llenarRubro.Connection = connection;
            connection.Open();
            SqlDataReader reader = llenarRubro.ExecuteReader();
            while (reader.Read())
            {

                comboRubro.Items.Add(reader["rubro_descripcion"].ToString());
            }
            connection.Close();
        }



        internal static void llenarComboGrado(ComboBox comboGrado)
        {

            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand llenarGrado = new SqlCommand("select grado_nombre from SQLEADOS.GradoPrioridad");
            llenarGrado.Connection = connection;
            connection.Open();
            SqlDataReader reader = llenarGrado.ExecuteReader();
            while (reader.Read())
            {

                comboGrado.Items.Add(reader["grado_nombre"].ToString());
            }
            connection.Close();
        }

        internal static void cargarGriddUbicaciones(DataGridView dgv)
        {
            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            connection.Open();
            try
            {
                String query = "select ubicacion_id as identidficador,ubicacion_fila,ubicacion_asiento,ubicacion_sin_numerar,ubicacion_Tipo_codigo,ubicacion_Tipo_Descripcion from SQLEADOs.Ubicacion order by ubicacion_Tipo_Descripcion";
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


        internal static string idRubro(string rubro)
        {
            string idRubro;

            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand CPexistente = new SqlCommand("SELECT rubro_id FROM [GD2C2018].[SQLEADOS].[Rubro] WHERE rubro_descripcion = @rubro");
            CPexistente.Parameters.AddWithValue("rubro", rubro);
            CPexistente.Connection = connection;
            connection.Open();
            SqlDataReader reader = CPexistente.ExecuteReader();
            reader.Read();

        
            idRubro = reader["rubro_id"].ToString();    
            

            connection.Close();
            return idRubro;
        }

        internal static string idGrado(string grado)
        {
            string idGrado;

            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand CPexistente = new SqlCommand("SELECT grado_id FROM [GD2C2018].[SQLEADOS].[GradoPrioridad] WHERE grado_nombre = @grado");
            CPexistente.Parameters.AddWithValue("grado", grado);
            CPexistente.Connection = connection;
            connection.Open();
            SqlDataReader reader = CPexistente.ExecuteReader();
            reader.Read();


            idGrado = reader["grado_id"].ToString();


            connection.Close();
            return idGrado;
        }


        internal static void insertarPublicacion(string codigo, string usuario, string rubroElegido, string gradoPublicacion, string descripcion, int cantidadDeUbicaciones, string estadoPublicacion, DateTime fechaPublicacion, DateTime fechaEspectaculo, string direccion)
        {

            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand insertPublicacion = new SqlCommand("insert into [GD2C2018].[SQLEADOS].[Publicacion] (publicacion_usuario_responsable,publicacion_rubro,publicacion_grado,publicacion_descripcion,publicacion_stock,publicacion_estado,publicacion_puntaje_venta,pubicacion_putaje_compra,publicacion_fecha,publicacion_fecha_venc,publicacion_estado_validacion,publicacion_direccion) values (@usuario,@rubroElegido,@gradoPublicacion,@descripcion,@cantidadDeUbicaciones,@estadoPublicacion,100,30,@fechaPublicacion,@fechaEspectaculo,1,@direccion)");
            insertPublicacion.Parameters.AddWithValue("usuario", usuario);

            insertPublicacion.Parameters.AddWithValue("rubroElegido", rubroElegido);
            insertPublicacion.Parameters.AddWithValue("gradoPublicacion", gradoPublicacion);
            insertPublicacion.Parameters.AddWithValue("cantidadDeUbicaciones", cantidadDeUbicaciones);
            insertPublicacion.Parameters.AddWithValue("estadoPublicacion", estadoPublicacion);
            insertPublicacion.Parameters.AddWithValue("fechaPublicacion", fechaPublicacion);
            insertPublicacion.Parameters.AddWithValue("fechaEspectaculo", fechaEspectaculo);
            insertPublicacion.Parameters.AddWithValue("direccion", direccion);
            insertPublicacion.Parameters.AddWithValue("descripcion", descripcion);


            insertPublicacion.Connection = connection;
            connection.Open();
            int registrosModificados = insertPublicacion.ExecuteNonQuery();
            connection.Close();
            if (registrosModificados > 0) MessageBox.Show("Publicacion ingreada correctamente", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error al cargar registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



        internal static void ubixPubli(string idUbi,string codigo,string precio)
        {


            SqlConnection connection = PalcoNet.Support.Conexion.conexionObtener();
            SqlCommand insertUbiXPublo = new SqlCommand("insert into [GD2C2018].[SQLEADOS].[ubicacionXpublicacion] (ubiXpubli_Publicacion,ubiXpubli_Ubicacion,ubiXpubli_precio) values (@codigo,@idUbi,@precio)");

            insertUbiXPublo.Parameters.AddWithValue("idUbi", idUbi);

            insertUbiXPublo.Parameters.AddWithValue("codigo", codigo);
            insertUbiXPublo.Parameters.AddWithValue("precio", precio);


            insertUbiXPublo.Connection = connection;
            connection.Open();
            int registrosModificados = insertUbiXPublo.ExecuteNonQuery();
            connection.Close();
        
        }
    }





#endregion
}