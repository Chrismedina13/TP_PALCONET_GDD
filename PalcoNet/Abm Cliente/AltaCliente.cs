﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Support;
using PalcoNet.Login_y_seguridad;
using PalcoNet.Registro_de_Usuario;

namespace PalcoNet.Abm_Cliente
{
    public partial class AltaCliente : Form
    {
    //    int usuario;
        RegistroUser registro;
        bool esRegistro, esCliente;
        ABMCliente ant;
        public AltaCliente(RegistroUser reg, bool algo, ABMCliente anterior, bool esABMCliente)
        {
            esCliente = esABMCliente;
            if (esABMCliente)
            {
                ant = anterior;
            }
            esRegistro = algo;
            if (esRegistro) {
                registro = reg;
            }
            
            
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

        private bool camposInvalidos() {
            String error = "";
            
            if (textBoxNombre.Text.Trim() == "" | textBoxApellido.Text.Trim() == "" | textBoxCuit.Text.Trim() == "" | textBoxTelefono.Text.Trim() == "" | textBoxMail.Text.Trim() == ""
                | textBoxTIPODOC.Text.Trim() == "" | textBoxDOCNUMERO.Text.Trim() == "" | textBoxTarjeta.Text.Trim() == ""
                | textBoxCodigoPostal.Text.Trim() == "" | textBoxNroCalle.Text.Trim() == "" | textBoxCalle.Text.Trim() == "")
            {
                error += "Faltan completar campos\n";
                if (textBoxNombre.Text.Trim() == "") {
                    error += "Faltan completar el nombre\n";
                }
                if (textBoxApellido.Text.Trim() == "")
                {
                    error += "Faltan completar el apellido\n";
                }
                if (textBoxCuit.Text.Trim() == "")
                {
                    error += "Faltan completar el CUIT\n";
                }
                if (textBoxTIPODOC.Text.Trim() == "")
                {
                    error += "Faltan completar el tipo de documento\n";
                }
                if (textBoxDOCNUMERO.Text.Trim() == "")
                {
                    error += "Faltan completar el número de documento\n";
                }
                if (textBoxTelefono.Text.Trim() == "")
                {
                    error += "Faltan completar el telefono\n";
                }
                if (textBoxMail.Text.Trim() == "")
                {
                    error += "Faltan completar el mail\n";
                }
                if (textBoxTarjeta.Text.Trim() == "")
                {
                    error += "Faltan completar el número de tarjeta\n";
                }
                if (textBoxCodigoPostal.Text.Trim() == "")
                {
                    error += "Faltan completar el código postal\n";
                }
                if (textBoxNroCalle.Text.Trim() == "")
                {
                    error += "Faltan completar el número de calle\n";
                }
                if (textBoxCalle.Text.Trim() == "")
                {
                    error += "Faltan completar la calle del cliente\n";
                }

         //       MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return true;

            }
            if (!AyudaExtra.CUILYContraseniaParecenRespetarTamanios(textBoxDOCNUMERO.Text.Trim(), textBoxCuit.Text.Trim()))
            {
                error = "El tamaño del campo CUIL es menor que el numero de documento\n";
         //       MessageBox.Show("El tamaño del campo CUIL es menor que el numero de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         //       return true;
            }

            if (!AyudaExtra.fechaMenorQueActual(dateFecha.Value.Date))
            {
                error += "La fecha ingresada es mayor o igual que la actual\n";
       //         MessageBox.Show("La fecha ingresada es mayor o igual que la actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return true;
            }
            if (!AyudaExtra.fechaEsMayorA18Anios(dateFecha.Value.Date)) {
                error += "La fecha ingresada no cumple los requisitos de que el usuario debe ser mayor a 18 años\n";
      //          MessageBox.Show("La fecha ingresada no cumple los requisitos de que el usuario debe ser mayor a 18 años", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
     //           return true;
            }
            if (!AyudaExtra.CUILYNroDocSeCorresponden(textBoxDOCNUMERO.Text.Trim(), textBoxCuit.Text.Trim()))
            {
                error += "El CUIL no corresponde al documento ingresado\n";
    //            MessageBox.Show("El CUIL no corresponde al documento ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
     //           return true;
            }

            if (!AyudaExtra.esStringNumerico(textBoxContrasenia.Text)) {
                error += "La contraseña debe ser un número\n";
         //       MessageBox.Show("La contraseña debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         //       return true;
            }

            if (!AyudaExtra.esStringNumerico(textBoxNroCalle.Text.Trim()))
            {
                error += "El numero de calle debe ser numerico\n";
        //        MessageBox.Show("El numero de calle debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
       //         return true;
            }
            if (!AyudaExtra.esStringNumerico(textBoxTarjeta.Text.Trim()))
            {
                error += "El numero de tarjeta debe ser numerico\n";
       //         MessageBox.Show("El numero de tarjeta debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
       //         return true;
            }
            if (!AyudaExtra.esStringNumerico(textBoxTelefono.Text.Trim()))
            {
                error += "El numero de telefono debe ser numerico\n";
        //        MessageBox.Show("El numero de telefono debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
       //         return true;
            }

            if (!AyudaExtra.esUnMail(textBoxMail.Text.Trim()))
            {
                error += "El campo mail está mal ingresado\n";
    //            MessageBox.Show("El campo mail está mal ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            return true;
            }

            if (!AyudaExtra.esStringNumerico(textBoxDOCNUMERO.Text.Trim()))
            {
                error += "El numero de documento debe ser numerico\n";
       //         MessageBox.Show("", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //          return true;
            }

            if (!AyudaExtra.esStringLetra(textBoxTIPODOC.Text.Trim()))
            {
                error += "Sólo se permiten letras en el Tipo de documento\n";
         //       MessageBox.Show("", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          //      return true;
            }
            if (!AyudaExtra.esStringLetra(textBoxApellido.Text.Trim()) || !AyudaExtra.esStringLetra(textBoxNombre.Text.Trim()))
            {
                error += "Sólo se permiten letras en el campo nombre y apellido\n";
       //         MessageBox.Show("", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //          return true;
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
                error += "El TIPO DE DOCUMENTO tiene que tener 3 digitos\n";
       //         MessageBox.Show("", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return true;
            }
            if (error == "") {
                return false;
            }
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return true;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (camposInvalidos()) {
                return;
            }

            // Porque no es campo obligatorio
            bool ingresoPisoYDPT = false;
            String error = "";
            if (textBoxPiso.Text.Trim() != "" && textBoxDto.Text.Trim() != "")
            {
                if (!AyudaExtra.esStringNumerico(textBoxPiso.Text.Trim()))
                {
                    error += "Debe ingresar el numero de piso\n";
     //               MessageBox.Show("Debe ingresar el numero de piso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
     //               return;
                }
                else {
                    ingresoPisoYDPT = true;
                }
    //            debeSerTodoNumero(textBoxPiso.Text, "Piso");
            }
            
    //        debeSerTodoNumero(textBoxTelefono.Text, "Telefono");

            String tipo = "Cliente";
            DBConsulta.conexionAbrir();
            if (consultasSQLCliente.existeCuit(textBoxCuit.Text, tipo))
            {
                error += "Ya se encuentra registrado el numero de CUIT\n";
  //              MessageBox.Show("Ya se encuentra registrado el numero de CUIT", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
     //           return;
            }
            DBConsulta.conexionCerrar();

            if (error != "") {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
       /*     if (!cuitYNroDocumentoSonCorrectos(textBoxCuit.Text, textBoxDOCNUMERO.Text)) {
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
            long numero_documento = Convert.ToInt64(textBoxDOCNUMERO.Text);
            String telefono = textBoxTelefono.Text.Trim();
            int nroCalle = Convert.ToInt32(textBoxNroCalle.Text);
            String nro_tarjeta = textBoxTarjeta.Text.Trim();
            int piso;
            if (ingresoPisoYDPT)
            {
                piso = Convert.ToInt32(textBoxPiso.Text);
            }
            else {
                piso = 0;
            }
            String localidad = textBoxLocalidad.Text;
            bool creacionAbortada = false;
            DBConsulta.conexionAbrir();
            if(DBConsulta.repeticion_de_campo_tipoDOC_numero_o_CUIL(cuit, textBoxDOCNUMERO.Text.Trim().ToString(), tipo_documento)) {
                MessageBox.Show("Hay repetición en CUIL, o en Tipo de documento y su número, correspondiente a la DB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DBConsulta.conexionCerrar();
                return;
            }
            DBConsulta.conexionCerrar();
            DBConsulta.conexionAbrir();
            if (mailRepetido(mail))
            {
                MessageBox.Show("El Email ingresado ya existe en la DB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DBConsulta.conexionCerrar();
                return;
            }
            
            
            
            bool errors = false;
            bool autocontra = false;
            String contraAutogenerada = autogenerarContrasenia.contraGeneradaAString();
            
            if (textBoxContrasenia.Text.Trim() == "")
            {
                autocontra = true;
                int usuarioNuevo = ConsultasSQL.crearUser(nombre.Replace(" ", "_") + "_" + apellido.Replace(" ", "_"), creacionAbortada, contraAutogenerada, "Cliente");
            }
            else {
                if (AyudaExtra.esStringNumerico(textBoxContrasenia.Text.Trim()))
                {
                    int usuarioNuevo = ConsultasSQL.crearUser(nombre.Replace(" ", "_") + "_" + apellido.Replace(" ", "_"), creacionAbortada, textBoxContrasenia.Text.Trim(), "Cliente");
                }
                else {
                    MessageBox.Show("La contraseña debe ser numérica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errors = true;
                }
            }
            DBConsulta.conexionCerrar();

            if (!errors)
            {
                
                if (creacionAbortada == false)
                {
                    consultasSQLCliente.AgregarCliente(nombre, apellido, tipo_documento, numero_documento, mail, nro_tarjeta, cuit, telefono, fecha_nacimiento, DateTime.Today);
                    DBConsulta.conexionAbrir();
                    consultasSQLCliente.AgregarDomicilio(calle, nroCalle, piso, dto, localidad, codPostal, "Cliente");
                    string cmd = "Select TOP 1 usuario_nombre from SQLEADOS.Usuario order by usuario_Id DESC";
                    DataTable dt = DBConsulta.obtenerConsultaEspecifica(cmd);
                    String comentario = "Usuario creado: " + dt.Rows[0][0].ToString();
                    if (autocontra) { 
                        comentario += "\n\nContraseña autogenerada: "+contraAutogenerada;
                    }
                    MessageBox.Show(comentario);
                    DBConsulta.conexionCerrar();
                    if (esRegistro)
                    {
                        registro.terminar();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Error al crear el nuevo usuario al consultar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DBConsulta.conexionCerrar();
                    return;
                }
            }

            this.limpiarCuadrosDeTexto();
        }

        private bool contieneNumeroTIPODocumento(String caracteres) {
            return caracteres.Contains("1") || caracteres.Contains("2") || caracteres.Contains("3") ||
                caracteres.Contains("4") || caracteres.Contains("5") || caracteres.Contains("6") ||
                caracteres.Contains("7") || caracteres.Contains("8") || caracteres.Contains("9");
        }

        private static bool cuitYNroDocumentoSonCorrectos(String cuit, String nroDocumento) {
            return cuit.Contains(nroDocumento);
        }

        private bool mailRepetido(String mail)
        {
            String comando = "SELECT empresa_email FROM SQLEADOS.Empresa WHERE empresa_email LIKE '" + mail + "' UNION SELECT cliente_email FROM SQLEADOS.Cliente  WHERE cliente_email LIKE '" + mail + "'";
            DBConsulta.conexionAbrir();
            DataTable dt = DBConsulta.obtenerConsultaEspecifica(comando);
            DBConsulta.conexionCerrar();
            return dt.Rows.Count > 0;
        }

        private void limpiarCuadrosDeTexto()
        {
            textBoxApellido.Text = "";
            textBoxCalle.Text = "";
            textBoxCodigoPostal.Text = "";
            textBoxContrasenia.Text = "";
            textBoxCuit.Text = "";
            textBoxDOCNUMERO.Text = "";
            textBoxDto.Text = "";
            textBoxLocalidad.Text = "";
            textBoxMail.Text = "";
            textBoxNombre.Text = "";
            textBoxNroCalle.Text = "";
            textBoxPiso.Text = "";
            textBoxTarjeta.Text = "";
            textBoxTelefono.Text = "";
            textBoxTIPODOC.Text = "";
        }

        public String armarCuit(String cuitSinArmar)
        {
            int n = textBoxDOCNUMERO.TextLength;
            int m = cuitSinArmar.Length;
            String primeraParte = cuitSinArmar.Substring(0, 2);
            String SegundaParte = cuitSinArmar.Substring(2, n);
            String TerceraParte = cuitSinArmar.Substring(2+n, m-primeraParte.Length-SegundaParte.Length);
            
            String cuitArmado = primeraParte + "-" + SegundaParte + "-" + TerceraParte;
            return cuitArmado;
        }

        #region funciones que no sirven pero si se borran se pierde la vista
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
            dateFecha.Value = ArchivoDeConfiguracion.fechaReferencia;
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void volver_boton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //BOTON VOLVER
        private void button1_Click(object sender, EventArgs e)
        {
            if (esCliente) {
                ant.Show();
            }
            if (esRegistro) {
       //         registro.Show();
            }
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
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            limpiarCuadrosDeTexto();
            dateFecha.Value = ArchivoDeConfiguracion.fechaReferencia;
        }
    }
}