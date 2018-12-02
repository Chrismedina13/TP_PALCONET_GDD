using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Support;

namespace PalcoNet
{
    public partial class tablaPaginada : Form
    {
        public tablaPaginada()
        {
            DBConsulta.conexionAbrir();
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void configuracionGrilla(DataTable dt) {
            dataGridView1.DataSource = dt;

            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 50;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 100;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 0;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 100;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 100;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column4.Width = 90;
            return;
        }

        private void tablaPaginada_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            configuracionGrilla(DBConsulta.obtenerHistorialCompras(18));
            Conexion.conexionCerrar();
        }
    }
}
