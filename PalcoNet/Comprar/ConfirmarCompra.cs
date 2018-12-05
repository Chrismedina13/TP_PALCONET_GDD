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

namespace PalcoNet.Comprar
{
    public partial class ConfirmarCompra : Form
    {
        ComprarPrincipal aVolver;
        String Especta;
        String asiento;
        String fila;
        String tipoUbicacion;
        String fecha;
        String categoria;
        String precio;
        int usuarioID;
        DataTable table = new DataTable();
        DataGridViewRow dts = new DataGridViewRow();
        List<String> IDs = new List<String>();
        public ConfirmarCompra(ComprarPrincipal ventanaAVolver, List<String> IDCargados, int user)
        {
            aVolver = ventanaAVolver;
            InitializeComponent();
            usuarioID = user;
            IDs = IDCargados;
        }

        private void CantidadAComprar_Load(object sender, EventArgs e)
        {
            String query = "SELECT ux.ubiXpubli_ID as 'ID', p.publicacion_descripcion as 'Espectáculo', u.ubicacion_asiento as 'Asiento', u.ubicacion_fila as 'Fila', u.ubicacion_Tipo_Descripcion as 'Tipo ubicación',	r.rubro_descripcion as 'Categoría', p.publicacion_fecha_venc as 'Fecha de evento', ux.ubiXpubli_precio as 'Precio'	FROM SQLEADOS.ubicacionXpublicacion ux	JOIN SQLEADOS.Publicacion p ON p.publicacion_codigo = ux.ubiXpubli_Publicacion	JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ux.ubiXpubli_Ubicacion JOIN SQLEADOS.Rubro r ON r.rubro_id = p.publicacion_rubro ";
            String agregado = " WHERE (";
            int i;
            for (i = 0; i < IDs.Count - 1; i++)
            {
                agregado += "ux.ubiXpubli_ID = " + IDs[i] +" OR ";
            }
            agregado += "ux.ubiXpubli_ID = " + IDs[i] + ")";
            query += agregado;
            dataGridView1.DataSource =  DBConsulta.obtenerConsultaEspecifica(query);
            DataGridViewColumn column = dataGridView1.Columns[1];
            column.Width = 250;
            
            int importeTotal= 0;
            for(i = 0; i < dataGridView1.RowCount; i++) {
                importeTotal += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value.ToString());
            }

            labelImporte.Text = "$ "+ importeTotal.ToString();
            
            
        }
        //BOTON PARA REALIZAR LA COMPRA Y CONFIRMARLA
        private void button1_Click(object sender, EventArgs e)
        {
            if (elUserTieneTarjeta(usuarioID))
            {
                cargarDatosDeCompra();
            }
            else {
                MessageBox.Show("No tiene un nro de tarjeta asignada.\nPor favor, ingrese una a continuación");
                ConfirmarCompra b = this;
                AgregarTarjeta ag = new AgregarTarjeta(usuarioID, b);
                ag.Show();
                cargarDatosDeCompra();
            }
        }

        public DataTable queryObtenerPKsDatosCliente()
        {
            String queryObtenerPKsDatosCliente = "SELECT cliente_tipo_documento as 'TIPO DOCUMENTO', cliente_numero_documento as 'NUMERO DOCUMENTO' FROM SQLEADOS.Cliente where cliente_usuario = " + usuarioID;
            return DBConsulta.obtenerConsultaEspecifica(queryObtenerPKsDatosCliente);
        }

        public void queryComprar() {
            DataTable datosPKCliente = queryObtenerPKsDatosCliente();
            String tipoDoc = datosPKCliente.Rows[0]["TIPO DOCUMENTO"].ToString();
            String nroDoc = datosPKCliente.Rows[0]["NUMERO DOCUMENTO"].ToString();
            int cantidadUbicacionesCompradas = IDs.Count;
            String queryCompraInsert = "INSERT INTO SQLEADOS.Compra( compra_cliente_tipo_documento , compra_cliente_numero_documento,	compra_fecha,compra_cantidad,compra_precio,	compra_forma_de_pago) VALUES ";
            queryCompraInsert += " ('" + tipoDoc + "', " + nroDoc + ", GETDATE(), " + cantidadUbicacionesCompradas + ", " + labelImporte.Text + ", 'Tarjeta')";

            DBConsulta.realizarUpdateConQuery(queryCompraInsert);
        }

        public void cargarDatosDeCompra() {
            queryComprar();
            insertarUbicacionXPublCompradoYActualizarCompra();
        }

        private void obtenerValorPuntajeCompra(int indice) {
            String queryObtenerPuntaje = "SELECT p.publicacion_puntaje_venta FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion u ON u.ubiXpubli_Publicacion = p.publicacion_codigo WHERE u.ubiXpubli_ID = " + dataGridView1.Rows[indice].Cells[0].Value.ToString();
            int puntaje  = Convert.ToInt32(DBConsulta.obtenerConsultaEspecifica(queryObtenerPuntaje).ToString());
            generarPuntosACliente(puntaje);
        }

        private void insertarUbicacionXPublCompradoYActualizarCompra() {
            int i = 0;
            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                String queryUBIXPUBLCOMPRADO = "INSERT INTO [SQLEADOS].ubicacionesXPublicidadComprada (ubxpcomp_compra, ubxpcom_ubicacionXPublicidad) SELECT DISTINCT c.compra_id, " + dataGridView1.Rows[i].Cells[0].Value.ToString() + " FROM SQLEADOS.Compra c  where c.compra_id = (Select TOP 1 compra_id FROM SQLEADOS.Compra order by compra_id DESC)";
                DBConsulta.realizarUpdateConQuery(queryUBIXPUBLCOMPRADO);

                String queryActualizarCompra = "UPDATE c SET c.compra_ubiXpubli = u.ubxpcomp_id FROM SQLEADOS.Compra c INNER JOIN SQLEADOS.ubicacionesXPublicidadComprada u ON u.ubxpcomp_compra = c.compra_id WHERE c.compra_id = (Select TOP 1 compra_id FROM SQLEADOS.Compra order by compra_id DESC)";
                DBConsulta.realizarUpdateConQuery(queryActualizarCompra);

            }
        }

        private void generarPuntosACliente(int puntaje)
        {

            DataTable datosPKCliente = queryObtenerPKsDatosCliente();
            String tipoDoc = datosPKCliente.Rows[0]["TIPO DOCUMENTO"].ToString();
            String nroDoc = datosPKCliente.Rows[0]["NUMERO DOCUMENTO"].ToString();

            String queryUpdatePuntaje = "UPDATE SQLEADOS.puntaje SET punt_puntaje += " + puntaje + " WHERE punt_cliente_numero_documento = "+nroDoc+" AND punt_cliente_tipo_documento LIKE '" + tipoDoc + "' ";

            DBConsulta.realizarUpdateConQuery(queryUpdatePuntaje);
        }

        private bool elUserTieneTarjeta(int user) {
            String query = "SELECT cliente_datos_tarjeta AS 'DATOS', cliente_usuario FROM SQLEADOS.Cliente WHERE cliente_usuario = " + usuarioID;
            DataTable dt = DBConsulta.obtenerConsultaEspecifica(query);
            var cellValue = dt.Rows[0][0];
            return cellValue == null;
        }

        //BOTON VOLVER, SOLO VUELVE A LA ANTERIOR VISTA
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Cancela la compra, quita todos los items de la lista IDCargada
        private void button2_Click(object sender, EventArgs e)
        {
            aVolver.vaciarIDCargada();
            this.Close();
        }
    }
}
