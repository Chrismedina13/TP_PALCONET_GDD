using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Globalization;
using System.Data.SqlClient;
using PalcoNet.Support;

namespace PalcoNet.ABM_Usuario
{
    public partial class IngresarNuevoAdmin : Form
    {
        tipoUserAAgregar exx;
        Registro_de_Usuario.RegistroUser registro;
        bool esParaAdmin, deABMUser;
        String rolUser;
        public IngresarNuevoAdmin(tipoUserAAgregar ex, bool esAdmin, bool vieneDeABMUser, Registro_de_Usuario.RegistroUser reg, String rol)
        {
            if (esAdmin)
            {
                rolUser = "Administrativo";
                exx = ex;
                registro = null;
            }
            else {
                if (vieneDeABMUser)
                {
                    rolUser = rol;
                    exx = ex;
                    registro = null;
                }
                else {
                    exx = null;
                    registro = reg;
                    rolUser = rol;
                }
            }
            deABMUser = vieneDeABMUser;
            esParaAdmin = esAdmin;
            
            InitializeComponent();
        }

        //BOTON VOLVER EN REALIDAD
        private void buttonCliente_Click(object sender, EventArgs e)
        {
            if (esParaAdmin)
            {
                exx.Show();
                this.Close();
            }
            else
            {
                registro.terminar();
                this.Close();
            }
        }
        //BOTON VOLVER
        private void buttonEmpresa_Click(object sender, EventArgs e)
        {
    //        Abm_Empresa_Espectaculo.EliminarEmpresa form = new Abm_Empresa_Espectaculo.EliminarEmpresa();
            if (esParaAdmin)
            {
                exx.Show();
                this.Close();
            }
            else {
                if (deABMUser)
                {
                    exx.Show();
                    this.Close();
                }
                else {
                    registro.terminar();
                    this.Close();
                }
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            if (esParaAdmin)
            {
                labelAdminTitulo.Text = "Crear nuevo ADMIN";
                labelNOMBREROL.Text = "ADMINISTRADOR";
                botoncrearAdmin.Text = "Crear nuevo Admin";
            }
            else
            {
                labelAdminTitulo.Text = "Crear nuevo Usuario";
                labelNOMBREROL.Text = rolUser;
                botoncrearAdmin.Text = "Crear nuevo User";
            }
            
        }

        private void botoncrear_Click(object sender, EventArgs e)
        {
            String error = "";
            if (textBoxcontra.Text.Trim() == "") {
                error += "El campos contraseña está vacio, debe rellenarlo\n";
            }
            if (textBoxNombre.Text.Trim() == "")
            {
                error += "El campos nombre de usuario está vacio, debe rellenarlo\n";
            }
            if (textBoxrepecontra.Text.Trim() == "")
            {
                error += "El campos repetir la contraseña está vacio, debe rellenarlo\n";
            }
            if (!AyudaExtra.esStringNumerico(textBoxcontra.Text)) {
                error += "La contraseña debe ser numérica, debe rellenarlo\n";
            }
            if (!AyudaExtra.esStringNumerico(textBoxrepecontra.Text))
            {
                error += "La contraseña debe ser numéricao, debe rellenarlo\n";
            }

            if (textBoxcontra.Text != textBoxrepecontra.Text) {
                error += "Las contraseñas ingresadas no coinciden\n";
            }
            if(error !="") {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String comando, comando2;
            String nombreUser = textBoxNombre.Text.Replace(" ", "_");
            if (esParaAdmin)
            {
                comando = "INSERT INTO SQLEADOS.Usuario(usuario_nombre, usuario_password, usuario_administrador) VALUES ('" + nombreUser + "' , " + textBoxcontra.Text + ", 1);";
                comando2 = "INSERT INTO SQLEADOS.UsuarioXRol (usuarioXRol_usuario, usuarioXRol_rol) SELECT usuario_Id, rol_Id FROM SQLEADOS.Usuario, SQLEADOS.Rol WHERE usuario_Id = (SELECT TOP 1 usuario_Id FROM SQLEADOS.Usuario U ORDER BY U.usuario_Id DESC)";
            }
            else {
                String obtenerIDRol = "SELECT rol_Id FROM SQLEADOS.Rol WHERE rol_nombre LIKE '"+rolUser+"'";
                DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(obtenerIDRol);
                //ID DE ROL
                String ID = dt.Rows[0][0].ToString();
                comando = "INSERT INTO SQLEADOS.Usuario(usuario_nombre, usuario_password) VALUES ('" + nombreUser + "' , " + textBoxcontra.Text + ");";
                comando2 = "INSERT INTO SQLEADOS.UsuarioXRol (usuarioXRol_usuario, usuarioXRol_rol) SELECT S.usuario_Id, "+ID+" FROM SQLEADOS.Usuario S WHERE S.usuario_Id = (SELECT TOP 1 usuario_Id FROM SQLEADOS.Usuario U ORDER BY U.usuario_Id DESC)";
            }
            
            DBConsulta.AbrirCerrarModificarDB(comando);
            DBConsulta.AbrirCerrarModificarDB(comando2);
            MessageBox.Show("Se añadido el nuevo "+ rolUser);

            if (!esParaAdmin) { 
                //VUELVE, PORQUE SOLO SE HACE UN SOLO INSERT SI NO EL CREADOR NO ES UN ADMIN
                registro.terminar();
                this.Close();
            }

        }
    }
}
