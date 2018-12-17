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
    public partial class PonerCaracteristicasDeUbicacion : Form
    {
        EditarUbicaciones editar;
        String fi, ass;
        public PonerCaracteristicasDeUbicacion(EditarUbicaciones ed ,String fila, String asiento, String precio, String sector)
        {
            textBox1.Text = precio;
            comboBox1.Text = sector;
            editar = ed;
            fi = fila;
            ass = asiento;
            InitializeComponent();
            labelUBICACION.Text = fila + "-" + asiento;
        }

        private void PonerCaracteristicasDeUbicacion_Load(object sender, EventArgs e)
        {
            String query = "SELECT DISTINCT ubicacion_Tipo_Descripcion FROM SQLEADOS.Ubicacion";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            for (int i = 0; i < dt.Rows.Count; i++) {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            //AGREGAR
            if (!AyudaExtra.esStringNumerico(textBox1.Text)) {
                MessageBox.Show("El precio no es un número");
                return;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("No has seleccionado ningún tipo de ubicación aún");
                return;
            }
            editar.agregarUbicacionConPrecioYTipo(fi, ass, textBox1.Text, comboBox1.SelectedItem.ToString());
            this.Close();
        }
    }
}
