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

namespace PalcoNet.Abm_Rubro
{
    public partial class ABMRUBRO : Form
    {
        Explorador exx;
        public ABMRUBRO(Explorador ex)
        {
            exx = ex;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!AyudaExtra.esStringLetra(textBox1.Text)) {
                MessageBox.Show("El nombre de la categoría debe ser solo alfabética", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estaRepetidoOParecido(textBox1.Text)) {
                MessageBox.Show("El nombre de la categoría no debe ser parecido al otro que ya está en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String query = "INSERT INTO SQLEADOS.Rubro(rubro_descripcion) VALUES ('" + textBox1.Text + "')";
            DBConsulta.AbrirCerrarModificarDB(query);
            cargar();
        }

        private bool estaRepetidoOParecido(String text) {
            String query = "SELECT COUNT(*) FROM SQLEADOS.Rubro WHERE rubro_descripcion LIKE '" + text + "%'";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            int res = Convert.ToInt32(dt.Rows[0][0].ToString());
            return res > 0;
        }

        private void cargar() {
            String query = "SELECT rubro_id AS 'ID', rubro_descripcion AS 'Nombre' FROM SQLEADOS.Rubro";
            dataGridView1.DataSource = DBConsulta.AbrirCerrarObtenerConsulta(query);
        }

        private void ABMRUBRO_Load(object sender, EventArgs e)
        {
            cargar();
        }

        //VOLVER
        private void button3_Click(object sender, EventArgs e)
        {
            exx.Show();
            this.Close();
        }
    }
}
