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
    public partial class FINALIZARUNAPUBLICACION : Form
    {
        EditarPublicacion volver;
        String idpublicaicon;
        public FINALIZARUNAPUBLICACION(EditarPublicacion edit, String publicacionID)
        {
            idpublicaicon = publicacionID;
            volver = edit;
            InitializeComponent();
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            cargar();
        }

        private void cargar() { 
            String query = "SELECT publicacion_descripcion FROM SQLEADOS.Publicacion where publicacion_codigo = " + idpublicaicon;
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            labelNombre.Text = dt.Rows[0][0].ToString();
        }

        private void FINALIZARUNAPUBLICACION_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //VOLVER
            volver.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true) {
                MessageBox.Show("No has cambiado el estado de la publicación", "Error");
                return;
            }
            String QUERY = "UPDATE SQLEADOS.Publicacion SET publicacion_estado = 'Finalizado' WHERE publicacion_codigo = " + idpublicaicon;
            DBConsulta.AbrirCerrarModificarDB(QUERY);
            MessageBox.Show("Se ha modificado el estado de la publicación seleccionada");
            volver.carga();
            volver.Show();
            this.Close();
        }
    }
}
