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
        Explorador ex;
        public canjePuntos(int usuario, Explorador exx)
        {
            ex = exx;
            String[] datos = new string[5];
            InitializeComponent();

            datos = CanjePuntos.obtenerPuntaje(usuario);

            textBoxTipoDocumento.Text = datos[0];
            textBoxNumeroDocumento.Text = datos[1];
            textBoxNombreCliente.Text = datos[2];
            textBoxApellido.Text = datos[3];
            textBoxPuntaje.Text = datos[4];

            if (textBoxPuntaje.Text == "")
            {
                MessageBox.Show("Es un administrador no puede canjear puntos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPuntaje.Text = "0";
            }
            else {

                if (Convert.ToInt32(textBoxPuntaje.Text) < 0)
                {

                    textBoxPuntaje.Text = "0";
                }

            }
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btCanje_Click(object sender, EventArgs e)
        {
            int puntos = Convert.ToInt32(textBoxPuntaje.Text);

            Canjear canje = new Canjear(puntos, textBoxNumeroDocumento.Text, textBoxTipoDocumento.Text, this);
     //       canje.Closed += (s, args) => this.Close();
            canje.Show();
            this.Hide();


        }
        //BOTON VOLVER
        private void button1_Click(object sender, EventArgs e)
        {
            ex.Show();
            this.Close();
        }
    }
}
