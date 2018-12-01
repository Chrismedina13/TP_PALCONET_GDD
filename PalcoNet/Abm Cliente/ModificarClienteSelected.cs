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
    public partial class ModificarClienteSelected : Form
    {
        int usuarioSeleccionado;

        //ATRIBUTOS DE SI UN CAMPO SE MODIFICÓ
        bool nombre = false,
            apellido = false, telefono = false, tarjeta = false
            , piso = false, calle = false, nrocalle = false, localidad = false
            , estado = false, codigopostal = false, departamento = false;

        public ModificarClienteSelected(int user)
        {
            usuarioSeleccionado = user;
            nombre = false;
            apellido = false; telefono = false; tarjeta = false;
            piso = false; calle = false; nrocalle = false; localidad = false;
            estado = false; codigopostal = false; departamento = false;
            InitializeComponent();
        }

        private void ModificarClienteSelected_Load(object sender, EventArgs e)
        {
            ObtenerDatos_load();
        }

        private void cargarDatos() 
        {
            DataTable dt = DBConsulta.obtenerTodosLosDatosRelevantesDe1Cliente(usuarioSeleccionado);

            labelNombre.Text = dt.Rows[0][0].ToString();
            labelApellido.Text = dt.Rows[0][1].ToString();
            labelTarjeta.Text = dt.Rows[0][2].ToString();
            labeltelefono.Text = dt.Rows[0][3].ToString();
            labelcalle.Text = dt.Rows[0][4].ToString();
            labelnrocalle.Text = dt.Rows[0][5].ToString();
            labelpiso.Text = dt.Rows[0][6].ToString();
            labelDepartamente.Text = dt.Rows[0][7].ToString();
            labelLocalidad.Text = dt.Rows[0][8].ToString();
            labelCodepostal.Text = dt.Rows[0][9].ToString();

            if (dt.Rows[0][10].ToString().Contains("True"))
            {
                labelEstado.Text = "Estado: 1";
            }
            else
            {
                labelEstado.Text = "Estado: 0";
            }
        }

        private void ObtenerDatos_load()
        {
            cargarDatos();
        }

        //MODIFICA CAMPOS
        private void botonmodificar_Click(object sender, EventArgs e)
        {
            camposConAlgunaModificacion();
            bool clienteTieneSet = false, domicilioTieneSet = false;
            String queryCliente = "UPDATE SQLEADOS.Cliente ";
            String queryDomicilio = "UPDATE SQLEADOS.Domicilio ";
            String queryUser ="";
            String finalQueryDomicilio = " where domicilio_cliente_numero_documento = (SELECT TOP 1 cliente_numero_documento from SQLEADOS.Cliente where cliente_usuario =" + usuarioSeleccionado + ") AND domicilio_cliente_tipo_documento = (SELECT TOP 1 cliente_tipo_documento from SQLEADOS.Cliente where cliente_usuario =" + usuarioSeleccionado +")"; 
            String finalQueryCliente = " where cliente_usuario = "+ usuarioSeleccionado;

            if (apellido == true)
            {
                if (!AyudaExtra.esStringLetra(textBoxApellido.Text.Trim())) 
                {
                    MessageBox.Show("El campo Apellido solo admite letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                queryCliente += " SET cliente_apellido = '" + textBoxApellido.Text.Trim()+"'";
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
                else {
                    queryCliente += " SET cliente_nombre = '" + textBoxNombre.Text.Trim() + "'";
                    clienteTieneSet = true;
                }
            }

            if (tarjeta == true )
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
                else {
                    queryCliente += " SET cliente_datos_tarjeta = " + textBoxTarjeta.Text.Trim();
                    clienteTieneSet = true;
                }
            }

            if (telefono == true)
            {
                if(!AyudaExtra.esStringNumerico(textBoxTelefono.Text.Trim())) 
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

            if (nrocalle == true )
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
                if (!AyudaExtra.esStringNumerico(textBoxPiso.Text)) {
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
            if (estado == true) {
                queryUser = "UPDATE SQLEADOS.Usuario SET usuario_estado = " + txtHabilitado.Text.Trim() + " where usuario_Id = " + usuarioSeleccionado;
            }

            queryCliente += finalQueryCliente;
            queryDomicilio += finalQueryDomicilio;

            if (queryDomicilio.Contains("SET")) {
                MessageBox.Show("MODIFICANDO DOMICILIO");
                DBConsulta.ModificarCliente(queryDomicilio);
         //       this.Close();
            }
            if(queryCliente.Contains("SET")) {
                MessageBox.Show("MODIFICANDO CLIENTE");
                DBConsulta.ModificarCliente(queryCliente);
       //         this.Close();
            }
            if (estado == true) {
                MessageBox.Show("MODIFICANDO ESTADO DE CLIENTE");
                DBConsulta.ModificarCliente(queryUser);
            }
            cargarDatos();
        }

        private void reiniciarBooleanos()
        {
            nombre = false;
            apellido = false; telefono = false; tarjeta = false;
            piso = false; calle = false; nrocalle = false; localidad = false;
            estado = false; codigopostal = false; departamento = false;
        }

        private void camposConAlgunaModificacion() {
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
            if (txtHabilitado.Text.Trim() == "0") {
                estado = true;
            }
            if(txtHabilitado.Text.Trim() == "1") {
                estado = true;
            }
        }
    }
}
