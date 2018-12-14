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
    public partial class Elegir_categoria : Form1
    {
        /*
        private int publicacionID;
        private int paginaActual;
        private int ultimaHoja;
        private int totalVistoPorPagina = 10;
        */
        String cadenaCategorias;
        ComprarPrincipal a;

        public Elegir_categoria(String categoriasSelecionadas, ComprarPrincipal cp)
        {
            cadenaCategorias = categoriasSelecionadas;
            
            a = cp;
   //         paginaActual = 1;
            InitializeComponent();
        }

        private void configuracionGrilla(DataTable dt)
        {
            dataGridView1.DataSource = dt;

            labelCategorias.Text += cadenaCategorias;
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Elegir_categoria_Load(object sender, EventArgs e)
        {
            DBConsulta.conexionAbrir();
            configuracionGrilla(DBConsulta.obtenerLosRubros());
            DBConsulta.conexionCerrar();
        }

        //LIMPIAR LABEL CATEGORIA
        private void button1_Click_1(object sender, EventArgs e)
        {
            labelCategorias.Text = "";
            cadenaCategorias ="";
            a.rellenarCategoríasSeleccionadas("");
            DBConsulta.conexionAbrir();
            configuracionGrilla(DBConsulta.obtenerLosRubros());
            DBConsulta.conexionCerrar();
        }

        //Agrega al Label categorías aquellas categorías que no están en ella.
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;

            if (!labelCategorias.Text.Contains(dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString()))
            {
                labelCategorias.Text += dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString() + ";";
            }
            //Elimina las categorías de la lista
            dataGridView1.Rows.RemoveAt(rowindex);
        }

        //BOTON AGREGAR
        private void button3_Click(object sender, EventArgs e)
        {
            a.rellenarCategoríasSeleccionadas(labelCategorias.Text);
            this.Close();
        }
    }
}
