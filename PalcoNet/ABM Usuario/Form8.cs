using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Globalization;
using System.Data.SqlClient;

namespace PalcoNet.ABM_Usuario
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void buttonCliente_Click(object sender, EventArgs e)
        {
            Abm_Cliente.EliminarCliente form = new Abm_Cliente.EliminarCliente();
            form.Show();
            this.Hide();
        }

        private void buttonEmpresa_Click(object sender, EventArgs e)
        {
            Abm_Empresa_Espectaculo.EliminarEmpresa form = new Abm_Empresa_Espectaculo.EliminarEmpresa();
            form.Show();
            this.Hide();
        }

       
    }
}
