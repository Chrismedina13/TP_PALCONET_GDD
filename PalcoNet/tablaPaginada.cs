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
            InitializeComponent();
/*
            String total = DBConsulta.obtenerCantidadTotalCompras(userID).Rows[0][0].ToString();
            totalPagina = Convert.ToInt32(total);
            labelPaginas.Text = paginaActual.ToString() + " de " + tamanioPagina.ToString();
  */      }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*private void configuracionGrilla(DataTable dt) {
            dataGridView1.DataSource = dt;
            
            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 70;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 70;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 200;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 60;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 60;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column4.Width = 60;

            
            return;
        }*/

        private void tablaPaginada_Load(object sender, EventArgs e)
        {
        }

        //PASAR SIGUIENTE PÁGINA
        private void button2_Click(object sender, EventArgs e)
        {
            /*
            
             * */
        }
        //PASAR ANTERIOR PÁGINA
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            
             * */
        }

        //BOTON VOLVER
        private void button3_Click(object sender, EventArgs e)
        {
            DBConsulta.conexionCerrar();
            this.Close();
        }

        
    }
}
