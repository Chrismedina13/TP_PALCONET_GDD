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


            debeSerTodoNumero(textBoxNroCalle.Text, "Nro de calle");
            debeSerTodoNumero(textBoxDOCNUMERO.Text, "Nro de documento");



            if (contieneNumeroTIPODocumento(textBoxTIPODOC.Text))
            {
                MessageBox.Show("Sólo se permiten letras en el Tipo de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (textBoxTIPODOC.TextLength != 3)
            {
                MessageBox.Show("El cuit tiene que tener 3 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Porque no es campo obligatorio
            if(textBoxPiso.Text != "") {
                debeSerTodoNumero(textBoxPiso.Text, "Piso");
            }
            
            debeSerTodoNumero(textBoxTelefono.Text, "Telefono");

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
            if (!cuitYNroDocumentoSonCorrectos(textBoxCuit.Text, textBoxDOCNUMERO.Text)) {
                MessageBox.Show("El CUIT y el numero de documento no coindiden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            String nombre = textBoxNombre.Text;
            String apellido = textBoxApellido.Text;
            String tipo_documento = textBoxTIPODOC.Text;
            String numero_documento = textBoxDOCNUMERO.Text;
            String cuit = armarCuit(textBoxCuit.Text);
            String nro_tarjeta = textBoxTarjeta.Text;
            String mail = textBoxMail.Text;
            String telefono = textBoxTelefono.Text;
            int puntaje = 0;
            int estado = 1;
            String fecha_nacimiento = dateFecha.ToString();
            int nroCalle = Convert.ToInt32(textBoxNroCalle.Text);
            String calle = textBoxCalle.Text;
            String codPostal = textBoxCodigoPostal.Text;
            String dto = textBoxDto.Text;
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

            int usuarioNuevo = ConsultasSQL.crearUser(nombre, apellido, creacionAbortada, "", "Cliente","3");
            if (creacionAbortada == false)
            {
                consultasSQLCliente.AgregarCliente(nombre, apellido, tipo_documento, numero_documento, usuarioNuevo, mail, nro_tarjeta, puntaje, estado, cuit, telefono, fecha_nacimiento, fecha_creacion);
                consultasSQLCliente.AgregarDomicilio(calle, nroCalle, piso, dto, localidad, codPostal, null, null, tipo_documento, numero_documento);
            }
            else {
                MessageBox.Show("Error al crear el nuevo usuario al consultar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            this.limpiarCuadrosDeTexto();
            return;

        }
    }
}
