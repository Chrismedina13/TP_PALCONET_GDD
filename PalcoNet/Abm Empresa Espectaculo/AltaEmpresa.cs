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
    public partial class AltaEmpresa : Form
    {
        int usuario;
        
        public AltaEmpresa(int usuarioRecibido)
        {
            InitializeComponent();
            usuario = usuarioRecibido;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            

            if (textBoxRazonSocial.Text.Trim() == " " | textBoxCuit.Text.Trim() == " " | textBoxTelefono.Text.Trim() == "" | textBoxMail.Text.Trim() == " "
                | textBoxCodigoPostal.Text.Trim() == " " | textBoxNroCalle.Text.Trim() == " " | textBoxNroCalle.Text.Trim() == " ")
            {

                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxCuit.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el CUIT", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxNroCalle.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el Nro de calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxPiso.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el Nro de calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxTelefono.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el Telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
              if (textBoxCuit.TextLength != 11)
            {
                MessageBox.Show("El cuit tiene que tener 11 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

              if (ConsultasSQL.existeCuit(textBoxCuit.Text,"empresa"))
            {

                MessageBox.Show("Ya se encuentra registrado el numero de CUIT", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            String razonSocial = textBoxRazonSocial.Text;
            String cuit = armarCuit(textBoxCuit.Text);
            String ciudad = textBoxCiudad.Text;
            String mail = textBoxMail.Text;
            String telefono = textBoxTelefono.Text;
            int nroCalle = Convert.ToInt32(textBoxNroCalle.Text);
            String calle = textBoxCalle.Text;
            int codPostal = Convert.ToInt32(textBoxCodigoPostal.Text);
            String dto = textBoxDto.Text;
            int piso = Convert.ToInt32(textBoxPiso.Text);
            String localidad = textBoxLocalidad.Text;
            DateTime hoy = DateTime.Today;
            ConsultasSQLEmpresa.AgregarEmpresa(razonSocial, cuit, ciudad, mail, telefono, usuario, hoy);
            ConsultasSQLEmpresa.AgregarDomicilio(calle, nroCalle, piso, dto, localidad, codPostal, razonSocial, cuit, null, null);
            this.limpiarCuadrosDeTexto();

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
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

        }


        public String armarCuit(String cuitSinArmar) {

            String primeraParte = cuitSinArmar.Substring(0, 2);
            String SegundaParte = cuitSinArmar.Substring(2, 8);
            String TerceraParte = cuitSinArmar.Substring(9, 2);
            String cuitArmado = primeraParte + "-" + SegundaParte + "-" + TerceraParte;

            return cuitArmado;
        
        }

        private void AltaEmpresa_Load(object sender, EventArgs e)
        {

        }
      
    }
}
