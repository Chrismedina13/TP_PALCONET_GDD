using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using PalcoNet.Support;

namespace PalcoNet.ABM_Rol
{
    public partial class FormModificarRol : Form
    {

        SqlConnection coneccion;
        SqlDataReader data;
        SqlCommand cargarRoles, cargarFunc, fpr, existeRol, cambiarN, eliminar, crearFunc, codigoRol, codigoFunc, habilitado, habilitar;
        List<String> funcion = new List<String>();
        List<String> funcionesViejas = new List<String>();
        
        string rol;
        ABMROL ro;
        public FormModificarRol(ABMROL rol)
        {
            ro = rol;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar() {
            //coneccion = PalcoNet.Support.Conexion.conectar();
            //coneccion.Open();
            //cargarRoles = new SqlCommand("[SQLeados].cargarRoles", coneccion);

            //cargarRoles.CommandType = CommandType.StoredProcedure;
            String cmd = "SELECT rol_nombre FROM SQLEADOS.Rol";
            DBConsulta.conexionAbrir();
            DataTable tablaRoles = DBConsulta.obtenerConsultaEspecifica(cmd);
            DBConsulta.conexionCerrar();
            //SqlDataAdapter adapter = new SqlDataAdapter(cargarRoles);

            //coneccion.Close();
            //adapter.Fill(tablaRoles);
            comboBox2.DataSource = tablaRoles;
            comboBox2.DisplayMember = "Rol_nombre";

            

            cargarFuncionalidades();
        }

        private void actualizarHabilitado() {
            int habilitado = estaHabilitado(rol);
            if (habilitado == 0)
            {
                labelEstado.Text = "Inhabilitado";
            }
            else {
                labelEstado.Text = "Habilitado";
            }
        }

        //EL BOTON CON EL SIGNO DE APROBADO
        private void button1_Click(object sender, EventArgs e)
        {
            rol = comboBox2.Text.ToString();
            int habilitado = estaHabilitado(rol);
            if (habilitado == 0)
            {
                button6.Visible = true;
                label6.Visible = true;
                label5.Visible = true;
                labelEstado.Text = "Inhabilitado";
                labelEstado.Visible = true;
            }
            else
            {
                label6.Visible = true;
                label6.Visible = true;
                label5.Visible = true;
                labelEstado.Text = "Habilitado";
                labelEstado.Visible = true;
            }
            label3.Visible = true;
            label6.Visible = true;
            textBox1.Visible = true;
            listBox1.Visible = true;
            listBox2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            textBox1.Text = rol;
            button2.Visible = true;

            cargarFuncionalidadesPorRol(rol);

   
        }

        private int estaHabilitado(String rol)
        {
            String comando = "SELECT rol_estado FROM SQLEADOS.ROL WHERE rol_nombre LIKE '"+ rol +"'";
            DBConsulta.conexionAbrir();
            DataTable dt = DBConsulta.obtenerConsultaEspecifica(comando);
            DBConsulta.conexionCerrar();
           // coneccion.Open();
           // habilitado = new SqlCommand("[SQLeados].rolHabilitado", coneccion);
           //habilitado.CommandType = CommandType.StoredProcedure;
           //habilitado.Parameters.Add("@nombre", SqlDbType.VarChar).Value = rol;
           //var resultado = habilitado.Parameters.Add("@Valor", SqlDbType.Bit);
           // resultado.Direction = ParameterDirection.ReturnValue;
           // data = habilitado.ExecuteReader();
           //  var habi = resultado.Value;
           // int respuesta = (int)habi;
           // coneccion.Close();
           // data.Close();
            if (dt.Rows[0][0].ToString() == "True") {
                return 1;
            }
            return 0;
        }

       
        
        private void cargarFuncionalidadesPorRol(String rol) 
        {
            List<String> funcionalidades = new List<string>();
            listBox2.Items.Clear();
            funcionesViejas.Clear();
            funcionalidades.Clear();
            funcion.Clear();
            String comando = "SELECT funcionalidad_descripcion FROM SQLEADOS.Rol JOIN SQLEADOS.FuncionalidadXRol ON funcionalidadXRol_rol = rol_Id JOIN SQLEADOS.Funcionalidad ON funcionalidad_Id = funcionalidadXRol_funcionalidad WHERE rol_nombre LIKE '" + rol + "'";
            DBConsulta.conexionAbrir();
            DataTable dt = DBConsulta.obtenerConsultaEspecifica(comando);
            DBConsulta.conexionCerrar();
            //coneccion.Open();
            //fpr = new SqlCommand("[SQLeados].FuncionalidadesPorRol", coneccion);

            //fpr.CommandType = CommandType.StoredProcedure;
            //fpr.Parameters.Add("@Rol", SqlDbType.VarChar).Value = rol;

            //SqlDataAdapter adapter = new SqlDataAdapter(fpr);
            //SqlDataReader reader = fpr.ExecuteReader();
            for (int i = 0; i < dt.Rows.Count; i++) {
                funcionalidades.Add(dt.Rows[i][0].ToString());
            }

                listBox2.Items.AddRange(funcionalidades.ToArray());

            for (int j = 0; j < listBox2.Items.Count; j++)
            {

                string text = listBox2.GetItemText(listBox2.Items[j]);

                funcion.Add(text);
                funcionesViejas.Add(text);
            }

        }

        private void validarCampos()
        {

          if (string.IsNullOrEmpty(textBox1.Text) || (int)listBox2.Items.Count == 0)
           {
                String mensaje = "Los campos nombre y funcionalidades son obligatorios";
                String caption = "Error al modificar el rol";
                MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);

            }
            
            else
            {
                coneccion.Open();
                existeRol = new SqlCommand("[SQLeados].existeRol", coneccion);
                existeRol.CommandType = CommandType.StoredProcedure;
                existeRol.Parameters.Add("@nombre", SqlDbType.VarChar).Value = textBox1.Text;
                var resultado = existeRol.Parameters.Add("@Valor", SqlDbType.Int);
                resultado.Direction = ParameterDirection.ReturnValue;
                data = existeRol.ExecuteReader();
                var existeR = resultado.Value;
                data.Close();
                coneccion.Close();

                if ((int)existeR == 1 && !(rol.Equals(textBox1.Text)))
                {
                    String mensaje = "El rol ya existe, ingrese otro nombre";
                    String caption = "Error al modificar el rol";
                    MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
                }
                else
                    modificarRol();

            }

        }

