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

namespace PalcoNet.Editar_Publicacion
{
    public partial class Seleccionar1Categoria : Form
    {
        private EditarCosasDePublicacion ed;
        public Seleccionar1Categoria(EditarCosasDePublicacion original)
        {
            ed = original;
            InitializeComponent();
        }

        private void Seleccionar1Categoria_Load(object sender, EventArgs e)
        {
            String cadena = "SELECT rubro_descripcion FROM SQLEADOS.Rubro";
            DBConsulta.conexionAbrir();
            dataGridView1.DataSource = DBConsulta.obtenerConsultaEspecifica(cadena);
            DBConsulta.conexionCerrar();
        }

        //SELECCIONAR ELEJIDO
        private void button1_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
            ed.
            cambiarCategoria(dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString());
           
            this.Close();
           
        }
    }
}
