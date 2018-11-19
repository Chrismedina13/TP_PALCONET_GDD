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
        private static SqlConnection conexion = new SqlConnection(@"Data source=LAPTOP-B6PLD9G\SQLSERVER2012; Initial Catalog=GD2C2018; User id=gdEspectaculos2018; Password= gd2018");

        private static void conexionAbrir()
        {
            try
            {
                conexion.Open();
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
            catch (Exception)
            {
                MessageBox.Show("No se pudo generar la consulta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ejecutador.ExecuteNonQuery();
                MessageBox.Show("Se han realizado los cambios");
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo realizar la operacion");
            }
            conexionCerrar();
        }
    }
}
