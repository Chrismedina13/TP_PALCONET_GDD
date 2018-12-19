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
    public partial class AgregarTarjeta : Form
    {
        private int userID;
        ConfirmarCompra c;
        public AgregarTarjeta(int us, ConfirmarCompra cp)
        {
            userID = us;
            c = cp;
            InitializeComponent();
        }

        //BOTON AGREGA LA TARJETA SIEMPRE Y CUANDO SEA VÁLIDA Y SE REPITA
        private void button1_Click(object sender, EventArgs e)
        {
            if (AyudaExtra.esStringNumerico(textBox1.Text) && AyudaExtra.esStringNumerico(textBox2.Text))
            {
                if (textBox1.Text.Contains(textBox2.Text))
                {
                    //ES NÚMERO VÁLIDO
                    String queryUpdate = "UPDATE SQLEADOS.Cliente SET cliente_datos_tarjeta = "+textBox1.Text+" WHERE cliente_usuario = "+userID;
                    DBConsulta.AbrirCerrarModificarDB(queryUpdate);
                    MessageBox.Show("El número de tarjeta fue ingresada y actualizada con éxito");
                    DBConsulta.conexionAbrir();
                    c.cargarDatosDeCompra();
                    DBConsulta.conexionCerrar();
                    this.Close();
                }
                else {
                    MessageBox.Show("El número de tarjeta no se repite, vuelva a ingresarla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Uno de los 2 campos ingresados, o ambos, no son numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarTarjeta_Load(object sender, EventArgs e)
        {
            String queryUser = "SELECT usuario_nombre FROM SQLEADOS.Usuario WHERE usuario_Id = " + userID;
            DBConsulta.conexionAbrir();
            labelNombreUser.Text = DBConsulta.obtenerConsultaEspecifica(queryUser).Rows[0][0].ToString();
            DBConsulta.conexionCerrar();
            labelUSERID.Text = userID.ToString();
        }
    }
}
