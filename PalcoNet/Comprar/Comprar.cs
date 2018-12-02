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

namespace PalcoNet.Comprar
{
    public partial class Comprar : Form1
    {
        private int publicacionID;
        private int paginaActual;
        private int ultimaHoja;
        private int totalVistoPorPagina = 10;
        public Comprar(int publicacion)
        {
            publicacionID = publicacion;
            paginaActual = 1;
            InitializeComponent();
            DBConsulta.conexionAbrir();
            InitializeComponent();
        }

        private void Comprar_Load(object sender, EventArgs e)
        {
            String res = DBConsulta.obtenerTotalUbicacionDePublicacion(publicacionID).Rows[0][0].ToString();
            int cantidad = Convert.ToInt32(res);
            ultimaHoja = (cantidad / totalVistoPorPagina) + 1;
            configuracionGrilla(DBConsulta.obtenerUbicacionDePublicacion(publicacionID, 1, totalVistoPorPagina)); 
        }

        private void configuracionGrilla(DataTable dt)
        {
            dataGridView1.DataSource = dt;

            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 50;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 80;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 210;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 80;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 100;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column4.Width = 90;

            labelPaginas.Text = paginaActual.ToString() + " de " + ultimaHoja.ToString();
            return;
        }

        private void buttonPrimeraHoja_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            configuracionGrilla(DBConsulta.obtenerUbicacionDePublicacion(publicacionID, paginaActual, totalVistoPorPagina));
            labelPaginas.Text = paginaActual.ToString() + " de " + ultimaHoja.ToString();
        }

        private void botonAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual -= 1;
                configuracionGrilla(DBConsulta.obtenerUbicacionDePublicacion(publicacionID, paginaActual, totalVistoPorPagina));
                labelPaginas.Text = paginaActual.ToString() + " de " + ultimaHoja.ToString();
            }
        }

        private void botonsiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < ultimaHoja)
            {
                paginaActual += 1;
                configuracionGrilla(DBConsulta.obtenerUbicacionDePublicacion(publicacionID, paginaActual, totalVistoPorPagina));
                labelPaginas.Text = paginaActual.ToString() + " de " + ultimaHoja.ToString();
            }
        }

        private void buttonUltimaHoja_Click(object sender, EventArgs e)
        {
            paginaActual = ultimaHoja;
            configuracionGrilla(DBConsulta.obtenerUbicacionDePublicacion(publicacionID, paginaActual, totalVistoPorPagina));
            labelPaginas.Text = paginaActual.ToString() + " de " + ultimaHoja.ToString();
        }
    }
}
