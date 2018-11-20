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

namespace PalcoNet.Abm_Cliente
{
    public partial class ABMCliente : Form
    {
        public ABMCliente()
        {
            InitializeComponent();
        }

        private void buttonALTA_Click(object sender, EventArgs e)
        {
            AltaCliente al = new AltaCliente();
            al.Show();
        }

        private void buttonBAJA_Click(object sender, EventArgs e)
        {
            EliminarCliente el = new EliminarCliente();
            el.Show();
        }

        private void buttonMODIFICAR_Click(object sender, EventArgs e)
        {

        }


        private void ABMCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