        private void modificarRol() {

                coneccion.Open();
                cambiarN = new SqlCommand("SQLeados.modificarRol", coneccion);
                cambiarN.CommandType = CommandType.StoredProcedure;
                cambiarN.Parameters.Add("@nombre", SqlDbType.VarChar).Value = textBox1.Text;
                cambiarN.Parameters.Add("@anterior", SqlDbType.VarChar).Value = rol;
                cambiarN.ExecuteNonQuery();


                codigoRol = new SqlCommand("SQLeados.codigoRol", coneccion);
                codigoRol.CommandType = CommandType.StoredProcedure;
                codigoRol.Parameters.Add("@nombre", SqlDbType.VarChar).Value = textBox1.Text;
                var resultado = codigoRol.Parameters.Add("@Valor", SqlDbType.Int);
                resultado.Direction = ParameterDirection.ReturnValue;
                data = codigoRol.ExecuteReader();
               

                var codi = resultado.Value;
                int codigo = (int)codi;
                data.Close();

                eliminar = new SqlCommand("SQLeados.eliminarFuncionalidades", coneccion);
                eliminar.CommandType = CommandType.StoredProcedure;
                eliminar.Parameters.Add("@rol", SqlDbType.Int).Value = codigo;
                eliminar.ExecuteNonQuery();
                coneccion.Close();

                List<int> codigos = new List<int>();


                for (int i = 0; i < funcion.Count(); i++)
                {
                    coneccion.Open();
                    codigoFunc = new SqlCommand("SQLeados.codigoFuncionalidad", coneccion);
                    codigoFunc.CommandType = CommandType.StoredProcedure;
                    codigoFunc.Parameters.Add("@nombre", SqlDbType.VarChar).Value = funcion.ElementAt(i).ToString();
                    var resultado2 = codigoFunc.Parameters.Add("@Valor", SqlDbType.Int);
                    resultado2.Direction = ParameterDirection.ReturnValue;
                    data = codigoFunc.ExecuteReader();
                    var codigo2 = resultado2.Value;
                    int aniadir = (int)codigo2;
                    codigos.Add(aniadir);
                    data.Close();
                    coneccion.Close();
                                    }


                for (int i = 0; i < codigos.Count(); i++)
                {

                    coneccion.Open();
                    crearFunc = new SqlCommand("SQLeados.crearFuncionalidad", coneccion);
                    crearFunc.CommandType = CommandType.StoredProcedure;
                    crearFunc.Parameters.Add("@codigoRol", SqlDbType.Int).Value = codigo;
                    crearFunc.Parameters.Add("@codigoFunc", SqlDbType.Int).Value = codigos.ElementAt(i);
                    crearFunc.ExecuteNonQuery();
                    coneccion.Close();

                }

                String mensaje = "El rol se ha modificado correctamente";
                String caption = "Rol modificado";
                MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);

