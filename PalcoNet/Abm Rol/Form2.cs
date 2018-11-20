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
using System.Configuration;


namespace PalcoNet.ABM_Rol
{
    public partial class Form2 : Form
    {
        SqlConnection coneccion;
        SqlCommand cargarFunc, crearRol, codigoRol, crearFunc, existeRol, codigoFunc;
        List<String> funcion = new List<String>();
        SqlDataReader data;
        int rol = 0;

        public Form2()
        {
            InitializeComponent();
            coneccion = Support.ConsultasSQL.conectar();
            coneccion.Open();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cargarFunc = new SqlCommand("[SQLeados].listarFuncionalidades", coneccion);

            cargarFunc.CommandType = CommandType.StoredProcedure;
            
            SqlDataAdapter adapter = new SqlDataAdapter(cargarFunc);
            DataTable tablaRoles = new DataTable();

            adapter.Fill(tablaRoles);
            SqlDataReader reader = cargarFunc.ExecuteReader();

            listBox1.DataSource = tablaRoles;
            listBox1.DisplayMember = "funcionalidad_descripcion";
            coneccion.Close();
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 
            ABM_Rol.Form1 accionesRol = new ABM_Rol.Form1();
            accionesRol.Show();
        }

        private void validarCampos()
        {
            if (string.IsNullOrEmpty(textBox1.Text) || (int)listBox2.Items.Count == 0)
            {
                String mensaje = "Los campos nombre y funcionalidades son obligatorios";
                String caption = "Error al crear el rol";
                MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);

            }
               else
            {
                coneccion.Open();
                existeRol = new SqlCommand("SQLeados.existeRol", coneccion);
                existeRol.CommandType = CommandType.StoredProcedure;
                existeRol.Parameters.Add("@nombre", SqlDbType.VarChar).Value = textBox1.Text;
                var resultado = existeRol.Parameters.Add("@Valor", SqlDbType.Int);
                resultado.Direction = ParameterDirection.ReturnValue;
                data = existeRol.ExecuteReader();
                var existeR = resultado.Value;
                data.Close();
                coneccion.Close();

                if ((int)existeR == 1)
                {
                    String mensaje = "El rol ya exisste, ingrese otro nombre";
                    String caption = "Error al crear el rol";
                    MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
                }
                else
                    crearNuevoRol();
            }


                
             }
            

        private void button2_Click(object sender, EventArgs e)
        {
            validarCampos();
        }
                      
                  

        private void crearNuevoRol(){
        
                coneccion.Open();
                crearRol = new SqlCommand("SQLeados.crearRolNuevo", coneccion);
                crearRol.CommandType = CommandType.StoredProcedure;
                crearRol.Parameters.Add("@nombre", SqlDbType.VarChar).Value = textBox1.Text;
                crearRol.ExecuteNonQuery();


                codigoRol = new SqlCommand("SQLeados.codigoRol", coneccion);
                codigoRol.CommandType = CommandType.StoredProcedure;
                codigoRol.Parameters.Add("@nombre", SqlDbType.VarChar).Value = textBox1.Text;
                var resultado = codigoRol.Parameters.Add("@Valor", SqlDbType.Int);
                resultado.Direction = ParameterDirection.ReturnValue;
                data = codigoRol.ExecuteReader();
                coneccion.Close();
                
                var codi = resultado.Value;
                rol = (int)codi;
                data.Close();

                crearFuncionalidades();
        
        }

        private void crearFuncionalidades()
        {

            List<int> codigos = new List<int>();
         
            
            for (int i = 0; i < funcion.Count(); i++)
            {
                coneccion.Open();
                codigoFunc = new SqlCommand("SQLeados.codigoFuncionalidad", coneccion);
                codigoFunc.CommandType = CommandType.StoredProcedure;
                codigoFunc.Parameters.Add("@nombre", SqlDbType.VarChar).Value = funcion.ElementAt(i).ToString();
                var resultado = codigoFunc.Parameters.Add("@Valor", SqlDbType.Int);
                resultado.Direction = ParameterDirection.ReturnValue;
                data = codigoFunc.ExecuteReader();
                var codigo = resultado.Value;
                int aniadir = (int)codigo;
                codigos.Add(aniadir);
                data.Close();
                coneccion.Close();
                
            }

            for (int i = 0; i < codigos.Count(); i++)
            {
                
                coneccion.Open();
                crearFunc = new SqlCommand("SQLeados.crearFuncionalidad", coneccion);
                crearFunc.CommandType = CommandType.StoredProcedure;
                crearFunc.Parameters.Add("@codigoRol", SqlDbType.Int).Value = rol;
                crearFunc.Parameters.Add("@codigoFunc", SqlDbType.Int).Value = codigos.ElementAt(i);
                crearFunc.ExecuteNonQuery();
                coneccion.Close();

            }

            rol = 0;
            String mensaje = "El rol se ha creado exitosamente";
            String caption = "Rol creado";
            MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
            ABM_Rol.Form1 form1= new ABM_Rol.Form1();
            form1.Show();
            this.Close();

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
            
            
       




      

       

       


    

}
}
