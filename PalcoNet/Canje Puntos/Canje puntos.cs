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
    public partial class canjePuntos : Form
    {
        public canjePuntos(int usuario)
        {
            String[] datos = new string[5];
            InitializeComponent();

            datos = CanjePuntos.obtenerPuntaje(usuario);

            textBoxTipoDocumento.Text = datos[0];
            textBoxNumeroDocumento.Text = datos[1];
            textBoxNombreCliente.Text = datos[2];
            textBoxApellido.Text = datos[3];
            textBoxPuntaje.Text = datos[4];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
