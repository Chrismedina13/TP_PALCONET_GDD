using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data;
using PalcoNet.Support;

namespace PalcoNet.Abm_Cliente
{
    
    public partial class ModificarClienteSeleccionado : volver
    {
        int usuarioSeleccionado;

        //ATRIBUTOS DE SI UN CAMPO SE MODIFICÓ
        bool nombre = false,
            apellido = false, telefono = false, tarjeta = false
            , piso = false, calle = false, nrocalle = false, localidad = false
            , estado = false, codigopostal = false, departamento = false;
        ModificarCliente mcli;

        public ModificarClienteSeleccionado(int user, ModificarCliente md)
        {
            mcli = md;
            usuarioSeleccionado = user;
            nombre = false;
            apellido = false; telefono = false; tarjeta = false;
            piso = false; calle = false; nrocalle = false; localidad = false;
            estado = false; codigopostal = false; departamento = false;
            InitializeComponent();
        }

        private void cargarDatos()
        {
            DBConsulta.conexionAbrir();
            DataTable dt = DBConsulta.obtenerTodosLosDatosRelevantesDe1Cliente(usuarioSeleccionado);
            DBConsulta.conexionCerrar();
            labelnombre.Text = dt.Rows[0][0].ToString();
            labeApellido.Text = dt.Rows[0][1].ToString();
            labeTarjeta.Text = dt.Rows[0][2].ToString();
            labeTelefono.Text = dt.Rows[0][3].ToString();
            labeCalle.Text = dt.Rows[0][4].ToString();
            labenrocalle.Text = dt.Rows[0][5].ToString();
            labelpiso.Text = dt.Rows[0][6].ToString();
            labeldto.Text = dt.Rows[0]["DOM_DEPARTAMENTO"].ToString();
            labellocalidad.Text = dt.Rows[0][8].ToString();
            labelcodepostal.Text = dt.Rows[0][9].ToString();

            if (dt.Rows[0][10].ToString().Contains("True"))
            {
                labelhabilitado.Text = "Estado: Habilitado";
                checkBox1.Checked = true;
            }
            else
            {
                labelhabilitado.Text = "Estado: Inhabilitado";
                checkBox1.Checked = false;
            }
        }

        private void ModificarClienteSeleccionado_Load(object sender, EventArgs e)
        {
            
        }

        private void completarDatosDeVista(DataTable dt) 
        {
           
        }

        private void ObtenerDatos_load() {
        }

        private void ModificarClienteSeleccionado_Load_1(object sender, EventArgs e)
        {
            cargarDatos();
        }

