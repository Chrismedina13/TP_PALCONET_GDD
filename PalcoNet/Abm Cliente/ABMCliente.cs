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
        Explorador exx;
        
        
        

        public ABMCliente(Explorador ex)
        {
            exx = ex;
            
            
            
            InitializeComponent();
        }

        private void buttonALTA_Click(object sender, EventArgs e)
        {
            AltaCliente al = new AltaCliente(null, false, this, true);
            al.Show();
            this.Hide();
        }

        private void buttonBAJA_Click(object sender, EventArgs e)
        {
            EliminarCliente el = new EliminarCliente(this);
            el.Show();
            this.Hide();
        }

        private void buttonMODIFICAR_Click(object sender, EventArgs e)
        {
            ModificarCliente Ml = new ModificarCliente(this);
            Ml.Show();
            this.Hide();
        }


        private void ABMCliente_Load(object sender, EventArgs e)
        {

        }

        private void volver_boton_Click_1(object sender, EventArgs e)
        {
            exx.Show();
            this.Close();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            exx.Show();
            this.Close();
        }
    }
}
