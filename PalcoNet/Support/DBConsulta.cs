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
using System.Data;

namespace PalcoNet.Support
{
    class DBConsulta
    {
        private static SqlConnection conexion;
        public static void conexionAbrir()
        {
            try
            {
                conexion = new SqlConnection(@"Data source=.\SQLSERVER2012;Initial Catalog=GD2C2018;User id=gdEspectaculos2018;Password= gd2018;MultipleActiveResultSets=True");
                conexion.Open();
                //          MessageBox.Show("CONEXION HECHA A LA DB");
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar conectar con la DB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void conexionCerrar()
        {
            conexion.Close();
        }

        public static int creacionNuevoUser(String nombre, String contra, String rol) {
            
            try
            {
                SqlCommand crearNuevoUser = new SqlCommand("[SQLeados].crearNuevoUserPorRegistroOABM", conexion);

                crearNuevoUser.CommandType = CommandType.StoredProcedure;
                crearNuevoUser.Parameters.Add("@user", SqlDbType.VarChar).Value = nombre;
                crearNuevoUser.Parameters.Add("@pass", SqlDbType.VarChar).Value = contra;
                crearNuevoUser.Parameters.Add("@rol", SqlDbType.VarChar).Value = rol;
                crearNuevoUser.BeginExecuteNonQuery();
                MessageBox.Show("Se agregó el nuevo usuario y su rol");
                return 1;
            }
            catch (Exception ex) {
                MessageBox.Show("No se pudo agregar al usuario:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static void creacionNuevoDomicilio(string calle, int numeroCalle, int piso, string dto, string localidad, string codigoPostal, String tipo) {
            SqlCommand crearNuevoDomicilioCliente;
            try
            {
                // DOMICILIO ES PARA Cliente
                DataTable ds = obtenerPKdelUltimoClienteOEmpresaIngresada();
                if (tipo.Equals("Cliente"))
                {
                    crearNuevoDomicilioCliente = new SqlCommand("[SQLeados].crearNuevoDomicilioDeCliente", conexion);

                    crearNuevoDomicilioCliente.CommandType = CommandType.StoredProcedure;

                    crearNuevoDomicilioCliente.Parameters.Add("@calle", SqlDbType.VarChar).Value = calle;
                    crearNuevoDomicilioCliente.Parameters.Add("@numeroCalle", SqlDbType.Int).Value = numeroCalle;
                    crearNuevoDomicilioCliente.Parameters.Add("@piso", SqlDbType.VarChar).Value = piso;

                    crearNuevoDomicilioCliente.Parameters.Add("@dto", SqlDbType.VarChar).Value = dto;
                    crearNuevoDomicilioCliente.Parameters.Add("@localidad", SqlDbType.VarChar).Value = localidad;
                    crearNuevoDomicilioCliente.Parameters.Add("@codPostal", SqlDbType.VarChar).Value = codigoPostal;

                    crearNuevoDomicilioCliente.Parameters.Add("@numeroDoc", SqlDbType.VarChar).Value = ds.Rows[0][1];
                    crearNuevoDomicilioCliente.Parameters.Add("@tipoDoc", SqlDbType.VarChar).Value = ds.Rows[0][0];


                    crearNuevoDomicilioCliente.BeginExecuteNonQuery();
                    MessageBox.Show("Se agregó el domicilio para el nuevo cliente");
                    return;
                }
                // ENTONCES EL DOMICILIO ES PARA EMPRESA
                crearNuevoDomicilioCliente = new SqlCommand("[SQLeados].crearNuevoDomicilioDeEmpresa", conexion);

                crearNuevoDomicilioCliente.CommandType = CommandType.StoredProcedure;

                crearNuevoDomicilioCliente.Parameters.Add("@calle", SqlDbType.VarChar).Value = calle;
                crearNuevoDomicilioCliente.Parameters.Add("@numeroCalle", SqlDbType.Int).Value = numeroCalle;
                crearNuevoDomicilioCliente.Parameters.Add("@piso", SqlDbType.VarChar).Value = piso;

                crearNuevoDomicilioCliente.Parameters.Add("@dto", SqlDbType.VarChar).Value = dto;
                crearNuevoDomicilioCliente.Parameters.Add("@localidad", SqlDbType.VarChar).Value = localidad;
                crearNuevoDomicilioCliente.Parameters.Add("@codPostal", SqlDbType.VarChar).Value = codigoPostal;

                crearNuevoDomicilioCliente.Parameters.Add("@numeroDoc", SqlDbType.VarChar).Value = ds.Rows[0][0];
                crearNuevoDomicilioCliente.Parameters.Add("@tipoDoc", SqlDbType.VarChar).Value = ds.Rows[0][1];

                crearNuevoDomicilioCliente.BeginExecuteNonQuery();
                MessageBox.Show("Se agregó el domicilio para la nueva empresa");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo agregar al usuario:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        public static void creacionNuevoCliente(String nombre, String apellido, String tipoDoc, String fechaNac,
            String fechaCreacion, String mail, String cuit, long numeroDoc, String telefono, String tarjeta)
        {
            conexionAbrir();
            try {
                SqlCommand crearNuevoCliente = new SqlCommand("[SQLeados].crearNuevoCliente", conexion);

                crearNuevoCliente.CommandType = CommandType.StoredProcedure;
                crearNuevoCliente.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                crearNuevoCliente.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido;
                crearNuevoCliente.Parameters.Add("@tipoDoc", SqlDbType.VarChar).Value = tipoDoc;

                crearNuevoCliente.Parameters.Add("@fechaNacimiento", SqlDbType.VarChar).Value = fechaNac;
                crearNuevoCliente.Parameters.Add("@fechaCreacion", SqlDbType.VarChar).Value = fechaCreacion;
                crearNuevoCliente.Parameters.Add("@mail", SqlDbType.VarChar).Value = mail;

                crearNuevoCliente.Parameters.Add("@cuit", SqlDbType.VarChar).Value = cuit;
                //DEMASIADOS PROBLEMAS ME DA PASAR UN LONG A SQL, ASI QUE LO PASO COMO STRING Y EN EL PROCEDURE
                //LUEGO LO CONVIERTO A NUMERIC
                crearNuevoCliente.Parameters.Add("@numeroDocumento", SqlDbType.VarChar).Value = numeroDoc.ToString();
                crearNuevoCliente.Parameters.Add("@telefono", SqlDbType.VarChar).Value = telefono;

                crearNuevoCliente.Parameters.Add("@tarjeta", SqlDbType.VarChar).Value = tarjeta;

                crearNuevoCliente.BeginExecuteNonQuery();
                MessageBox.Show("Se agregó el nuevo Cliente");
                conexionCerrar();
            }
            catch (Exception ex) {
                MessageBox.Show("No se pudo agregar el nuevo cliente:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }

        public static DataTable obtenerPKdelUltimoClienteOEmpresaIngresada()
        {
            DataTable dt = new DataTable();
            SqlCommand crearNuevoCliente = new SqlCommand("[SQLeados].[obtenerPKdelUltimoClienteIngresado]", conexion);
            crearNuevoCliente.CommandType = CommandType.StoredProcedure;
            dt.Load(crearNuevoCliente.ExecuteReader());
            return dt;
        }

        public static DataSet ConectarConsulta(String cmd)
        {
            conexionAbrir();
            try
            {
                DataSet DS = new DataSet();
                SqlDataAdapter DP = new SqlDataAdapter(cmd, conexion);
                DP.Fill(DS);
                conexionCerrar();
                return DS;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar la consulta:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool dataSetVacio(DataSet DS)
        {
            return tamanioDataSet(DS) == 0;
        }

        public static int tamanioDataSet(DataSet DS) {
            return DS.Tables[0].Rows.Count;
        }

        public static void ModificarCliente(String cmd) {
            try {
                MessageBox.Show(cmd);
                SqlCommand ejecutador = new SqlCommand(cmd);
                ejecutador.Connection = conexion;
                ejecutador.ExecuteNonQuery();
                MessageBox.Show("Se han realizado los cambios");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar al cliente\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static void ModificarDB(String cmd)
        {
            conexionAbrir();
            try
            {
                SqlCommand ejecutador = new SqlCommand(cmd);
                ejecutador.Connection = conexion;
                ejecutador.ExecuteNonQuery();
                MessageBox.Show("Se han realizado los cambios");
                conexionCerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la operacion\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private static String agregarAComandoDeBusquedad(String aBuscar, String expresionExtra) {
            if (!aBuscar.Equals("")) { 
                return expresionExtra + "LIKE ('"+aBuscar+"'+'%')";
            }
            return "";
        }

        public static void darDeBajaUser(int user) {
            SqlCommand darDeBajaUser = new SqlCommand("[SQLeados].[darDeBajaUserCliente]", conexion);
            darDeBajaUser.CommandType = CommandType.StoredProcedure;
            darDeBajaUser.Parameters.Add("@user", SqlDbType.Int).Value = user;
            darDeBajaUser.ExecuteNonQuery();
            return;
        }

        public static DataTable obtenerTodosLosDatosRelevantesDe1Cliente(int userId)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand("[SQLeados].[obtenerDatosRelevantesParaModificarCliente]", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@userID", SqlDbType.Int).Value = userId;
            dt.Load(command.ExecuteReader());
            return dt;
        }

        public static DataTable buscarClienteSegunCriterios2(String nombre, String apellido, String numero, String mail)
        {
            DataTable dt = new DataTable();
            String comando = "SELECT c.cliente_usuario as 'ID', u.usuario_estado as 'Estado', c.cliente_nombre as 'Nombre', c.cliente_apellido as 'Apellido', cliente_tipo_documento 'Tipo documento', cliente_numero_documento as 'Número', c.cliente_email as 'Email' FROM SQLEADOS.Cliente c JOIN SQLEADOS.Usuario u ON usuario_Id = cliente_id where usuario_estado = 1";

            comando = comando + agregarAComandoDeBusquedad(nombre, " AND cliente_nombre ");
            comando = comando + agregarAComandoDeBusquedad(apellido, " AND cliente_apellido ");
            comando = comando + agregarAComandoDeBusquedad(numero, " AND CONVERT(varchar(50), cliente_numero_documento) ");
            comando = comando + agregarAComandoDeBusquedad(mail, " AND cliente_email ");

            SqlCommand buscarClientes = new SqlCommand(comando, conexion);
            dt.Load(buscarClientes.ExecuteReader());
            return dt;
        }
    
        public static DataTable llenarGrillaABMCliente() {
            DataTable dt = new DataTable();
            SqlCommand crearNuevoCliente = new SqlCommand("[SQLeados].[llenarGrillaABMCliente]", conexion);
            crearNuevoCliente.CommandType = CommandType.StoredProcedure;
            dt.Load(crearNuevoCliente.ExecuteReader());
            return dt;
        }
        public static bool repeticion_de_campo_tipoDOC_numero_o_CUIL(String cuil, String numero, String tipo) {
            return repe_CUIL_enCliente(cuil) || repe_TipoDOCYNumero_enCliente(numero, tipo);
        }

        public static bool repe_TipoDOCYNumero_enCliente(String numero, String tipo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("[SQLeados].[repeticionDeTIPODOCYNumeroEnCliente]", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = tipo;
            cmd.Parameters.Add("@numero", SqlDbType.NVarChar).Value = numero;
            dt.Load(cmd.ExecuteReader());
            if (CasoData.obtenerStringPrimeraCelda(dt) == "1")
            {
                return true;
            }
            return false;
        }

        public static bool repe_CUIL_enCliente(String cuil) {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("[SQLeados].[repeticionDeCUILEnCliente]", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@cuil", SqlDbType.NVarChar).Value = cuil;
            dt.Load(cmd.ExecuteReader());
            if (CasoData.obtenerStringPrimeraCelda(dt) == "1") {
                return true;
            }
            return false;
        }

        public static bool repe_mail(String mail) {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("[SQLeados].[repeticionDeMail]", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mail", SqlDbType.NVarChar).Value = mail;
            dt.Load(cmd.ExecuteReader());
            if (CasoData.obtenerStringPrimeraCelda(dt) == "1")
            {
                return true;
            }
            return false;
        }

        /* Obtengo el nombre usuario, importante ya que si hay 2 nombres de pila iguales entonces habrá un incrementador
         * numerico al final apra diferenciarlos
       
*/       public static String obtenerNombreUltimoUserIngresado() {
            DataSet dt = new DataSet();
            String comando = "Select TOP 1 usuario_nombre from SQLEADOS.Usuario order by usuario_Id DESC";
            SqlDataAdapter dP = new SqlDataAdapter(comando, conexion);
            dP.Fill(dt);
            return dt.Tables[0].Rows[0][0].ToString();
        }
    }
}