        // BOTON MODIFICAR LOS DATOS DEL CLIENTE
        private void button1_Click(object sender, EventArgs e)
        {
            DBConsulta.conexionAbrir();
            camposConAlgunaModificacion();
            bool clienteTieneSet = false, domicilioTieneSet = false;
            String queryCliente = "UPDATE SQLEADOS.Cliente ";
            String queryDomicilio = "UPDATE SQLEADOS.Domicilio ";
            String queryUser = "";
            String finalQueryDomicilio = " where domicilio_cliente_numero_documento = (SELECT TOP 1 cliente_numero_documento from SQLEADOS.Cliente where cliente_usuario =" + usuarioSeleccionado + ") AND domicilio_cliente_tipo_documento = (SELECT TOP 1 cliente_tipo_documento from SQLEADOS.Cliente where cliente_usuario =" + usuarioSeleccionado + ")";
            String finalQueryCliente = " where cliente_usuario = " + usuarioSeleccionado;

            if (apellido == true)
            {
                if (!AyudaExtra.esStringLetra(textBoxApellido.Text.Trim()))
                {
                    MessageBox.Show("El campo Apellido solo admite letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                queryCliente += " SET cliente_apellido = '" + textBoxApellido.Text.Trim() + "'";
                clienteTieneSet = true;
            }

            if (nombre == true)
            {
                if (!AyudaExtra.esStringLetra(textBoxNombre.Text.Trim()))
                {
                    MessageBox.Show("El campo Nombre solo admite letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (clienteTieneSet)
                {
                    queryCliente += " , cliente_nombre = '" + textBoxNombre.Text.Trim() + "'";
                }
                else
                {
                    queryCliente += " SET cliente_nombre = '" + textBoxNombre.Text.Trim() + "'";
                    clienteTieneSet = true;
                }
            }

            if (tarjeta == true)
            {
                if (!AyudaExtra.esStringNumerico(textBoxTarjeta.Text.Trim()))
                {
                    MessageBox.Show("El campo tarjeta solo admite numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (clienteTieneSet)
                {
                    queryCliente += " , cliente_datos_tarjeta = " + textBoxTarjeta.Text.Trim();
                }
                else
                {
                    queryCliente += " SET cliente_datos_tarjeta = " + textBoxTarjeta.Text.Trim();
                    clienteTieneSet = true;
                }
            }

            if (telefono == true)
            {
                if (!AyudaExtra.esStringNumerico(textBoxTelefono.Text.Trim()))
                {
                    MessageBox.Show("El campo telefono solo admite numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (clienteTieneSet)
                {
                    queryCliente += " , cliente_telefono = " + textBoxTelefono.Text.Trim();
                }
                else
                {
                    queryCliente += " SET  cliente_telefono = " + textBoxTelefono.Text.Trim();
                    clienteTieneSet = true;
                }
            }

            if (calle == true)
            {
                queryDomicilio += " SET domicilio_calle = '" + textBoxCalle.Text.Trim() + "'";
                domicilioTieneSet = true;
            }

            if (nrocalle == true)
            {
                if (!AyudaExtra.esStringNumerico(textBoxNroCalle.Text.Trim()))
                {
                    MessageBox.Show("El campo número de calle solo admite números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (domicilioTieneSet)
                {
                    queryDomicilio += " , domicilio_numero = " + textBoxNroCalle.Text.Trim();
                }
                else
                {
                    queryDomicilio += " SET  domicilio_numero = " + textBoxNroCalle.Text.Trim();
                    domicilioTieneSet = true;
                }
            }

            if (piso == true)
            {
                if (!AyudaExtra.esStringNumerico(textBoxPiso.Text))
                {
                    MessageBox.Show("El campo piso solo admite números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (domicilioTieneSet)
                {
                    queryDomicilio += " , domicilio_piso = " + textBoxPiso.Text.Trim();
                }
                else
                {
                    queryDomicilio += " SET  domicilio_piso = " + textBoxPiso.Text.Trim();
                    domicilioTieneSet = true;
                }
            }

            if (departamento == true)
            {
                if (!AyudaExtra.esStringLetra(textBoxPiso.Text.Trim()))
                {
                    MessageBox.Show("El campo departamento solo admite letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (domicilioTieneSet)
                {
                    queryDomicilio += " , domicilio_dto = '" + textBoxDto.Text.Trim() + "'";
                }
                else
                {
                    queryDomicilio += " SET domicilio_dto = '" + textBoxDto.Text.Trim() + "'";
                    domicilioTieneSet = true;
                }
            }

            if (localidad == true)
            {
                if (domicilioTieneSet)
                {
                    queryDomicilio += " , domicilio_localidad = '" + textBoxLocalidad.Text.Trim() + "'";
                }
                else
                {
                    queryDomicilio += " SET domicilio_localidad = '" + textBoxLocalidad.Text.Trim() + "'";
                    domicilioTieneSet = true;
                }
            }

            if (codigopostal == true)
            {
                if (AyudaExtra.esStringNumerico(textBoxCodigoPostal.Text.Trim()))
                {
                    MessageBox.Show("El campo número de Código postal solo admite números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (domicilioTieneSet)
                {
                    queryDomicilio += " , domicilio_codigo_postal = '" + textBoxCodigoPostal.Text.Trim() + "'";
                }
                else
                {
                    queryDomicilio += " SET domicilio_codigo_postal = '" + textBoxCodigoPostal.Text.Trim() + "'";
                    domicilioTieneSet = true;
                }
            }
            if (checkBox1.Checked)
            {
                queryUser = "UPDATE SQLEADOS.Usuario SET usuario_estado = " + 1 + " where usuario_Id = " + usuarioSeleccionado;
            }
            else {
                queryUser = "UPDATE SQLEADOS.Usuario SET usuario_estado = " + 0 + " where usuario_Id = " + usuarioSeleccionado;
            }

            queryCliente += finalQueryCliente;
            queryDomicilio += finalQueryDomicilio;

            if (queryDomicilio.Contains("SET"))
            {
                DBConsulta.ModificarCliente(queryDomicilio);
                //       this.Close();
            }
            if (queryCliente.Contains("SET"))
            {
                DBConsulta.ModificarCliente(queryCliente);
                //         this.Close();
            }
            if (checkBox1.Checked)
            {
                DBConsulta.ModificarCliente(queryUser);
            }
            cargarDatos();
            DBConsulta.conexionCerrar();
        }

        private void reiniciarBooleanos()
        {
            nombre = false;
            apellido = false; telefono = false; tarjeta = false;
            piso = false; calle = false; nrocalle = false; localidad = false;
            estado = false; codigopostal = false; departamento = false;
        }

        private void camposConAlgunaModificacion()
        {
            reiniciarBooleanos();
            if (!AyudaExtra.esStringVacio(textBoxApellido.Text.Trim()))
            {
                apellido = true;
            }
            if (!AyudaExtra.esStringVacio(textBoxNombre.Text.Trim()))
            {
                nombre = true;
            }
            if (!AyudaExtra.esStringVacio(textBoxTelefono.Text.Trim()))
            {
                telefono = true;
            }
            if (!AyudaExtra.esStringVacio(textBoxTarjeta.Text.Trim()))
            {
                tarjeta = true;
            }
            if (!AyudaExtra.esStringVacio(textBoxCalle.Text.Trim()))
            {
                calle = true;
            }
            if (!AyudaExtra.esStringVacio(textBoxNroCalle.Text.Trim()))
            {
                nrocalle = true;
            }
            if (!AyudaExtra.esStringVacio(textBoxLocalidad.Text.Trim()))
            {
                localidad = true;
            }
            if (!AyudaExtra.esStringVacio(textBoxPiso.Text.Trim()))
            {
                piso = true;
            }
            if (!AyudaExtra.esStringVacio(textBoxDto.Text.Trim()))
            {
                departamento = true;
            }
            if (!AyudaExtra.esStringVacio(textBoxCodigoPostal.Text.Trim()))
            {
                codigopostal = true;
            }
        }

     
        

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void volver_boton_Click_1(object sender, EventArgs e)
        {
            mcli.BusquedadYLlenarGrilla();
            mcli.Show();
            this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxApellido.Text = labeApellido.Text;
            textBoxCalle.Text = textBoxCalle.Text;
            textBoxCodigoPostal.Text = labelcodepostal.Text;
            textBoxDto.Text = labeldto.Text;
            textBoxLocalidad.Text = labellocalidad.Text;
            textBoxNombre.Text = labelnombre.Text;
            textBoxNroCalle.Text = labenrocalle.Text;
            textBoxPiso.Text = labelpiso.Text;
            textBoxTarjeta.Text = labeTarjeta.Text;
            textBoxTelefono.Text = labeTelefono.Text;

            if (labelhabilitado.Text.Contains("in"))
            {
                checkBox1.Checked = false;
            }
            else {
                checkBox1.Checked = true;
            }
        }
    }
}
