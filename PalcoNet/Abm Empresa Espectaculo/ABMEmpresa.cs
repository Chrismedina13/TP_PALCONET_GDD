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
        public ABMEmpresa(int usuarioRecibido)
        {
            InitializeComponent();
            USUARIO_ID = usuarioRecibido;
        }

        private void buttonALTA_Click(object sender, EventArgs e)
        {
            AltaEmpresa Aempresa = new AltaEmpresa(USUARIO_ID);
            Aempresa.Show();
        }

        private void buttonMODIFICAR_Click(object sender, EventArgs e)
        {
            ModificacionEmpresa ModEmpresa = new ModificacionEmpresa();
            ModEmpresa.Show();
        }

        private void buttonBAJA_Click(object sender, EventArgs e)
        {
            EliminarEmpresa EliEmpresa = new EliminarEmpresa();
            EliEmpresa.Show();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
