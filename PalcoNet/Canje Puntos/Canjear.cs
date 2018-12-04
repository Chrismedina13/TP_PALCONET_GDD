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

namespace PalcoNet.Canje_Puntos
{
    public partial class Canjear : Form
    {
        public Canjear(int puntos,string numeroDocumento,string tipoDocumento)
        {
            InitializeComponent();
            textBoxPuntos.Text = Convert.ToString(puntos);
        }

        private void Canjear_Load(object sender, EventArgs e)
        {
            CanjePuntos.cargarGriddCanje(dataGridView1);
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
        }

        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                textBoxPremio.Text = row.Cells["canj_producto"].Value.ToString();
                textBoxValor.Text = row.Cells["canj_costo_puntaje"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
