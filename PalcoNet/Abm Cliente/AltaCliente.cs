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

namespace PalcoNet.Abm_Cliente
{
    public partial class AltaCliente : Form
    {
        int usuario;

        public AltaCliente()
        {
            /*
            InitializeComponent();
            usuario = usuarioRecibido;
             * */
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

<<<<<<< HEAD

            debeSerTodoNumero(textBoxDOCNUMERO.Text, "Nro de documento");
            debeSerTodoNumero(textBoxNroCalle.Text, "Nro de calle");
=======
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

>>>>>>> parent of e9638d7... subo cambios

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxDOCNUMERO.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el Nro de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxTIPODOC.Text, @"[0-9]"))
            {
                MessageBox.Show("Sólo se permiten letras en el Tipo de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxTIPODOC.TextLength != 3)
            {
                MessageBox.Show("El cuit tiene que tener 3 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


<<<<<<< HEAD
=======
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
>>>>>>> parent of e9638d7... subo cambios
            String tipo = "cliente";
            if (consultasSQLCliente.existeCuit(textBoxCuit.Text, tipo))
            {
                MessageBox.Show("Ya se encuentra registrado el numero de CUIT", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            String nombre = textBoxNombre.Text;
            String apellido = textBoxApellido.Text;
            String tipo_documento = textBoxTIPODOC.Text;
            String numero_documento = textBoxDOCNUMERO.Text;
            String cuit = armarCuit(textBoxCuit.Text);
            String nro_tarjeta = textBoxTarjeta.Text;
            String ciudad = textBoxCiudad.Text;
            String mail = textBoxMail.Text;
            String telefono = textBoxTelefono.Text;
            int puntaje = 0;
            int estado = 1;
            DateTime fecha_nacimiento = Convert.ToDateTime(textBoxFechaNacimiento);
            int nroCalle = Convert.ToInt32(textBoxNroCalle.Text);
            String calle = textBoxCalle.Text;
            int codPostal = Convert.ToInt32(textBoxCodigoPostal.Text);
            String dto = textBoxDto.Text;
            int piso = Convert.ToInt32(textBoxPiso.Text);
            String localidad = textBoxLocalidad.Text;
            DateTime fecha_creacion = DateTime.Today;

            bool creacionAbortada = false;

            int usuarioNuevo = ConsultasSQL.crearUser(nombre, apellido, creacionAbortada, "");
            if (creacionAbortada == false)
            {
                consultasSQLCliente.AgregarCliente(nombre, apellido, tipo_documento, numero_documento, usuario, mail, nro_tarjeta, puntaje, estado, cuit, telefono, fecha_nacimiento, fecha_creacion);
                consultasSQLCliente.AgregarDomicilio(calle, nroCalle, piso, dto, localidad, codPostal, null, null, tipo_documento, numero_documento);
            }
            else {
                MessageBox.Show("Error al crear el nuevo usuario al consultar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            this.limpiarCuadrosDeTexto();

        }

        private void limpiarCuadrosDeTexto()
        {
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxTIPODOC.Text = "";
            textBoxDOCNUMERO.Text = "";
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

        public String armarCuit(String cuitSinArmar)
        {
            int n = textBoxDOCNUMERO.TextLength;
            String primeraParte = cuitSinArmar.Substring(0, 2);
<<<<<<< HEAD
            String SegundaParte = cuitSinArmar.Substring(2, n);
            String TerceraParte = cuitSinArmar.Substring(2+n, 2);
            
=======
            String SegundaParte = cuitSinArmar.Substring(2, n-2);
            String TerceraParte = cuitSinArmar.Substring(9, n);
>>>>>>> parent of e9638d7... subo cambios

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

<<<<<<< HEAD
=======
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

>>>>>>> parent of d713694... Importante avance

    }
}
