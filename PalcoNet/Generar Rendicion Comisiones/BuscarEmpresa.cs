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

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class BuscarEmpresa : Form
    {
        GenerarFacturaDeComisiones factura;
        public BuscarEmpresa(GenerarFacturaDeComisiones fac)
        {
            factura = fac;
            InitializeComponent();
        }

        //FILTRAR POR NOMBRE DE LA EMPRESA
        private void button2_Click(object sender, EventArgs e)
        {
            /*
            if (!AyudaExtra.esStringConLetraONumero(textBox1.Text.Trim())) {
                MessageBox.Show("Ingrese un nombre válido");
                return;
            }*/
            
            String query = "SELECT empresa_razon_social FROM SQLEADOS.Empresa where empresa_razon_social LIKE '%" + textBox1.Text.Trim() + "%'";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            if (dt.Rows.Count == 0) {
                MessageBox.Show("No existe ninguna empresa con ese nombre");
                return;
            }
            dataGridView1.DataSource = dt;
        }

        private void BuscarEmpresa_Load(object sender, EventArgs e)
        {
            String query = "SELECT empresa_razon_social FROM SQLEADOS.Empresa";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            dataGridView1.DataSource = dt;
        }

        //SELECCIONA UNA EMPRESA ELEGIDA
        private void button1_Click(object sender, EventArgs e)
        {
            String empresa = dataGridView1.SelectedCells[0].Value.ToString();
            if (!buscarSiTienePublicacionesFinalizadasSinCobrar(empresa)) {
                MessageBox.Show("Ya se le generó las factura a todas\nlas publicaciones finalizadas de esta empresa");
                return;
            }
            BuscarPublicacionSinCobrar pub = new BuscarPublicacionSinCobrar(empresa, this, factura);
            pub.Show();
            this.Hide();
        }

        private bool buscarSiTienePublicacionesFinalizadasSinCobrar(String empresa) {
            //BUSCA SI LA PUBLICACIÓN DE LA EMPRESA AL CUAL LE QUIERO COBRAR 
            //ESTÁ EN ESTADO FINALIZADO Y ADEMÁS NO FUE ANTERIORMENTE
            //REGISTRADO EN UNA ANTERIOR FACTURA
            String query = "SELECT COUNT(*) FROM SQLEADOS.Publicacion JOIN SQLEADOS.Empresa ON publicacion_usuario_responsable = empresa_usuario WHERE empresa_razon_social LIKE '" + empresa + "'";// AND publicacion_codigo NOT IN (SELECT factura_publicacion FROM SQLEADOS.Factura) AND publicacion_estado LIKE 'Finalizada'";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            return Convert.ToInt32(dt.Rows[0][0].ToString()) > 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //limpiar
            textBox1.Text = "";
        }
    }
}
