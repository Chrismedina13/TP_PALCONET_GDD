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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class ModificarEmpresaElegida : volver
    {
        public ModificarEmpresaElegida(String razonSocialVieja,String mailViejo,String cuitViejo)
        {   
            String[] datos = new string[9];
            InitializeComponent();
            textBoxRazonSocial.Text = razonSocialVieja;
            textBoxCuit.Text = cuitViejo;
            textBoxMail.Text = mailViejo;
            datos = ConsultasSQLEmpresa.getDatosEmpresa(razonSocialVieja,cuitViejo,mailViejo);

            textBoxCiudad.Text = datos[0];
            textBoxTelefono.Text = datos[1];
            txtHabilitado.Text = datos[2];
            textBoxCalle.Text = datos[3];
            textBoxNroCalle.Text = datos[4];
            textBoxPiso.Text = datos[5];
            textBoxDto.Text = datos[6];
            textBoxLocalidad.Text = datos[7];
            textBoxCodigoPostal.Text = datos[8];

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
