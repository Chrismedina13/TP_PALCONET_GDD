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
    public partial class BuscarPublicacionSinCobrar : Form
    {
        BuscarEmpresa em;
        String empresa;
        GenerarFacturaDeComisiones factura;
        public BuscarPublicacionSinCobrar(String empres, BuscarEmpresa emp, GenerarFacturaDeComisiones fac)
        {
            factura = fac;
            empresa = empres;
            em = emp;
            InitializeComponent();
        }

        private void BuscarPublicacionSinCobrar_Load(object sender, EventArgs e)
        {
            String query = "SELECT publicacion_codigo as 'ID', publicacion_descripcion as 'Nombre espectáculo', publicacion_fecha as 'Fecha' FROM SQLEADOS.Publicacion JOIN SQLEADOS.Empresa ON publicacion_usuario_responsable = empresa_usuario WHERE empresa_razon_social LIKE '" + empresa + "' AND publicacion_estado LIKE 'Finalizada' AND publicacion_codigo NOT IN (SELECT factura_publicacion FROM SQLEADOS.Factura)";
            dataGridView1.DataSource = DBConsulta.AbrirCerrarObtenerConsulta(query);
            cargarGrilla();
        }

        private void cargarGrilla() 
        {
            DataGridViewColumn column1 = dataGridView1.Columns[2];
            column1.Width = 250;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*if (!AyudaExtra.esStringConLetraONumero(textBox1.Text.Trim()))
            {
                MessageBox.Show("Ingrese un nombre válido");
                return;
            }*/
            String query = "SELECT publicacion_codigo as 'ID', publicacion_descripcion as 'Nombre espectáculo', publicacion_fecha as 'Fecha' FROM SQLEADOS.Publicacion JOIN SQLEADOS.Empresa ON publicacion_usuario_responsable = empresa_usuario WHERE empresa_razon_social LIKE '" + empresa + "' AND publicacion_descripcion LIKE '%" + textBox1.Text.Trim() + "%' AND publicacion_estado LIKE 'Finalizada' AND publicacion_codigo NOT IN (SELECT factura_publicacion FROM SQLEADOS.Factura)";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No existe ninguna publicación con ese nombre");
                return;
            }
            dataGridView1.DataSource = dt;
            cargarGrilla();
        }

        //ABRIR UNA PUBLICACION EN ESPECÍFICO PARA GENERAR SU FACTURA
        private void button1_Click(object sender, EventArgs e)
        {
            factura.GenerarFacturaAEstaPublicacion(dataGridView1.SelectedCells[0].Value.ToString());
            factura.Show();
            em.Close();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Limpiar

            textBox1.Text = "";
        }
    }
}
