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

namespace PalcoNet.Login_y_seguridad
{
    public partial class SeleccionarROL : volver

    {
        String user;
        public SeleccionarROL(String usuario)
        {
            user = usuario;
            InitializeComponent();
        }

        private void SeleccionarROL_Load(object sender, EventArgs e)
        {

        }

        private void volver_boton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
