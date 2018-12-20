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
    public partial class ComprarPrincipal : Form1
    {
        private int paginaActual;
        private int ultimaHoja;
        private int totalVistoPorPagina = 10;
        private bool fueCargadaCategoria, fueCargadaPublicacion, fueCargadaTipoUbicaciones;
        private int userID;
        private DateTime f1, f2;
        DateTime fecha1;
        DateTime fecha2;
        List<String> IDCargados;
        Explorador exx;
        public ComprarPrincipal(int usuario, Explorador ex)
        {
            exx = ex;
    //        publicacionID = publicacion;
            userID = usuario;

            IDCargados = new List<String>();
            fecha1 = DateTime.Today;
            fecha2 = DateTime.Today;
            fecha2.AddDays(1);
            f1 = fecha1;
            f2 = fecha2;
            paginaActual = 1;
            InitializeComponent();
            fueCargadaTipoUbicaciones = false;
            fueCargadaCategoria = false;
            fueCargadaPublicacion = false;
            labelItemXHoja.Text = "Items por hoja \n" +totalVistoPorPagina.ToString();
            
        }

        private void Comprar_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(f1.Year, f1.Month, f1.Day);
            dateTimePicker2.Value = new DateTime(f2.Year, f2.Month, f2.Day);
            
       //     String res = DBConsulta.obtenerTotalUbicacionDePublicacion(publicacionID).Rows[0][0].ToString();
      //      int cantidad = Convert.ToInt32(res);
      //      ultimaHoja = (cantidad / totalVistoPorPagina) + 1;
     //       configuracionGrilla(DBConsulta.obtenerUbicacionDePublicacion(publicacionID, 1, totalVistoPorPagina)); 
        }

        private void configuracionGrilla(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado publicaciones con estos criterios");
            }
            else {
                String espectaculo = dt.Rows[0]["Espectáculo"].ToString();  //0
                String Asiento = dt.Rows[0]["Asiento"].ToString();          //1
                String Fila = dt.Rows[0]["Fila"].ToString();                //2
                String Precio = dt.Rows[0]["Precio"].ToString();            //3
                String fecha = dt.Rows[0]["Fecha de evento"].ToString();    //4
                String Categoria = dt.Rows[0]["Categoría"].ToString();      //5


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
                DataGridViewColumn column = dataGridView1.Columns[1];
                column.Width = 250;
                DataGridViewColumn column1 = dataGridView1.Columns[2];
                column1.Width = 50;
                DataGridViewColumn column2 = dataGridView1.Columns[3];
                column2.Width = 50;
                DataGridViewColumn column3 = dataGridView1.Columns[4];
                column3.Width = 80;
                DataGridViewColumn column4 = dataGridView1.Columns[5];
                column4.Width = 100;
                DataGridViewColumn column5 = dataGridView1.Columns[6];
                column4.Width = 90;

                labelPaginas.Text = paginaActual.ToString() + " de " + ultimaHoja.ToString();
            }
            
            return;
        }

        private void buttonPrimeraHoja_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count != 0) {
                paginaActual = 1;
                DBConsulta.conexionAbrir();
                String comando = cargar10QuerysParaNPagina();
                comando += " " + ordenamiento();
                obtenerResultados(comando);
                DBConsulta.conexionCerrar();
                //       configuracionGrilla(DBConsulta.obtenerUbicacionDePublicacion(publicacionID, paginaActual, totalVistoPorPagina));
                labelPaginas.Text = paginaActual.ToString() + " de " + ultimaHoja.ToString();
            }
        }

        private void botonAnterior_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0) {
                if (paginaActual > 1)
                {
                    paginaActual -= 1;
                    DBConsulta.conexionAbrir();
                    String comando = cargar10QuerysParaNPagina();
                    comando += " " + ordenamiento();
                    obtenerResultados(comando);
                    DBConsulta.conexionCerrar();
                    //           configuracionGrilla(DBConsulta.obtenerUbicacionDePublicacion(publicacionID, paginaActual, totalVistoPorPagina));
                    labelPaginas.Text = paginaActual.ToString() + " de " + ultimaHoja.ToString();
                }
            }
        }

        private void botonsiguiente_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                if (paginaActual < ultimaHoja)
                {
                    paginaActual += 1;
                    DBConsulta.conexionAbrir();
                    String comando = cargar10QuerysParaNPagina();
                    comando += " " + ordenamiento();
                    obtenerResultados(comando);
                    DBConsulta.conexionCerrar();
                    //          configuracionGrilla(DBConsulta.obtenerUbicacionDePublicacion(publicacionID, paginaActual, totalVistoPorPagina));
                    labelPaginas.Text = paginaActual.ToString() + " de " + ultimaHoja.ToString();
                }
            }
        }

        private void buttonUltimaHoja_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                paginaActual = ultimaHoja;
                DBConsulta.conexionAbrir();
                String comando = cargar10QuerysParaNPagina();
                comando += " " + ordenamiento();

                obtenerResultados(comando);
                DBConsulta.conexionCerrar();
                //      configuracionGrilla(DBConsulta.obtenerUbicacionDePublicacion(publicacionID, paginaActual, totalVistoPorPagina));
                labelPaginas.Text = paginaActual.ToString() + " de " + ultimaHoja.ToString();
            }
        }

        public void rellenarCategoríasSeleccionadas(String categoriasSelecionadas) {
            labelCategoria.Text = categoriasSelecionadas;
            fueCargadaCategoria = true;
        }

        public void rellenarTiposSeleccionadas(String tiposSeleccionados)
        {
            labelTipoUbicaciones.Text = tiposSeleccionados;
            fueCargadaTipoUbicaciones = true;
        }

        private String crearComandoParaCategoria() {
            int separardor;
            bool hayMasDe1 = false;
            String listaCategorias = labelCategoria.Text;
            String substringPrimero, substringResto;
            String cadena;
            cadena = " AND ( ";
            while (listaCategorias.Contains(";"))
            {
                separardor = listaCategorias.IndexOf(";");
                substringPrimero = listaCategorias.Substring(0, separardor);
                if (separardor+1 != listaCategorias.Length)
                {
                    substringResto = listaCategorias.Substring(separardor+1, listaCategorias.Length - separardor-1);
                    
                    listaCategorias = substringResto;
                }
                else {
                    listaCategorias = "";
                }
                
                if (hayMasDe1)
                {
                    cadena += " OR r.rubro_descripcion LIKE '" + substringPrimero + "' ";
                }
                else
                {
                    cadena += " r.rubro_descripcion LIKE '" + substringPrimero + "' ";
                    hayMasDe1 = true;
                }
            }
            cadena += ") ";
            return cadena;
        }

        private String crearComandoParaTipoUbicacion() {
            int separardor;
            bool hayMasDe1 = false;
            String listaTipos = labelTipoUbicaciones.Text;
            String substringPrimero, substringResto;
            String cadena;
            cadena = " AND ( ";
            while (listaTipos.Contains(";"))
            {
                separardor = listaTipos.IndexOf(";");
                substringPrimero = listaTipos.Substring(0, separardor);
                if (separardor + 1 != listaTipos.Length)
                {
                    substringResto = listaTipos.Substring(separardor + 1, listaTipos.Length - separardor - 1);
                    listaTipos = substringResto;
                }
                else {
                    listaTipos = "";
                }
                
                if (hayMasDe1)
                {
                    cadena += " OR u.ubicacion_Tipo_Descripcion LIKE '" + substringPrimero + "' ";
                }
                else
                {
                    cadena += " u.ubicacion_Tipo_Descripcion LIKE '" + substringPrimero + "' ";
                    hayMasDe1 = true;
                }
            }
            cadena += ") ";
            return cadena;
        }

        private String cargarPrimeros10Querys() {
            String queryPrincipal = "SELECT "+ conTop(totalVistoPorPagina) + " ";
            queryPrincipal += "up.ubiXpubli_ID as 'ID',  p.publicacion_descripcion as 'Espectáculo' ,ubicacion_asiento as 'Asiento', ubicacion_fila as 'Fila', u.ubicacion_Tipo_Descripcion as 'Tipo ubicación', ";
            queryPrincipal += "'$ ' +CONVERT(varchar(15), ubiXpubli_precio)  as 'Precio', ";
            queryPrincipal += "CONVERT(nvarchar(15), DAY(publicacion_fecha_venc))+'/'+CONVERT(nvarchar(15), MONTH(publicacion_fecha_venc))+'/'+CONVERT(nvarchar(15), YEAR(publicacion_fecha_venc)) +  ' ' + CONVERT(nvarchar(15), DATEPART(HOUR, publicacion_fecha_venc)) +':'+ CONVERT(nvarchar(15), DATEPART(MINUTE, publicacion_fecha_venc)) as 'Fecha de evento', r.rubro_descripcion as 'Categoría', g.grado_id as 'GRADO ID' ";
            queryPrincipal += " FROM [SQLEADOS].Publicacion p ";
            queryPrincipal += cargarJoins();
            queryPrincipal += comandoWhere();
            return queryPrincipal;
        }

        private String conTop(int numero) { 
            return " TOP ("+numero.ToString()+") ";
        }

        private String cargar10QuerysParaNPagina()
        {
            String queryPrincipal = cargarPrimeros10Querys();
            String queryExcluyente = " AND up.ubiXpubli_ID NOT IN (SELECT TOP (" + (paginaActual - 1) * totalVistoPorPagina + ") ";
            queryExcluyente += "up.ubiXpubli_ID";
            queryExcluyente += " FROM [SQLEADOS].Publicacion p ";
            queryExcluyente += cargarJoins();
            queryExcluyente += comandoWhere() +" " + ordenamiento() +") ";
            queryPrincipal += queryExcluyente;
            return queryPrincipal;
        }

        public String queryExcluyenteSinTop() {
            String queryExcluyente = " AND up.ubiXpubli_ID NOT IN (SELECT ";
            queryExcluyente += "up.ubiXpubli_ID";
            queryExcluyente += " FROM [SQLEADOS].Publicacion p ";
            queryExcluyente += cargarJoins();
            queryExcluyente += comandoWhere() + ") ";
            return queryExcluyente;
        }

        private String cargarJoins() {
            String joins;
            joins = " JOIN [SQLEADOS].ubicacionXpublicacion  up ON up.ubiXpubli_Publicacion = p.publicacion_codigo JOIN [SQLEADOS].Rubro r on r.rubro_id = p.publicacion_rubro ";
            joins += "JOIN [SQLEADOS].Ubicacion u ON u.ubicacion_id = up.ubiXpubli_Ubicacion JOIN [SQLEADOS].GradoPrioridad g ON g.grado_id = p.publicacion_grado ";
            return joins;
        }

        private String ordenamiento() {
            return " ORDER BY g.grado_id ASC, YEAR(publicacion_fecha_venc) ASC, MONTH(publicacion_fecha_venc) ASC, DAY(publicacion_fecha_venc) ASC";
        }

        private String comandoWhere() {
            String where ="";
            where += " WHERE p.publicacion_estado LIKE 'Publicada' ";
            if (textBoxPublicacion.Text != "")
            {
                where += "AND p.publicacion_descripcion LIKE '%" + textBoxPublicacion.Text.Trim() + "%' ";
            }

            if (labelCategoria.Text != "")
            {
                where += crearComandoParaCategoria();
            }


            if (labelTipoUbicaciones.Text != "")
            {
                where += crearComandoParaTipoUbicacion();
            }
            DateTime hoy = DateTime.Today;
            if (hoy.Year == dateTimePicker1.Value.Date.Year && hoy.Month == dateTimePicker1.Value.Date.Month && hoy.Day == dateTimePicker1.Value.Date.Day)
            {
                //PARA CUMPLIR CON EL REQUISITO EXTRA DE QUE SI LA FECHA DE COMPRA DESDE ES EL MISMO DÍA QUE EL DE COMPRA, ENTONCES
                //SE DEBE COMPRAR CON ANTICIPACIÓN 1 DÍA ANTES DE LA FUNCIÓN

                //RANGO DE FECHAS
                where += " AND publicacion_fecha_venc BETWEEN '" + extraerFechaSinHora(dateTimePicker1.Value.Date.AddDays(1)) + "' AND '" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + " 23:59:00.000" +"' ";
            }
            else
            {
                //RANGO DE FECHAS
                where += " AND publicacion_fecha_venc BETWEEN '" + extraerFechaSinHora(dateTimePicker1.Value.Date) + "' AND '" +  dateTimePicker2.Value.ToString("yyyy/MM/dd") + " 23:59:00.000"+ "' ";
            }

            //EXCLUYO TODAS LAS UBICACIONES QUE YA FUERON COMPRADAS
            where += " AND ubiXpubli_ID NOT IN (SELECT x.ubxpcom_ubicacionXPublicidad FROM SQLEADOS.ubicacionesXPublicidadComprada x)";
            //         cadena += "OR ('" + extraerFechaSinHora(dateTimePicker2.Value.Date) + "' BETWEEN publicacion_fecha_venc AND publicacion_fecha)) ";

  //          where += " AND up.ubiXpubli_ID NOT IN (SELECT ubicacion_id FROM SQLEADOS.ubicacionXpublicacion JOIN SQLEADOS.Compra c ON c.compra_ubiXpubli = ubiXpubli_ID JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ubiXpubli_Ubicacion) ";
            return where;
        }

        public void cargarDeNuevo() {
            cargaDeLaGrilla();
        }

        //BOTON BUSCAR
        // PRIMERO ARMO PARA QUE ME CUENTE LA CANTIDAD TOTAL DE IDS, LUEGO LOS BUSCA
        private void button1_Click(object sender, EventArgs e)
        {
            cargaDeLaGrilla();
        }

        private void cargaDeLaGrilla() 
        {
            //string theDate = dateTimePickeValuer1.Value.ToString("yyyy-MM-dd");
            //string theDate2 = dateTimePicker2..ToString("yyyy-MM-dd");
            if (dateTimePicker1.Value.Date >= dateTimePicker2.Value.Date)
            {
                MessageBox.Show("La segunda fecha no puede ser inferior o igual a la primera \nFECHA 1:" + dateTimePicker1.Text + "\nFECHA 2:" + dateTimePicker2.Text);
                return;
            }
            DateTime hoy = DateTime.Today;
            if (hoy > dateTimePicker1.Value.Date)
            {
                MessageBox.Show("La fecha inicial no puede ser menor que la actual");
                return;
            }
            String queryPrincipal;
            if (paginaActual != 1)
            {
                queryPrincipal = cargar10QuerysParaNPagina();
            }
            else
            {
                queryPrincipal = cargarPrimeros10Querys();
            }

            String comandoContadorTotalIDs = "SELECT DISTINCT COUNT(*) as 'ID' FROM [SQLEADOS].Publicacion p ";
            comandoContadorTotalIDs += cargarJoins();
            //       cadena += "JOIN [SQLEADOS].Compra c ON c.compra_ubiXpubli != up.ubiXpubli_ID ";

            comandoContadorTotalIDs += comandoWhere();
            queryPrincipal += " " + ordenamiento();
            //         MessageBox.Show(queryPrincipal);
            //   comandoContadorTotalIDs += queryExcluyenteSinTop();
            DBConsulta.conexionAbrir();
            ponerBienLasHojas(comandoContadorTotalIDs);
            obtenerResultados(queryPrincipal);
            DBConsulta.conexionCerrar();
        }

        private String extraerFechaSinHora(DateTime fecha) {
            //FORMATO YYYY-MM-DD
            
            int anio = fecha.Year;
            int mes = fecha.Month;
            int dia = fecha.Day;
            return anio+"-"+mes+"-"+dia;
        }

        private void ponerBienLasHojas(String query) {
            String cantidadDeResultados =DBConsulta.obtenerConsultaEspecifica(query).Rows[0][0].ToString();
            int res = Convert.ToInt32(cantidadDeResultados);
            ultimaHoja = (res / totalVistoPorPagina) + 1;
            labelPaginas.Text = "1 de " + ultimaHoja.ToString();
        }

        private void obtenerResultados(String query) {
            DataTable dt = new DataTable();
            dt = DBConsulta.obtenerConsultaEspecifica(query);
            configuracionGrilla(dt);
        }

        //ELEGIR CATEGORIAS
        private void buttonCategoria_Click(object sender, EventArgs e)
        {
            ComprarPrincipal a = this;

            Elegir_categoria el = new Elegir_categoria(labelCategoria.Text, a);
            el.Show();  
        }

        private void buttonElegirUbicacion_Click(object sender, EventArgs e)
        {
            ComprarPrincipal a = this;
            ElegirTipoAsiento es = new ElegirTipoAsiento(labelTipoUbicaciones.Text, a);
            es.Show();
        }

        //CAMBIA EL TIPO DE 
        private void button10_Click(object sender, EventArgs e)
        {
            cambiarTamanio(button10.Text, sender, e);
        }

        //CAMBIA LA CANTIDAD DE HOJAS POR PÁGINA AL HACER CLICK UN BOTON
        private void cambiarTamanio(String cantidad,object s, EventArgs e) {
            totalVistoPorPagina = Convert.ToInt32(cantidad);
            labelItemXHoja.Text = "Items por hoja \n" + cantidad;
            //RECARGA LA GRILLA CON LA CONFIGURACION DE TAMANIO POR PAGINA
         //   button1_Click(s, e);
        }

        //EN REALIDAD ESTE ES PARA EL BOTON QUE DICE 50, PERO NO SE ACTUALIZÓ EL NOMBRE DE LA FUNCION
        private void button25_Click(object sender, EventArgs e)
        {
            cambiarTamanio(button50.Text, sender, e);
        }

        private void button100_Click(object sender, EventArgs e)
        {
            cambiarTamanio(button100.Text, sender, e);
        }

        private void button250_Click(object sender, EventArgs e)
        {
            cambiarTamanio(button250.Text, sender, e);
        }

        private void button500_Click(object sender, EventArgs e)
        {
            cambiarTamanio(button500.Text, sender, e);
        }

        //BOTON DE COMPRAR, SOLO CARGA LOS IDS QUE LUEGO IRAN A LA VISTA DE CONFIRMARCOMPRA
        private void buttonComprar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                String ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                IDCargados.Add(ID);
                MessageBox.Show("La ubicación con ID " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + " fue añadida");
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowindex);
            }
            
            
        }

        //BOTON PARA CONFIRMAR LA COMPRA O SEA PAGAR
        private void button2_Click(object sender, EventArgs e)
        {
            if (Usuario.esAdmin == 1)
            {
                MessageBox.Show("Un administrador no puede comprar", "Error");
                return;
            }

            ComprarPrincipal thi = this;

            if (!IDCargados.Any())
            {
                MessageBox.Show("No has seleccionado nada para comprar");
                return;
            }
            ConfirmarCompra a = new ConfirmarCompra(this, IDCargados, userID);
            a.Show();
            this.Hide();
        }

        public void vaciarIDCargada() {
            if (IDCargados.Any())
            {
                IDCargados.Clear();
            }
            
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            labelCategoria.Text = "";
            labelTipoUbicaciones.Text = "";
            textBoxPublicacion.Text = "";
            cambiarTamanio("10", sender, e);

            dateTimePicker1.Value = new DateTime(f1.Year, f1.Month, f1.Day);
            dateTimePicker2.Value = new DateTime(f2.Year, f2.Month, f2.Day);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //VOLVER
        private void button3_Click(object sender, EventArgs e)
        {
            exx.Show();
            this.Close();
        }
    }
}
