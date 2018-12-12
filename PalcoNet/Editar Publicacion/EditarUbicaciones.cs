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
    public partial class EditarUbicaciones : Form
    {
        private int empresa;
        public EditarUbicaciones(int idEmpresa)
        {
            empresa = idEmpresa;
            InitializeComponent();
        }

        private void EditarUbicaciones_Load(object sender, EventArgs e)
        {

        }

        //SALIR
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
