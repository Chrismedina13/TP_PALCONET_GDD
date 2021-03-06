﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using PalcoNet.Registro_de_Usuario;
using PalcoNet.Support;
using PalcoNet.Login_y_seguridad;

namespace PalcoNet
{
    public partial class Inicio : Form
    {
        SqlConnection coneccion;
        SqlCommand validarUsuario, validarContra, cantidadRoles, validarIntentos,
            actualizarIntentos, itemFactura, newCompra, resetearIntentos, modificarStockEstadoPublicacion, modificarMontoFactura, bloquearUsuario, validarBloqueo, esAdmin, roles, vencer, ultimaFactura, facturar, porVisibilidad;
        SqlDataReader data;
        String username;
        String nombreUser;
        public Inicio()
        {
            InitializeComponent();
     //       coneccion = Support.Conexion.conectar();
            coneccion = new SqlConnection(@"Data source=.\SQLSERVER2012;Initial Catalog=GD2C2018;User id=gdEspectaculos2018;Password=gd2018");
            
        }

        //INGRESAR
        private void button1_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                coneccion.Open();
                validarUsuario = new SqlCommand("[SQLeados].ValidarUsuario", coneccion);

                validarUsuario.CommandType = CommandType.StoredProcedure;
                validarUsuario.Parameters.Add("@Username", SqlDbType.VarChar).Value = textBox1.Text;

                var resultado = validarUsuario.Parameters.Add("@Valor", SqlDbType.Int);
                resultado.Direction = ParameterDirection.ReturnValue;
                data = validarUsuario.ExecuteReader();
                data.Close();

                var resultado2 = resultado.Value;

                // validarbloquead;
                validarBloqueo = new SqlCommand("[SQLeados].estaBloqueado", coneccion);

                validarBloqueo.CommandType = CommandType.StoredProcedure;
                validarBloqueo.Parameters.Add("@Username", SqlDbType.VarChar).Value = textBox1.Text;

                var bloq = validarBloqueo.Parameters.Add("@Valor", SqlDbType.Int);
                bloq.Direction = ParameterDirection.ReturnValue;
                data = validarBloqueo.ExecuteReader();
                data.Close();

                coneccion.Close();
                var bloqueado = bloq.Value;
                if ((int)resultado2 == 1)
                {
                    if ((int)bloqueado == 1)
                    {
                        coneccion.Open();

                        validarIntentos = new SqlCommand("[SQLeados].intentosFallidos", coneccion);

                        validarIntentos.CommandType = CommandType.StoredProcedure;
                        validarIntentos.Parameters.Add("@Username", SqlDbType.VarChar).Value = textBox1.Text;


                        var resultadoIntentos = validarIntentos.Parameters.Add("@Valor", SqlDbType.Int);
                        resultadoIntentos.Direction = ParameterDirection.ReturnValue;
                        data = validarIntentos.ExecuteReader();


                        
                        var resultadoIntentos2 = resultadoIntentos.Value;
                        coneccion.Close();
                        data.Close();
                        if (((int)resultadoIntentos2) < 3)
                        {
                            coneccion.Open();
                            validarContra = new SqlCommand("[SQLeados].ValidarContra", coneccion);

                            validarContra.CommandType = CommandType.StoredProcedure;
                            validarContra.Parameters.Add("@Username", SqlDbType.VarChar).Value = textBox1.Text;
                            validarContra.Parameters.Add("@Password", SqlDbType.VarChar).Value = textBox2.Text;

                            var resultadoC = validarContra.Parameters.Add("@Valor", SqlDbType.Int);
                            resultadoC.Direction = ParameterDirection.ReturnValue;
                            data = validarContra.ExecuteReader();
                            var resultadoContra = resultadoC.Value;
                            data.Close();
                            coneccion.Close();
                            if ((int)resultadoContra == 1)
                            {

                                coneccion.Open();
                                // LA CONTRA Y EL USER SON VALIDOS, PASA A BUSCAR ROLES, SI HAY SOLO 1 PASA DE UNA, SINO ELIJE
                                resetearIntentos = new SqlCommand("[SQLeados].resetearIntentoFallidos", coneccion);

                                resetearIntentos.CommandType = CommandType.StoredProcedure;
                                resetearIntentos.Parameters.Add("@Username", SqlDbType.VarChar).Value = textBox1.Text;

                                resetearIntentos.ExecuteNonQuery();
                                coneccion.Close();
                                encontrarRoles();
                                Usuario.username = textBox1.Text;
                                
                            }
                            else
                            {
                                //LA CONRTASEÑA ESTÁ MAL PERO EL USUARIO NO, POR LO TANTO SE INCREMENTA SUS INTENTOS FALLIDOS
                                String mensaje = "";
                                if (esRolAdmin(textBox1.Text))
                                {
                                    mensaje = "Nombre de usuario o contraseña incorrecta";
                                }
                                else 
                                {
                                    coneccion.Open();
                                    actualizarIntentos = new SqlCommand("SQLeados.agregarIntentoFallidos", coneccion);

                                    actualizarIntentos.CommandType = CommandType.StoredProcedure;
                                    actualizarIntentos.Parameters.Add("@Username", SqlDbType.VarChar).Value = textBox1.Text;

                                    actualizarIntentos.ExecuteNonQuery();
                                    coneccion.Close();
                                    if ((((int)resultadoIntentos2) + 1) > 2)
                                    {
                                        coneccion.Open();
                                        bloquearUsuario = new SqlCommand("[SQLeados].bloquearUsuario", coneccion);

                                        bloquearUsuario.CommandType = CommandType.StoredProcedure;
                                        bloquearUsuario.Parameters.Add("@Username", SqlDbType.VarChar).Value = textBox1.Text;

                                        bloquearUsuario.ExecuteNonQuery();
                                        coneccion.Close();
                                    }
                                    mensaje = "Nombre de usuario o contraseña incorrecta, ha perdido un intento de 3";
                                }
                                String caption = "Error en iniciar sesion";
                                textBox1.Clear();
                                textBox2.Clear();
                                MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
                                
                            }
                        }
                    }
                    else
                    {
                        String mensaje = "El usuario esta bloqueado, contactar administrador 0810-999-admin";
                        String caption = "Error en iniciar sesion";
                        textBox1.Clear();
                        textBox2.Clear();
                        MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
                    }
                }

