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
            if (datos[2] == "1")
            {
                checkBox1.Checked = true;
            }
            else {
                checkBox1.Checked = false;
            }
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


            if (textBoxRazonSocial.Text.Trim() == "" | textBoxCuit.Text.Trim() == "" | textBoxTelefono.Text.Trim() == "" | textBoxMail.Text.Trim() == ""
                | textBoxCodigoPostal.Text.Trim() == "" | textBoxNroCalle.Text.Trim() == "" | textBoxNroCalle.Text.Trim() == "")
            {

                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxNroCalle.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el Nro de calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxPiso.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el Piso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxTelefono.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el Telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String razonSocial = textBoxRazonSocial.Text;
            String cuit = textBoxCuit.Text;
            String ciudad = textBoxCiudad.Text;
            String mail = textBoxMail.Text;
            String telefono = textBoxTelefono.Text;
            int nroCalle = Convert.ToInt32(textBoxNroCalle.Text);
            String calle = textBoxCalle.Text;
            String codPostal = textBoxCodigoPostal.Text;
            String dto = textBoxDto.Text;
            int piso = Convert.ToInt32(textBoxPiso.Text);
            String localidad = textBoxLocalidad.Text;
            int estado;
            if (checkBox1.Checked)
            {
                estado = 1;
            }
            else {
                estado = 0;
            }
            ConsultasSQLEmpresa.modificarEmpresa(razonSocial, cuit, ciudad, mail, telefono,estado);
            ConsultasSQLEmpresa.modificarEmpresaDomicilio(calle, nroCalle, piso, dto, localidad, codPostal, cuit, razonSocial);
            this.limpiarCuadrosDeTexto();
            this.Close();

        }

        private void limpiarCuadrosDeTexto()
        {
            textBoxRazonSocial.Text = "";
            textBoxCiudad.Text = "";
            textBoxMail.Text = "";
            textBoxTelefono.Text = "";
            textBoxNroCalle.Text = "";
            textBoxCalle.Text = "";
            textBoxCodigoPostal.Text = "";
            textBoxDto.Text = "";
            textBoxPiso.Text = "";
            textBoxLocalidad.Text = "";
            textBoxCuit.Text = "";
//            txtHabilitado.Text = "";
        }

        private void ModificarEmpresaElegida_Load(object sender, EventArgs e)
        {

        }
    }
}
