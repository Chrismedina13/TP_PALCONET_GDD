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
using PalcoNet.Abm_Cliente;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class RegistroCliente : AltaCliente
    {
        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void RegistroCliente_Load(object sender, EventArgs e)
        {

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (textBoxNombre.Text.Trim() == " " | textBoxApellido.Text.Trim() == " " | textBoxCuit.Text.Trim() == " " | textBoxTelefono.Text.Trim() == "" | textBoxMail.Text.Trim() == " "
                | textBoxTIPODOC.Text.Trim() == " " | textBoxDOCNUMERO.Text.Trim()==" " | textBoxTarjeta.Text.Trim()==" "
                | textBoxCodigoPostal.Text.Trim() == " " | textBoxNroCalle.Text.Trim() == " " | textBoxNroCalle.Text.Trim() == " ")
            {

                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!AyudaExtra.esStringNumerico(textBoxNroCalle.Text.Trim())) {
                MessageBox.Show("El numero de calle debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AyudaExtra.esStringNumerico(textBoxDOCNUMERO.Text.Trim());



       /*     if (contieneNumeroTIPODocumento(textBoxTIPODOC.Text))
            {
                MessageBox.Show("Sólo se permiten letras en el Tipo de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
*/

            if (textBoxTIPODOC.TextLength != 3)
            {
                MessageBox.Show("El cuit tiene que tener 3 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Porque no es campo obligatorio
            if(textBoxPiso.Text != "") {
     //           debeSerTodoNumero(textBoxPiso.Text, "Piso");
            }
            
        //    debeSerTodoNumero(textBoxTelefono.Text, "Telefono");

            if (textBoxDOCNUMERO.TextLength != 7)
            {
                MessageBox.Show("El documento debe tener 7 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBoxCuit.TextLength != 11)
            {
                MessageBox.Show("El cuit tiene que tener 11 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String tipo = "cliente";
            if (consultasSQLCliente.existeCuit(textBoxCuit.Text, tipo))
            {

                MessageBox.Show("Ya se encuentra registrado el numero de CUIT", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
      /*      if (!cuitYNroDocumentoSonCorrectos(textBoxCuit.Text, textBoxDOCNUMERO.Text)) {
                MessageBox.Show("El CUIT y el numero de documento no coindiden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            */

            String nombre = textBoxNombre.Text.Trim();
            String apellido = textBoxApellido.Text.Trim();
            String tipo_documento = textBoxTIPODOC.Text.Trim();
            String cuit = armarCuit(textBoxCuit.Text);

            String mail = textBoxMail.Text.Trim();
            String fecha_nacimiento = dateFecha.Value.ToString("yyyy-MM-dd");

            String calle = textBoxCalle.Text.Trim();
            String codPostal = textBoxCodigoPostal.Text.Trim();
            String dto = textBoxDto.Text;
            int numero_documento = Convert.ToInt32(textBoxDOCNUMERO.Text);
            String telefono = textBoxTelefono.Text.Trim();
            int nroCalle = Convert.ToInt32(textBoxNroCalle.Text);
            String nro_tarjeta = textBoxTarjeta.Text.Trim();
            int piso;
            if (textBoxPiso.Text != "")
            {
                piso = Convert.ToInt32(textBoxPiso.Text);
            }
            else {
                piso = 0;
            }
           
            String localidad = textBoxLocalidad.Text;
            DateTime fecha_creacion = DateTime.Today;

            bool creacionAbortada = false;

            int usuarioNuevo = ConsultasSQL.crearUser(nombre.Replace(" ", "_") + "_" + apellido.Replace(" ", "_"), creacionAbortada, autogenerarContrasenia.contraGeneradaAString(), "Cliente");
            if (creacionAbortada == false)
            {
                consultasSQLCliente.AgregarCliente(nombre, apellido, tipo_documento, numero_documento, mail, nro_tarjeta, cuit, telefono, fecha_nacimiento, DateTime.Today);
                consultasSQLCliente.AgregarDomicilio(calle, nroCalle, piso, dto, localidad, codPostal, "Cliente");
            }
            else {
                MessageBox.Show("Error al crear el nuevo usuario al consultar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


         //   this.limpiarCuadrosDeTexto();
            return;

        }
    }
}
