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
        bool hayDatos;
        double cantidadTotal;
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
            String datosFactura = "SELECT DISTINCT ub.ubiXpubli_Ubicacion as 'ID ubicación', CONVERT(varchar(10),u.ubicacion_asiento) +'-'+ CONVERT(varchar(10),u.ubicacion_fila)  as 'Asiento', u.ubicacion_Tipo_Descripcion as 'Sector', c.compra_fecha as 'Fecha de venta', '$ ' + CONVERT(varchar(20),ub.ubiXpubli_precio) as 'Precio', '$ ' + CONVERT(varchar(20),(ub.ubiXpubli_precio*gr.grado_comision)/100) as 'Comísión' FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = p.publicacion_codigo JOIN SQLEADOS.ubicacionesXPublicidadComprada ubx ON ubxpcom_ubicacionXPublicidad = ub.ubiXpubli_ID JOIN SQLEADOS.Compra c ON c.compra_id = ubx.ubxpcomp_compra JOIN SQLEADOS.GradoPrioridad gr ON gr.grado_id = p.publicacion_grado JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ub.ubiXpubli_Ubicacion WHERE p.publicacion_codigo = " + nombrePublicacion;
            String datosPrincipalesFactura = "SELECT DISTINCT p.publicacion_codigo as 'ID publicación', p.publicacion_descripcion as 'Nombre publicación', gr.grado_nombre as 'Grado de prioridad', gr.grado_comision as 'porcentaje de comisión', e.empresa_razon_social as 'Nombre empresa', e.empresa_cuit as 'CUIT' FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = p.publicacion_codigo JOIN SQLEADOS.ubicacionesXPublicidadComprada ubx ON ubxpcom_ubicacionXPublicidad = ub.ubiXpubli_ID JOIN SQLEADOS.Compra c ON c.compra_id = ubx.ubxpcomp_compra JOIN SQLEADOS.GradoPrioridad gr ON gr.grado_id = p.publicacion_grado JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ub.ubiXpubli_Ubicacion JOIN SQLEADOS.Empresa e ON e.empresa_usuario = p.publicacion_usuario_responsable WHERE p.publicacion_codigo = " + nombrePublicacion;
            String numeroFactura = "SELECT MAX(factura_nro)+1 as 'Nro Factura' FROM SQLEADOS.Factura";
            String valorTotalPublicacion = "SELECT DISTINCT (ub.ubiXpubli_precio*gr.grado_comision)/100 FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = p.publicacion_codigo JOIN SQLEADOS.ubicacionesXPublicidadComprada ubx ON ubxpcom_ubicacionXPublicidad = ub.ubiXpubli_ID JOIN SQLEADOS.Compra c ON c.compra_id = ubx.ubxpcomp_compra JOIN SQLEADOS.GradoPrioridad gr ON gr.grado_id = p.publicacion_grado JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ub.ubiXpubli_Ubicacion WHERE p.publicacion_codigo = " + nombrePublicacion;
            DataTable dtPrincipal = DBConsulta.AbrirCerrarObtenerConsulta(datosPrincipalesFactura);
            DataTable nroFactura = DBConsulta.AbrirCerrarObtenerConsulta(numeroFactura);
            DataTable datosDeFacturas = DBConsulta.AbrirCerrarObtenerConsulta(datosFactura);
            DataTable valorDeComisiones = DBConsulta.AbrirCerrarObtenerConsulta(valorTotalPublicacion);
            dataGridView1.DataSource = datosDeFacturas;

            labelNroFactura.Text = nroFactura.Rows[0][0].ToString();
            labelNroPublicacion.Text = dtPrincipal.Rows[0][0].ToString();
            labelGradoPublicacion.Text = dtPrincipal.Rows[0][2].ToString();
            labelComision.Text = dtPrincipal.Rows[0][3].ToString();
            labelNombrePublicacion.Text = dtPrincipal.Rows[0][1].ToString();
            labelEmpresa.Text = dtPrincipal.Rows[0][4].ToString();
            labelCUIT.Text = dtPrincipal.Rows[0][5].ToString();

            
            for(int i = 0; i < datosDeFacturas.Rows.Count; i++) {
                cantidadTotal += Convert.ToDouble(valorDeComisiones.Rows[i][0].ToString());
            }

            labelTotalACobrar.Text = "$ " +cantidadTotal.ToString();

            hayDatos = true;
        }

        public void entrar()
        {
            hayDatos = false;

            labelNroFactura.Text = "";
            labelNroPublicacion.Text = "";
            labelGradoPublicacion.Text = "";
            labelComision.Text = "";
            labelNombrePublicacion.Text = "";
            labelEmpresa.Text = "";
            labelCUIT.Text = "";
            cantidadTotal = 0;
            labelTotalACobrar.Text = "";
            DataTable dt = new DataTable();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void GenerarFacturaDeComisiones_Load(object sender, EventArgs e)
        {

        }

        private void buttonGenerarFactura_Click(object sender, EventArgs e)
        {
            if (!hayDatos) {
                MessageBox.Show("No hay nada puesto en la grilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
       //     String buscarIDPublicacion = "SELECT publicacion_codigo FROM SQLEADOS.Publicacion where publicacion_codigo = " + labelNroPublicacion;
       //     String idPubl = DBConsulta.AbrirCerrarObtenerConsulta(buscarIDPublicacion).Rows[0][0].ToString();
            DateTime hoy = DateTime.Today;
            String montoTotal = cantidadTotal.ToString();
            montoTotal = montoTotal.Replace(",", ".");
            String guardarNuevaFactura = "insert into [SQLEADOS].Factura (factura_publicacion, factura_nro, factura_empresa_cuit, factura_empresa_razon_social, factura_fecha, factura_total, factura_forma_de_pago) Values (" + labelNroPublicacion.Text + ", " + labelNroFactura.Text + ", '" + labelCUIT.Text + "', '" + labelEmpresa.Text + "', '" + AyudaExtra.stringAFormatoFechaSQLDateSinHora(hoy.ToString()) + "', " + montoTotal + ", 'Tarjeta')";
            DBConsulta.AbrirCerrarModificarDB(guardarNuevaFactura);
            for(int i = 0; i < dataGridView1.Rows.Count; i++) {
                //CREA ITEM FACTURA POR CADA COMISIÓN DE CADA COMPRA
                String query = "SELECT DISTINCT (ub.ubiXpubli_precio*gr.grado_comision)/100 FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = p.publicacion_codigo JOIN SQLEADOS.ubicacionesXPublicidadComprada ubx ON ubxpcom_ubicacionXPublicidad = ub.ubiXpubli_ID JOIN SQLEADOS.Compra c ON c.compra_id = ubx.ubxpcomp_compra JOIN SQLEADOS.GradoPrioridad gr ON gr.grado_id = p.publicacion_grado JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ub.ubiXpubli_Ubicacion WHERE p.publicacion_codigo = " + labelNroPublicacion.Text;
                DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
                double cant = Convert.ToDouble(dt.Rows[i][0].ToString());
                montoTotal = (cant.ToString()).Replace(",", ".");
                String guardarDatosComisiones = "insert into [SQLEADOS].ItemFactura (item_factura_nro, item_factura_monto, item_factura_descripcion, item_factura_cantidad) Values(" + labelNroFactura.Text + ", " + montoTotal + ", 'Precio de comisión', 1)";
                DBConsulta.AbrirCerrarModificarDB(guardarDatosComisiones);
            }
            MessageBox.Show("Se ha generado la factura para la empresa seleccionada");

            //LIMPIO TODO
            entrar();
        }

        //BUSCAR EMPRESA
        private void button1_Click(object sender, EventArgs e)
        {
            BuscarEmpresa em = new BuscarEmpresa(this);
            em.Show();
        }
    }
}
