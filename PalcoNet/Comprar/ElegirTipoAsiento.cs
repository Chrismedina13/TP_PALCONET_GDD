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
    public partial class ElegirTipoAsiento : Form
    {
        String cadenaTipo;
        ComprarPrincipal a;
        public ElegirTipoAsiento(String categoriasSelecionadas, ComprarPrincipal cp)
        {
            cadenaTipo = categoriasSelecionadas;

            a = cp;
            InitializeComponent();
        }

        private void ElegirTipoAsiento_Load(object sender, EventArgs e)
        {
            configuracionGrilla(DBConsulta.obtenerConsultaEspecifica("SELECT DISTINCT ubicacion_Tipo_Descripcion FROM SQLEADOS.Ubicacion"));
        }

        private void configuracionGrilla(DataTable dt)
        {
            dataGridView1.DataSource = dt;

            labelCategorias.Text += cadenaTipo;
            return;
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            labelCategorias.Text = "";
            cadenaTipo = "";
            a.rellenarCategoríasSeleccionadas("");
            configuracionGrilla(DBConsulta.obtenerConsultaEspecifica("SELECT DISTINCT ubicacion_Tipo_Descripcion FROM SQLEADOS.Ubicacion"));
        }

        //VUELVE A LA VENTANA COMPRARPRINCIPAL CON LOS DATOS PUESTOS AQUI
        private void button3_Click(object sender, EventArgs e)
        {
            a.rellenarTiposSeleccionadas(labelCategorias.Text);
            this.Close();
        }
    }
}
