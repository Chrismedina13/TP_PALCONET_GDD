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

            datos = CanjePuntos.obtenerPuntaje(Usuario.ID);
            DataTable dt = cargarDatosCliente();
            textBoxTipoDocumento.Text = dt.Rows[0][2].ToString();
            textBoxNumeroDocumento.Text = dt.Rows[0][3].ToString();
            textBoxNombreCliente.Text = dt.Rows[0][1].ToString();
            textBoxApellido.Text = dt.Rows[0][0].ToString();
            dt = obtenerPuntajeCliente();
            textBoxPuntaje.Text = dt.Rows[0][0].ToString();
            if (Usuario.Rol == "Administrativo")
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

        private DataTable obtenerPuntajeCliente() {
            String query = "SELECT SUM(punt_puntaje) as 'Puntaje' FROM SQLEADOS.puntaje p JOIN SQLEADOS.Cliente  ON p.punt_cliente_numero_documento = cliente_numero_documento AND p.punt_cliente_tipo_documento LIKE cliente_tipo_documento WHERE p.punt_id NOT IN (SELECT pp.punt_id FROM SQLEADOS.puntaje pp WHERE pp.punt_fecha_vencimiento <= GETDATE()) AND cliente_usuario = 85";
            return DBConsulta.AbrirCerrarObtenerConsulta(query);
        }

        private DataTable cargarDatosCliente() 
        {
            String query = "SELECT cliente_apellido as 'Apellido', cliente_nombre as 'Nombre', cliente_tipo_documento as 'TIPO DOCUMENTO', cliente_numero_documento as 'Numero' FROM SQLEADOS.Cliente WHERE cliente_usuario = 85 GROUP BY cliente_apellido, cliente_nombre, cliente_tipo_documento, cliente_numero_documento";
            return DBConsulta.AbrirCerrarObtenerConsulta(query);
            
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
