using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class ABMEmpresa : Form
    {
        int USUARIO_ID;
        Explorador exx;
        public ABMEmpresa(Explorador ex)
        {
            exx = ex;
            InitializeComponent();
            USUARIO_ID = Usuario.ID;
        }

        private void buttonALTA_Click(object sender, EventArgs e)
        {
            AltaEmpresa Aempresa = new AltaEmpresa(this, true, null);
            Aempresa.Show();
            this.Hide();
        }

        private void buttonMODIFICAR_Click(object sender, EventArgs e)
        {
            ModificacionEmpresa ModEmpresa = new ModificacionEmpresa(this);
            ModEmpresa.Show();
        }

        private void buttonBAJA_Click(object sender, EventArgs e)
        {
            EliminarEmpresa EliEmpresa = new EliminarEmpresa(this);
            EliEmpresa.Show();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            exx.Show();
            this.Close();
        }

        private void ABMEmpresa_Load(object sender, EventArgs e)
        {

        }
    }
}
