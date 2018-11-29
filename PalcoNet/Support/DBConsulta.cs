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
        private static void conexionAbrir()
        {
            try
            {
                conexion = new SqlConnection(@"Data source=.\SQLSERVER2012;Initial Catalog=GD2C2018;User id=gdEspectaculos2018;Password= gd2018");
                conexion.Open();
                //          MessageBox.Show("CONEXION HECHA A LA DB");
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar conectar con la DB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void conexionCerrar()
        {
            conexion.Close();
        }

        public static int creacionNuevoUser(String nombre, String contra, String rol) {
            conexionAbrir();
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
    }
}
