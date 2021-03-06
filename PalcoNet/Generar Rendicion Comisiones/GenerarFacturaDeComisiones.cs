﻿using System;
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

        public void GenerarFacturaAEstaPublicacion(String codigoPublicacion) 
        {

           String datosFactura = "SELECT DISTINCT ubxpcomp_id as 'ID Compra', CONVERT(varchar(10),u.ubicacion_asiento) +'-'+ CONVERT(varchar(10),u.ubicacion_fila)  as 'Asiento', u.ubicacion_Tipo_Descripcion as 'Sector', c.compra_fecha as 'Fecha de venta', '$ ' + CONVERT(varchar(20),ub.ubiXpubli_precio) as 'Precio', '$ ' + CONVERT(varchar(20),(ub.ubiXpubli_precio*gr.grado_comision)/100) as 'Comísión' FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = p.publicacion_codigo JOIN SQLEADOS.ubicacionesXPublicidadComprada ubx ON ubxpcom_ubicacionXPublicidad = ub.ubiXpubli_ID JOIN SQLEADOS.Compra c ON c.compra_id = ubx.ubxpcomp_compra JOIN SQLEADOS.GradoPrioridad gr ON gr.grado_id = p.publicacion_grado JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ub.ubiXpubli_Ubicacion WHERE p.publicacion_codigo = " + codigoPublicacion + " AND ub.ubiXpubli_ID NOT IN (SELECT i.item_factura_ubicacion FROM SQLEADOS.ItemFactura i JOIN SQLEADOS.Factura f ON f.factura_nro = i.item_factura_nro AND f.factura_publicacion = p.publicacion_codigo)";
       //     String datosFactura = "SELECT DISTINCT ubxpcomp_id as 'ID Compra', CONVERT(varchar(10),u.ubicacion_asiento) +'-'+ CONVERT(varchar(10),u.ubicacion_fila)  as 'Asiento', u.ubicacion_Tipo_Descripcion as 'Sector', c.compra_fecha as 'Fecha de venta', '$ ' + CONVERT(varchar(20),ub.ubiXpubli_precio) as 'Precio', '$ ' + CONVERT(varchar(20),(ub.ubiXpubli_precio*gr.grado_comision)/100) as 'Comísión' FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = p.publicacion_codigo JOIN SQLEADOS.ubicacionesXPublicidadComprada ubx ON ubxpcom_ubicacionXPublicidad = ub.ubiXpubli_ID JOIN SQLEADOS.Compra c ON c.compra_id = ubx.ubxpcomp_compra JOIN SQLEADOS.GradoPrioridad gr ON gr.grado_id = p.publicacion_grado JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ub.ubiXpubli_Ubicacion WHERE p.publicacion_codigo = " + codigoPublicacion + " AND ub.ubiXpubli_ID NOT IN (SELECT i.item_factura_ubicacion FROM SQLEADOS.ItemFactura i JOIN SQLEADOS.Factura f ON f.factura_nro = i.item_factura_nro AND f.factura_publicacion = p.publicacion_codigo)";

            
            String datosPrincipalesFactura = "SELECT DISTINCT p.publicacion_codigo as 'ID publicación', p.publicacion_descripcion as 'Nombre publicación', gr.grado_nombre as 'Grado de prioridad', gr.grado_comision as 'porcentaje de comisión', e.empresa_razon_social as 'Nombre empresa', e.empresa_cuit as 'CUIT' FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = p.publicacion_codigo JOIN SQLEADOS.ubicacionesXPublicidadComprada ubx ON ubxpcom_ubicacionXPublicidad = ub.ubiXpubli_ID JOIN SQLEADOS.Compra c ON c.compra_id = ubx.ubxpcomp_compra JOIN SQLEADOS.GradoPrioridad gr ON gr.grado_id = p.publicacion_grado JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ub.ubiXpubli_Ubicacion JOIN SQLEADOS.Empresa e ON e.empresa_usuario = p.publicacion_usuario_responsable WHERE p.publicacion_codigo = " + codigoPublicacion;
            String numeroFactura = "SELECT MAX(factura_nro)+1 as 'Nro Factura' FROM SQLEADOS.Factura";
            String valorTotalPublicacion = "SELECT DISTINCT (ub.ubiXpubli_precio*gr.grado_comision)/100 FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = p.publicacion_codigo JOIN SQLEADOS.ubicacionesXPublicidadComprada ubx ON ubxpcom_ubicacionXPublicidad = ub.ubiXpubli_ID JOIN SQLEADOS.Compra c ON c.compra_id = ubx.ubxpcomp_compra JOIN SQLEADOS.GradoPrioridad gr ON gr.grado_id = p.publicacion_grado JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ub.ubiXpubli_Ubicacion WHERE p.publicacion_codigo = " + codigoPublicacion + " AND ub.ubiXpubli_ID NOT IN (SELECT i.item_factura_ubicacion FROM SQLEADOS.ItemFactura i JOIN SQLEADOS.Factura f ON f.factura_nro = i.item_factura_nro AND f.factura_publicacion = p.publicacion_codigo)";
            DataTable dtPrincipal = DBConsulta.AbrirCerrarObtenerConsulta(datosPrincipalesFactura);
            DataTable nroFactura = DBConsulta.AbrirCerrarObtenerConsulta(numeroFactura);
            DataTable datosDeFacturas = DBConsulta.AbrirCerrarObtenerConsulta(datosFactura);
            DataTable valorDeComisiones = DBConsulta.AbrirCerrarObtenerConsulta(valorTotalPublicacion);
            
            //PLANILLA DE LA FACTURA
            dataGridView1.DataSource = datosDeFacturas;

            //RELLENO DE LABELS
            labelNroFactura.Text = nroFactura.Rows[0][0].ToString();
            labelNroPublicacion.Text = dtPrincipal.Rows[0][0].ToString();
            labelGradoPublicacion.Text = dtPrincipal.Rows[0][2].ToString();
            labelComision.Text = dtPrincipal.Rows[0][3].ToString();
            labelNombrePublicacion.Text = dtPrincipal.Rows[0][1].ToString();
            labelEmpresa.Text = dtPrincipal.Rows[0][4].ToString();
            labelCUIT.Text = dtPrincipal.Rows[0][5].ToString();

            int i = 0;
            while (i < datosDeFacturas.Rows.Count) {
                String cadena = datosDeFacturas.Rows[i][5].ToString().Substring(2, datosDeFacturas.Rows[i][5].ToString().Length - 2);
                cadena = cadena.Replace(".", ",");
                cantidadTotal += Convert.ToDouble(cadena);
                i++;
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
            DateTime hoy = ArchivoDeConfiguracion.fechaReferencia;
            String montoTotal = cantidadTotal.ToString();
            montoTotal = montoTotal.Replace(",", ".");
            String guardarNuevaFactura = "insert into [SQLEADOS].Factura (factura_publicacion, factura_nro, factura_empresa_cuit, factura_empresa_razon_social, factura_fecha, factura_total, factura_forma_de_pago) Values (" + labelNroPublicacion.Text + ", " + labelNroFactura.Text + ", '" + labelCUIT.Text + "', '" + labelEmpresa.Text + "', '" + AyudaExtra.stringAFormatoFechaSQLDateSinHora(hoy.ToString()) + "', " + montoTotal + ", 'Tarjeta')";
            DBConsulta.AbrirCerrarModificarDB(guardarNuevaFactura);

            int i = 0;
            while (i < dataGridView1.Rows.Count)
            {
                //CREA ITEM FACTURA POR CADA COMISIÓN DE CADA COMPRA

           //     String query = "SELECT DISTINCT (ub.ubiXpubli_precio*gr.grado_comision)/100 FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Publicacion = p.publicacion_codigo JOIN SQLEADOS.ubicacionesXPublicidadComprada ubx ON ubxpcom_ubicacionXPublicidad = ub.ubiXpubli_ID JOIN SQLEADOS.Compra c ON c.compra_id = ubx.ubxpcomp_compra JOIN SQLEADOS.GradoPrioridad gr ON gr.grado_id = p.publicacion_grado JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ub.ubiXpubli_Ubicacion WHERE p.publicacion_codigo = " + labelNroPublicacion.Text + " AND ub.ubiXpubli_ID NOT IN (SELECT i.item_factura_ubicacion FROM SQLEADOS.ItemFactura i JOIN SQLEADOS.Factura f ON f.factura_nro = i.item_factura_nro AND f.factura_publicacion = p.publicacion_codigo)";

           //     DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
                String cadena = dataGridView1.Rows[i].Cells[5].Value.ToString().Substring(2, dataGridView1.Rows[i].Cells[5].Value.ToString().Length - 2);
                cadena = cadena.Replace(".", ",");
                double cant = 0;
                cant = Convert.ToDouble(cadena);

                //AQUI EL MONTO TOTAL EN REALIDAD ES EL MONTO PARTICULAR DE CADA COMISION
                montoTotal = (cant.ToString()).Replace(",", ".");

                String ubicacion = dataGridView1.Rows[i].Cells[0].Value.ToString();

                String guardarDatosComisiones = "insert into [SQLEADOS].ItemFactura (item_factura_nro, item_factura_monto, item_factura_descripcion, item_factura_cantidad, item_factura_ubicacion) Values(" + labelNroFactura.Text + ", " + montoTotal + ", 'Precio de comisión', 1, " + ubicacion + ")";
                DBConsulta.AbrirCerrarModificarDB(guardarDatosComisiones);

                i++;
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
