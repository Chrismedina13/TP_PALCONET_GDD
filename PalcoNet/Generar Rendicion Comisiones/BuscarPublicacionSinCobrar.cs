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
            String query = "SELECT DISTINCT publicacion_codigo as 'ID', publicacion_descripcion as 'Nombre espectáculo', publicacion_fecha as 'Fecha' FROM  SQLEADOS.Publicacion p JOIN SQLEADOS.Empresa E on p.publicacion_usuario_responsable = e.empresa_usuario	JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = publicacion_codigo	WHERE empresa_razon_social LIKE '" + empresa + "' AND publicacion_estado LIKE 'Finalizad%' AND (publicacion_codigo NOT IN (Select factura_publicacion FROM SQLEADOS.Factura)) UNION SELECT DISTINCT publicacion_codigo as 'ID', publicacion_descripcion as 'Nombre espectáculo', publicacion_fecha as 'Fecha' FROM  SQLEADOS.Publicacion p JOIN SQLEADOS.Empresa E on p.publicacion_usuario_responsable = e.empresa_usuario JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = publicacion_codigo WHERE empresa_razon_social LIKE '" + empresa + "' AND publicacion_estado LIKE 'Finalizad%' AND publicacion_codigo IN (Select factura_publicacion FROM SQLEADOS.Factura JOIN SQLEADOS.ItemFactura i ON i.item_factura_nro = factura_nro AND i.item_factura_ubicacion != ub.ubiXpubli_ID)";
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
            String query = "SELECT DISTINCT publicacion_codigo as 'ID', publicacion_descripcion as 'Nombre espectáculo', publicacion_fecha as 'Fecha' FROM  SQLEADOS.Publicacion p JOIN SQLEADOS.Empresa E on p.publicacion_usuario_responsable = e.empresa_usuario	JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = publicacion_codigo	WHERE empresa_razon_social LIKE '" + empresa + "' AND publicacion_descripcion LIKE '%" + textBox1.Text.Trim() +"%' AND publicacion_estado LIKE 'Finalizad%' AND (publicacion_codigo NOT IN (Select factura_publicacion FROM SQLEADOS.Factura)) UNION SELECT DISTINCT publicacion_codigo as 'ID', publicacion_descripcion as 'Nombre espectáculo', publicacion_fecha as 'Fecha' FROM  SQLEADOS.Publicacion p JOIN SQLEADOS.Empresa E on p.publicacion_usuario_responsable = e.empresa_usuario JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = publicacion_codigo WHERE empresa_razon_social LIKE '" + empresa + "' AND publicacion_descripcion LIKE '%" + textBox1.Text.Trim()+ "%' AND publicacion_estado LIKE 'Finalizad%' AND publicacion_codigo IN (Select factura_publicacion FROM SQLEADOS.Factura JOIN SQLEADOS.ItemFactura i ON i.item_factura_nro = factura_nro AND i.item_factura_ubicacion != ub.ubiXpubli_ID)";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No existe ninguna publicación con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
