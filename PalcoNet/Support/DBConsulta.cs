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

        public static DataSet ConectarConsulta(String cmd) {
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

        public static bool dataSetVacio(DataSet DS) {
            return false;
        }

        public static void ModificarDB(String cmd) {
            conexionAbrir();
            try {
                SqlCommand ejecutador = new SqlCommand(cmd);
                ejecutador.Connection = conexion;
                ejecutador.ExecuteNonQuery();
                MessageBox.Show("Se han realizado los cambios");
                conexionCerrar();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo realizar la operacion");
            }
            
        }
    }
}