                this.Close();
                //ABM_Rol.ABMROL accionesRol = new ABM_Rol.ABMROL();
                //accionesRol.Show();
                


                
                

            

          
        }



        
        
        
        private void cargarFuncionalidades()
        {

            //coneccion.Open();
            //cargarFunc = new SqlCommand("SQLeados.listarFuncionalidades", coneccion);

            //cargarFunc.CommandType = CommandType.StoredProcedure;

            //SqlDataAdapter adapter = new SqlDataAdapter(cargarFunc);
            //DataTable tablaRoles = new DataTable();

            //adapter.Fill(tablaRoles);
            //SqlDataReader reader = cargarFunc.ExecuteReader();

            String comando = "SELECT funcionalidad_descripcion FROM SQLEADOS.Funcionalidad";
            DBConsulta.conexionAbrir();
            DataTable tablaRoles = DBConsulta.obtenerConsultaEspecifica(comando);
            DBConsulta.conexionCerrar();
            listBox1.DataSource = tablaRoles;
            listBox1.DisplayMember = "funcionalidad_descripcion";
            //coneccion.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = listBox1.GetItemText(listBox1.SelectedItem);

            if (funcion.Contains(text))
            {

                String mensaje = "Esta funcionalidad ya ha sido ingresada";
                String caption = "Funcionalidad duplicada";
                MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);

            }
            else
            {

                listBox2.DisplayMember = "funcionalidad_descripcion";
                listBox2.Items.Add((DataRowView)listBox1.SelectedItem);

                funcion.Add(text);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text = listBox2.GetItemText(listBox2.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);

            funcion.Remove(text);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ro.Show();
            this.Hide();
            //ABM_Rol.ABMROL accionesRol = new ABM_Rol.ABMROL();
            //accionesRol.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            validarCampos();
            cargar();
        }

        //HABILITAR
        private void button6_Click(object sender, EventArgs e)
        {

            String update = "UPDATE SQLEADOS.Rol SET rol_estado = 1 WHERE rol_nombre LIKE '" + comboBox2.Text.ToString() + "'";
            DBConsulta.conexionAbrir();
            DBConsulta.modificarDatosDeDB(update);
            DBConsulta.conexionCerrar();
            
            //coneccion.Open();
            //habilitar = new SqlCommand("SQLeados.habilitarRol", coneccion);
            //habilitar.CommandType = CommandType.StoredProcedure;
            //habilitar.Parameters.Add("@nombre", SqlDbType.VarChar).Value = comboBox2.Text.ToString();
            //habilitar.ExecuteNonQuery();
            //coneccion.Close();

            String mensaje = "El rol ha sido habilitado";
            String caption = "Rol modificado";
            MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
            actualizarHabilitado();
        }
    }
}
