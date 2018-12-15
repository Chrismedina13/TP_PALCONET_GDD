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
    public partial class GenerarFacturaDeComisiones : Form
    {
        Explorador exx;
        public GenerarFacturaDeComisiones(Explorador ex)
        {
            exx = ex;
            InitializeComponent();
        }

        private void botonvolver_Click(object sender, EventArgs e)
        {
            exx.Show();
            this.Close();
        }

        public void GenerarFacturaAEstaPublicacion(String nombrePublicacion) {
            String datosFactura = "SELECT ub.ubiXpubli_Ubicacion as 'ID ubicación', CONVERT(varchar(10),u.ubicacion_asiento) +'-'+ CONVERT(varchar(10),u.ubicacion_fila)  as 'Asiento', u.ubicacion_Tipo_Descripcion as 'Sector', c.compra_fecha as 'Fecha de venta', ub.ubiXpubli_precio as 'Precio', (ub.ubiXpubli_precio*gr.grado_comision)/100 as 'Comísión' FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = p.publicacion_codigo JOIN SQLEADOS.ubicacionesXPublicidadComprada ubx ON ubxpcom_ubicacionXPublicidad = ub.ubiXpubli_ID JOIN SQLEADOS.Compra c ON c.compra_id = ubx.ubxpcomp_compra JOIN SQLEADOS.GradoPrioridad gr ON gr.grado_id = p.publicacion_grado JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ub.ubiXpubli_Ubicacion WHERE p.publicacion_descripcion LIKE '"+nombrePublicacion+"'";
            String datosPrincipalesFactura = "SELECT p.publicacion_codigo as 'ID publicación', p.publicacion_descripcion as 'Nombre publicación', gr.grado_nombre as 'Grado de prioridad', gr.grado_comision as 'porcentaje de comisión' FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = p.publicacion_codigo JOIN SQLEADOS.ubicacionesXPublicidadComprada ubx ON ubxpcom_ubicacionXPublicidad = ub.ubiXpubli_ID JOIN SQLEADOS.Compra c ON c.compra_id = ubx.ubxpcomp_compra JOIN SQLEADOS.GradoPrioridad gr ON gr.grado_id = p.publicacion_grado JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ub.ubiXpubli_Ubicacion WHERE p.publicacion_descripcion LIKE '"+nombrePublicacion+"'";
            String numeroFactura = "SELECT MAX(factura_nro)+1 as 'Nro Factura' FROM SQLEADOS.Factura";

            DataTable dtPrincipal = DBConsulta.AbrirCerrarObtenerConsulta(datosPrincipalesFactura);
            DataTable nroFactura = DBConsulta.AbrirCerrarObtenerConsulta(numeroFactura);
            DataTable datosDeFacturas = DBConsulta.AbrirCerrarObtenerConsulta(datosFactura);
            dataGridView1.DataSource = datosDeFacturas;

            labelNroFactura.Text = nroFactura.Rows[0][0].ToString();
            labelNroPublicacion.Text = dtPrincipal.Rows[0][0].ToString();
            labelGradoPublicacion.Text = dtPrincipal.Rows[2][0].ToString();
            labelComision.Text = dtPrincipal.Rows[3][0].ToString();
            labelNombrePublicacion.Text = dtPrincipal.Rows[1][0].ToString();

            int cantidadTotal = 0;
            for(int i = 0; i < datosDeFacturas.Rows.Count; i++) {
                cantidadTotal += Convert.ToInt32(datosDeFacturas.Rows[i][5].ToString());
            }

            labelTotalACobrar.Text = cantidadTotal.ToString();
        }

        public void entrar()
        {
            labelNroFactura.Text = "";
            labelNroPublicacion.Text = "";
            labelGradoPublicacion.Text = "";
            labelComision.Text = "";
            labelNombrePublicacion.Text = "";

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void GenerarFacturaDeComisiones_Load(object sender, EventArgs e)
        {

        }
    }
}
