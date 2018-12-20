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
using PalcoNet.Registro_de_Usuario;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class AltaEmpresa : Form
    {
        ABMEmpresa ante;
        RegistroUser reg;
        bool deEmpresa;
        public AltaEmpresa(ABMEmpresa empre, bool vieneDeEmpresa, RegistroUser regUser)
        {
            deEmpresa = vieneDeEmpresa;
            if (deEmpresa)
            {
                ante = empre;
            }
            else {
                reg = regUser;
            }
            InitializeComponent();
        }

        private String validarCamposIniciales()
        {
            String error = "";

            if (textBoxRazonSocial.Text.Trim() == "" | textBoxCuit.Text.Trim() == "" | textBoxTelefono.Text.Trim() == "" | textBoxMail.Text.Trim() == ""
                | textBoxCodigoPostal.Text.Trim() == "" | textBoxNroCalle.Text.Trim() == "" | textBoxCiudad.Text.Trim() == "" | textBoxCalle.Text.Trim() == "")
            {
                error += "Faltan completar campos\n";
                //             MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //             return;
                if (textBoxRazonSocial.Text.Trim() == "")
                {
                    error += "Faltan completar el nombre de la empresa\n";
                }
                if (textBoxCuit.Text.Trim() == "")
                {
                    error += "Faltan completar el CUIT de la empresa\n";
                }
                if (textBoxTelefono.Text.Trim() == "")
                {
                    error += "Faltan completar el número de telefono de la empresa\n";
                }
                if (textBoxCodigoPostal.Text.Trim() == "")
                {
                    error += "Faltan completar el código postal de la empresa\n";
                }
                if (textBoxNroCalle.Text.Trim() == "")
                {
                    error += "Faltan completar el número de calle de la empresa\n";
                }
                if (textBoxMail.Text.Trim() == "")
                {
                    error += "Faltan completar el mail de la empresa\n";
                }
                if (textBoxCiudad.Text.Trim() == "")
                {
                    error += "Faltan completar la ciudad de la empresa\n";
                }
                if (textBoxCalle.Text.Trim() == "")
                {
                    error += "Faltan completar la dirección de calle de la empresa\n";
                }
            }
            return error;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            String error = validarCamposIniciales();
            
            if (!AyudaExtra.esUnMail(textBoxMail.Text)) {
                error += "Ingrese un mail valido\n";
         //       MessageBox.Show("Ingrese un mail valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         //       return;
            }
            if (mailRepetido(textBoxMail.Text)) {
                error += "Mail repetido, ingrese otro\n";
         //       MessageBox.Show("Mail repetido, ingrese otro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         //       return;
            }

            if (!AyudaExtra.esStringNumerico(textBoxCuit.Text))
            {
                error += "Sólo se permiten numeros en el CUIT\n";
           //     MessageBox.Show("Sólo se permiten numeros en el CUIT", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            }
            if (!AyudaExtra.esStringNumerico(textBoxNroCalle.Text))
            {
                error += "Sólo se permiten numeros en el Nro de calle\n";
        //        MessageBox.Show("Sólo se permiten numeros en el Nro de calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
            }
            if (textBoxPiso.Text.Trim() != "") {
                if (!AyudaExtra.esStringNumerico(textBoxPiso.Text))
                {
                    error += "Sólo se permiten numeros en el Pisoe\n";
           //         MessageBox.Show("Sólo se permiten numeros en el Piso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
                }
            }
            if (!AyudaExtra.esStringLetra(textBoxCiudad.Text)) {
                error += "Sólo se permiten letras en el campo ciudad\n";
            //    MessageBox.Show("Sólo se permiten letras en el campo ciudad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          //      return;
            }
            if (textBoxDto.Text.Trim() != "") {
                if (!AyudaExtra.esStringLetra(textBoxDto.Text))
                {
                    error += "Sólo se permiten letras en el departamento\n";
           //         MessageBox.Show("Sólo se permiten letras en el departamento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           //         return;
                }
            }
            if (!AyudaExtra.esStringNumerico(textBoxTelefono.Text))
            {
                error += "Sólo se permiten numeros en el Telefono\n";
          //      MessageBox.Show("Sólo se permiten numeros en el Telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         //       return;
            }
            /*
              if (textBoxCuit.TextLength != 11)
            {
                MessageBox.Show("El cuit tiene que tener 11 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            */

            String razonSocial = textBoxRazonSocial.Text;
            if(existeRazonSocialYa(razonSocial) ){
                error += "Ya se encuentra registrado esa razon social, ingrese otro\n";
         //       MessageBox.Show("Ya se encuentra registrado esa razon social, ingrese otro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         //       return;
            }

            String cuit = armarCuit(textBoxCuit.Text);
            String ciudad = textBoxCiudad.Text;

            if (existeCuit(cuit))
            {
                error += "Ya se encuentra registrado el numero de CUIT, ingrese otro\n";
    //            MessageBox.Show("Ya se encuentra registrado el numero de CUIT, ingrese otro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
     //           return;
            }

            String mail = textBoxMail.Text;
            String telefono = textBoxTelefono.Text;
            int nroCalle = Convert.ToInt32(textBoxNroCalle.Text);
            String calle = textBoxCalle.Text;
            String codPostal = textBoxCodigoPostal.Text;
            String dto = textBoxDto.Text;
            int piso = 0;
            if (textBoxPiso.Text != "") { 
                piso = Convert.ToInt32(textBoxPiso.Text);
            }
             
            String localidad = textBoxLocalidad.Text;

            int usuarioNuevo =0;
            bool errores = false;

            DBConsulta.conexionAbrir();
            bool autocontra = false;
            String contraautogenerada = autogenerarContrasenia.contraGeneradaAString();
            //SE CREA EL USUARIO
            if (textBoxContrasenia.Text.Trim() != "")
            {
                if (AyudaExtra.esStringNumerico(textBoxContrasenia.Text.Trim()))
                {
                    if (error != "") {
                        error += "La contraseña debe ser numérica\n";
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    usuarioNuevo = ConsultasSQL.crearUser(textBoxRazonSocial.Text.Trim().Replace(" ", "_"), false, textBoxContrasenia.Text.Trim(), "Empresa");
                }
                else
                {
                    error += "La contraseña debe ser numérica\n";
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    //         MessageBox.Show("La contraseña debe ser numérica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //       errores = true;
                }
            }
            else
            {
                autocontra = true;
                usuarioNuevo = ConsultasSQL.crearUser(textBoxRazonSocial.Text.Trim().Replace(" ", "_"), false, contraautogenerada, "Empresa");

                
            }
            //TERMINA CREA EL USUARIO
            DBConsulta.conexionCerrar();
            //CREA LA EMPRESA
            if (!errores)
            {
                DateTime hoy = DateTime.Today;
                int ultimoUser;

                String obtenerUltimoUser = "SELECT TOP 1 usuario_Id FROM SQLEADOS.Usuario order by usuario_Id DESC";
                DataTable ds = DBConsulta.AbrirCerrarObtenerConsulta(obtenerUltimoUser);
                ultimoUser = Convert.ToInt32(ds.Rows[0][0].ToString());
                DBConsulta.creacionNuevoEmpresa(razonSocial,mail,cuit,hoy.ToString(),ultimoUser, ciudad, telefono);
     ///           crearNuevaEmpresa(razonSocial, cuit, ciudad, mail, telefono, Convert.ToInt32(ds.Rows[0][0].ToString()), hoy);
        //        ConsultasSQLEmpresa.AgregarEmpresa(razonSocial, cuit, ciudad, mail, telefono, Convert.ToInt32(ds.Rows[0][0].ToString()), hoy);
                DBConsulta.crearNuevoDomicilioEmpresa(calle, nroCalle.ToString(), piso.ToString(), dto, codPostal, localidad, razonSocial, cuit);
                
        //        ConsultasSQLEmpresa.AgregarDomicilio(calle, nroCalle, piso, dto, localidad, codPostal, "Empresa");
                this.limpiarCuadrosDeTexto();
                String obtenerNombreUser = "SELECT TOP 1 usuario_nombre FROM SQLEADOS.Usuario order by usuario_Id DESC";
                DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(obtenerNombreUser);
                
                String mostrarResultado = "Se ha agregado el nuevo Usuario:\n\n" + dt.Rows[0][0].ToString();
                if (autocontra) {
                    mostrarResultado += "\n\nSe ha autogenerado una contraseña, es: " + contraautogenerada;
                }
                MessageBox.Show(mostrarResultado);
                if (deEmpresa)
                {
                    ante.Show();
                }
                else {
                    reg.terminar();
                }
                this.Close();
            }
            else {
                return;
            }
        }

        private void crearNuevaEmpresa(String razonSocial, String cuit, String ciudad, String mail, string telefono, int user, DateTime fecha) { 
            String query = "insert into [GD2C2018].[SQLEADOS].[Empresa] (empresa_razon_social,empresa_cuit,empresa_ciudad,empresa_email,empresa_telefono,empresa_usuario,empresa_fecha_creacion) values ('"+razonSocial+"','"+cuit+"','"+ciudad+"','"+mail+"','"+telefono+"',"+user+","+fecha+")";
            DBConsulta.AbrirCerrarModificarDB(query);
        }

        private bool existeRazonSocialYa(String nombre) {
            String comando = "SELECT empresa_razon_social FROM SQLEADOS.Empresa where empresa_razon_social = '" + nombre + "'";

            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(comando);
            return dt.Rows.Count > 0;
        }

        private bool existeCuit(String cuit) {
            String comando = "SELECT empresa_cuit FROM SQLEADOS.Empresa where empresa_cuit = '"+cuit+"'";

            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(comando);
            return dt.Rows.Count > 0;
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            if (deEmpresa)
            {
                ante.Show();
            }
            else {
                reg.Show();
            }
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
            textBoxContrasenia.Text = "";
        }


        public String armarCuit(String cuitSinArmar) {
            //COMO NO SE SABE LA LONGITUD EXACTA DEL CODIGO NUMERICO DEL MEDIO, DEJAMOS ESE CAMPO LIBRE Y LOS ULTIMOS 2 SERNA LOS CODIGOS DE FINAL
            int n = cuitSinArmar.Length;
            String primeraParte = cuitSinArmar.Substring(0, 2);
            String SegundaParte = cuitSinArmar.Substring(2, n-4);
            String TerceraParte = cuitSinArmar.Substring(n-2, 2);
            String cuitArmado = primeraParte + "-" + SegundaParte + "-" + TerceraParte;

            return cuitArmado;
        
        }

        private bool mailRepetido(String mail) {
            String comando = "SELECT empresa_email FROM SQLEADOS.Empresa WHERE empresa_email LIKE '" + mail + "' UNION SELECT cliente_email FROM SQLEADOS.Cliente  WHERE cliente_email LIKE '" + mail + "'";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(comando);
            return dt.Rows.Count > 0;
        }

        private void AltaEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNroCalle_TextChanged(object sender, EventArgs e)
        {

        }

        //LIMPIAR
        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCuadrosDeTexto();
        }
      
    }
}
