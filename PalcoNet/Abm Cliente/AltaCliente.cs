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
    public partial class AltaCliente : Form
    {
    //    int usuario;
        
        public AltaCliente()
        {
            
            InitializeComponent();
     //       usuario = usuarioRecibido;   
        }

        private void debeSerTodoNumero(String cadena, String tipo) {
            int parsedValue;
            if (!int.TryParse(cadena, out parsedValue))
            {
                MessageBox.Show("Sólo se permiten numeros en el campo: "+ tipo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            return;
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

            if (!AyudaExtra.esStringNumerico(textBoxNroCalle.Text.Trim()))
            {
                MessageBox.Show("El numero de calle debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!AyudaExtra.esUnMail(textBoxMail.Text.Trim()))
            {
                MessageBox.Show("El campo mail está mal ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            if (! AyudaExtra.esStringNumerico(textBoxDOCNUMERO.Text.Trim()))
            {
                MessageBox.Show("El numero de calle debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (AyudaExtra.esStringNumerico(textBoxTIPODOC.Text.Trim())) {
                MessageBox.Show("Sólo se permiten letras en el Tipo de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
      
            /*
            if (contieneNumeroTIPODocumento(textBoxTIPODOC.Text))
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
            bool ingresoPisoYDPT = false;
            if (textBoxPiso.Text.Trim() != "" && textBoxDto.Text.Trim() != "")
            {
                if (!AyudaExtra.esStringNumerico(textBoxPiso.Text.Trim()))
                {
                    MessageBox.Show("Debe ingresar el numero de piso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else {
                    ingresoPisoYDPT = true;
                }
    //            debeSerTodoNumero(textBoxPiso.Text, "Piso");
            }
            
    //        debeSerTodoNumero(textBoxTelefono.Text, "Telefono");

            String tipo = "cliente";
            if (consultasSQLCliente.existeCuit(textBoxCuit.Text, tipo))
            {
                MessageBox.Show("Ya se encuentra registrado el numero de CUIT", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
       /*     if (!cuitYNroDocumentoSonCorrectos(textBoxCuit.Text, textBoxDOCNUMERO.Text)) {
                MessageBox.Show("El CUIT y el numero de documento no coindiden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            */

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
            if (ingresoPisoYDPT)
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
                consultasSQLCliente.AgregarCliente(nombre, apellido, tipo_documento, numero_documento, usuarioNuevo, mail, nro_tarjeta, puntaje, estado, cuit, telefono, fecha_nacimiento, fecha_creacion);
                consultasSQLCliente.AgregarDomicilio(calle, nroCalle, piso, dto, localidad, codPostal, null, null, tipo_documento, numero_documento);
            }
            else {
                MessageBox.Show("Error al crear el nuevo usuario al consultar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


       //     this.limpiarCuadrosDeTexto();
            return;

        }

        private bool contieneNumeroTIPODocumento(String caracteres) {
            return caracteres.Contains("1") || caracteres.Contains("2") || caracteres.Contains("3") ||
                caracteres.Contains("4") || caracteres.Contains("5") || caracteres.Contains("6") ||
                caracteres.Contains("7") || caracteres.Contains("8") || caracteres.Contains("9");
        }

        private static bool cuitYNroDocumentoSonCorrectos(String cuit, String nroDocumento) {
            return cuit.Contains(nroDocumento);
        }

        private void limpiarCuadrosDeTexto()
        {
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxTIPODOC.Text = "";
            textBoxDOCNUMERO.Text = "";
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

        public String armarCuit(String cuitSinArmar)
        {
            int n = textBoxDOCNUMERO.TextLength;
            String primeraParte = cuitSinArmar.Substring(0, 2);
            String SegundaParte = cuitSinArmar.Substring(2, n);
            String TerceraParte = cuitSinArmar.Substring(2+n, 2);
            

            String cuitArmado = primeraParte + "-" + SegundaParte + "-" + TerceraParte;

            return cuitArmado;

        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFechaNacimiento_TextChanged(object sender, EventArgs e)
        {

        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void volver_boton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxTIPODOC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxMail_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
