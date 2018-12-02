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

namespace PalcoNet.Historial_Cliente
{
    public partial class HistorialCliente : tablaPaginada
    {
        private int tamanioPagina = 10;
        private int paginaActual = 1;
        private int totalPagina;
        private int userID = 0;

        public HistorialCliente(int userIDRecibido)
        {
            DBConsulta.conexionAbrir();
            InitializeComponent();
            String total = DBConsulta.obtenerCantidadTotalCompras(userID).Rows[0][0].ToString();
            userID = userIDRecibido;
            totalPagina = Convert.ToInt32(total);
            labelPaginas.Text = paginaActual.ToString() + " de " + tamanioPagina.ToString();
            
        }

        private void configuracionGrilla(DataTable dt)
        {
            dataGridView2.DataSource = dt;

            DataGridViewColumn column = dataGridView2.Columns[0];
            column.Width = 70;
            DataGridViewColumn column1 = dataGridView2.Columns[1];
            column1.Width = 70;
            DataGridViewColumn column2 = dataGridView2.Columns[2];
            column2.Width = 200;
            DataGridViewColumn column3 = dataGridView2.Columns[3];
            column3.Width = 60;
            DataGridViewColumn column4 = dataGridView2.Columns[4];
            column4.Width = 60;
            DataGridViewColumn column5 = dataGridView2.Columns[5];
            column4.Width = 60;


            return;
        }


        //AVANZAR LA SIGUEINTE PAGINA
        private void button2_Click(object sender, EventArgs e)
        {
            if (paginaActual < tamanioPagina)
            {
                paginaActual += 1;
                configuracionGrilla(DBConsulta.obtenerHistorialCompras(userID, paginaActual, tamanioPagina));
                labelPaginas.Text = paginaActual.ToString() + " de " + tamanioPagina.ToString();
            }
        }

        // VOLVER A LA ANTERIOR PAGINA
        private void button1_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual -= 1;
                configuracionGrilla(DBConsulta.obtenerHistorialCompras(userID, paginaActual, tamanioPagina));
                labelPaginas.Text = paginaActual.ToString() + " de " + tamanioPagina.ToString();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      //      
        }

        private void HistorialCliente_Load(object sender, EventArgs e)
        {
            configuracionGrilla(DBConsulta.obtenerHistorialCompras(userID, 1, tamanioPagina));
        }
    }
}
