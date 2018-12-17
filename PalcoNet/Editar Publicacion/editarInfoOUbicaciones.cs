using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Editar_Publicacion
{
    public partial class editarInfoOUbicaciones : Form
    {
        int idpublicacion;
        EditarPublicacion ed;
        public editarInfoOUbicaciones(int id, EditarPublicacion edit)
        {
            ed = edit;
            idpublicacion = id;
            InitializeComponent();
        }

        private void editarInfoOUbicaciones_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //VOLVER
            ed.Show();
            this.Close();
        }

        public void cerrar() {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //EDITAR INFORMACIÓN
            EditarCosasDePublicacion editar = new EditarCosasDePublicacion(idpublicacion, ed, this);
            editar.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditarUbicaciones ubi = new EditarUbicaciones(idpublicacion, ed, this);
            ubi.Show();
            this.Hide();
        }
    }
}