                else
                {
                    String mensaje = "Nombre de usuario o contraseña incorrecto, intetelo de nuevo";
                    String caption = "Error en iniciar sesion";
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
                }
            }

        }

        private Boolean validarCampos()
        {
            if (string.IsNullOrEmpty(textBox1.Text) | string.IsNullOrEmpty(textBox2.Text))
            {
                String mensaje = "Los campos Username y Password son obligatorios";
                String caption = "Ingrese Username y Password";
                MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
                return false;



            }
            else
            {

                return true;
            }

        }

        //BUSCA ROLES, SI HAY 1 SOLO ENTRA AL BUSCADOR SINO DEBE ELEJIR ENTRE ELLOS
        private void encontrarRoles()
        {
            if (!tieneAlgunRol(textBox1.Text))
            {
                MessageBox.Show("Usted no tiene ningún rol asignado o habilitado");
                return;
            }
            coneccion.Open();
            esAdmin = new SqlCommand("[SQLeados].esAdministrador", coneccion);

            esAdmin.CommandType = CommandType.StoredProcedure;
            esAdmin.Parameters.Add("@Username", SqlDbType.VarChar).Value = textBox1.Text;


            var resultadoIntentos = esAdmin.Parameters.Add("@Valor", SqlDbType.Int);
            resultadoIntentos.Direction = ParameterDirection.ReturnValue;
            data = esAdmin.ExecuteReader();
            var resultadoIntentos2 = resultadoIntentos.Value;
            data.Close();

            roles = new SqlCommand("SQLeados.Nombreroles", coneccion);

            roles.CommandType = CommandType.StoredProcedure;
            roles.Parameters.Add("@Username", SqlDbType.VarChar).Value = textBox1.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(roles);
            DataTable tablaRoles = new DataTable();

            adapter.Fill(tablaRoles);
            SqlDataReader reader = roles.ExecuteReader();
            List<string> roleslist = new List<string>();

            comboBox1.DataSource = tablaRoles;
            comboBox1.DisplayMember = "Rol_nombre";
            coneccion.Close();
            if (((int)resultadoIntentos2) == 1)
            {
                DataRow dr = tablaRoles.NewRow();
                dr["Rol_nombre"] = "Seleccione un rol";

                roleslist.Add("Seleccione rol");

                tablaRoles.Rows.InsertAt(dr, 0);
            }

            if (comboBox1.Items.Count == 1)
            {
                //PASA DIRECTO AL EXPLORADOR
                elRolEsAdmin();
                
                String rol;
                if (roleslist.Count != 0)
                {
                    rol = roleslist.First();
                }
                else
                {
                    rol = (tablaRoles.Rows[0]["Rol_nombre"]).ToString();
                }
                //BUSCO SI ES EL PRIMER LOGIN DEL USER ASI CAMBIA LA CONTRA AUTOGENERADA
                
                Usuario.Rol = rol;
                Usuario.username = textBox1.Text;
                String queryss = "SELECT usuario_Id FROM SQLEADOS.Usuario where usuario_nombre LIKE '"+Usuario.username+"'";
                DataTable dts = DBConsulta.AbrirCerrarObtenerConsulta(queryss);
                Usuario.ID = Convert.ToInt32(dts.Rows[0][0].ToString());
                if (primerLogin())
                {
                    CambiarContra ca = new CambiarContra(Usuario.username, new Explorador(this), this, true);
                    ca.Show();
                    this.Hide();
                }
                else {
                    Explorador form = new Explorador(this);
                    form.Show();
                    this.Hide();
                }
            }
            else
            {
                //MUESTRA LA SECCIÓN DE ELEJIR ROLES
        //        button1.Visible = false;
                label9.Visible = true;
                comboBox1.Visible = true;
                comboBox1.Text = "Seleccione un rol";
                button2.Visible = true;
            }

        }

        private void elRolEsAdmin() {
            String queryss = "SELECT usuarioXRol_rol FROM SQLEADOS.UsuarioXRol JOIN SQLEADOS.Usuario u ON u.usuario_Id = usuarioXRol_usuario WHERE usuario_nombre LIKE '" + textBox1.Text + "'";
            DataTable ddt = DBConsulta.AbrirCerrarObtenerConsulta(queryss);
            if (Convert.ToInt32(ddt.Rows[0][0].ToString()) == 0)
            {
                // ES ADMIN
                Usuario.esAdmin = 1;
            }
        }

        private bool tieneAlgunRol(String nombreUser) {
            String query = "SELECT COUNT(*) FROM SQLEADOS.Usuario JOIN SQLEADOS.UsuarioXRol us ON us.usuarioXRol_usuario = usuario_Id where usuario_nombre LIKE '" + nombreUser + "'";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            if (dt.Rows[0][0].ToString() == "0") {
                return false;
            }
            return true;
        }

        private void buscarRolYSaberSiEsAdmin(String rol, String nombreUser) {
            String query = "SELECT rol_Id FROM SQLEADOS.Rol WHERE rol_nombre LIKE '"+ rol+"'";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Usuario.esAdmin = 1;
            }
            else 
            {
                Usuario.esAdmin = 0;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //BOTON SELECCIONAR UN ROL EN ESPECÍFICO
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("No has seleccionado ningún rol aún");
                return;
            }
            buscarRolYSaberSiEsAdmin(comboBox1.Text, textBox1.Text);

            Usuario.Rol = comboBox1.Text;
            Usuario.username = textBox1.Text;
            String queryss = "SELECT usuario_Id FROM SQLEADOS.Usuario where usuario_nombre LIKE '" + Usuario.username + "'";
            DataTable dts = DBConsulta.AbrirCerrarObtenerConsulta(queryss);
            Usuario.ID = Convert.ToInt32(dts.Rows[0][0].ToString());
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Visible = false;
            button2.Visible = false;
            label9.Visible = false;
                
                
            if (primerLogin())
            {
                CambiarContra ca = new CambiarContra(Usuario.username, new Explorador(this), this, true);
                ca.Show();
                this.Hide();
            }
            else {
                Explorador form = new Explorador(this);
                form.Show();
                this.Hide();
            }
        }

        private bool primerLogin() {
            String nombre = Usuario.username;
            String comando = "SELECT usuario_primer_ingreso FROM SQLEADOS.Usuario where usuario_nombre LIKE '" + nombre + "'";
            DBConsulta.conexionAbrir();
            DataTable dt = DBConsulta.obtenerConsultaEspecifica(comando);
            DBConsulta.conexionCerrar();
            //ES TIPO BIT, 1 SIGNIFICA QUE ES SU PRIMER INGRESO
            string COSO = dt.Rows[0][0].ToString();
            /*
            if (COSO == "True") {
                DBConsulta.conexionAbrir();
                comando = "UPDATE SQLEADOS.Usuario SET usuario_primer_ingreso = 0  where usuario_nombre LIKE '" + nombre + "'";
                DBConsulta.modificarDatosDeDB(comando);
                DBConsulta.conexionCerrar();
                return true;
            }*/
            return false;
        }

        //BOTON REGISTRAR
        private void button3_Click(object sender, EventArgs e)
        {
            RegistroUser a = new RegistroUser(this);
            a.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private bool esRolAdmin(String text) 
        {
            String queryBuscar = "SELECT usuario_administrador FROM SQLEADOS.Usuario WHERE usuario_nombre LIKE '" + text + "'";

            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(queryBuscar);
            String respuesta = dt.Rows[0][0].ToString();
            if (respuesta == "True")
            {
                return true;
            }
            return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}