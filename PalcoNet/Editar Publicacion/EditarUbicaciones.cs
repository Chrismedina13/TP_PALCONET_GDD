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

namespace PalcoNet.Editar_Publicacion
{
    public partial class EditarUbicaciones : Form
    {
        private int publicacion;
        EditarPublicacion edit;
        editarInfoOUbicaciones ventanaAnterior;
        List<int> ubicacionesQuitadas;
        bool huboCambios;
        public EditarUbicaciones(int idPublicacion, EditarPublicacion cosas, editarInfoOUbicaciones infoubicacion)
        {
            edit = cosas;
            ventanaAnterior = infoubicacion;
            publicacion = idPublicacion;
            InitializeComponent();
            huboCambios = false;
            ubicacionesQuitadas = new List<int>();
        }

        private void EditarUbicaciones_Load(object sender, EventArgs e)
        {
            //CARGAR UBICACIONES Y UBICACIONES QUE YA ESTÁN EN LA PUBLICACION
            cargarUbicaciones();
            cargarUbicacionesDePublicacion();

            String query = "SELECT DISTINCT ubicacion_Tipo_Descripcion FROM SQLEADOS.Ubicacion";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        public void agregarUbicacionConPrecioYTipo(String fila, String ubicacion, String precio, String tipoUbicacion) {

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Fila", typeof(String));
            dt.Columns.Add(dc);

            dc = new DataColumn("Asiento", typeof(String));
            dt.Columns.Add(dc);

            dc = new DataColumn("Sector", typeof(String));
            dt.Columns.Add(dc);

            dc = new DataColumn("Precio", typeof(String));
            dt.Columns.Add(dc);

            
            for (int i = 0; i < dataGridViewAdentro.RowCount; i++) {
                DataRow dr = dt.NewRow();
                dr[0] = dataGridViewAdentro.Rows[i].Cells[0].Value.ToString();
                dr[1] = dataGridViewAdentro.Rows[i].Cells[1].Value.ToString();
                dr[2] = dataGridViewAdentro.Rows[i].Cells[2].Value.ToString();
                dr[3] = dataGridViewAdentro.Rows[i].Cells[3].Value.ToString();

                dt.Rows.Add(dr);
            }
            DataRow ds = dt.NewRow();

            ds[0] = fila;
            ds[1] = ubicacion;
            ds[2] = tipoUbicacion;
            ds[3] = precio;

            dt.Rows.Add(ds);
            dataGridViewAdentro.DataSource = dt;
        }

        

        private void cargarUbicaciones() {
            String query = "SELECT DISTINCT ubicacion_fila as 'FILA', ubicacion_asiento as 'Asiento' FROM SQLEADOS.Ubicacion";

            dataGridViewUbicacionesEnLugar.DataSource = DBConsulta.AbrirCerrarObtenerConsulta(query);
        }

        private void cargarUbicacionesDePublicacion() {
            String query = "SELECT DISTINCT ubicacion_fila as 'FILA', ubicacion_asiento as 'Asiento', ubicacion_Tipo_Descripcion as 'Sector', ub.ubiXpubli_precio as 'Precio' FROM SQLEADOS.Ubicacion u JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Ubicacion = u.ubicacion_id JOIN SQLEADOS.Publicacion p ON p.publicacion_codigo = ub.ubiXpubli_Publicacion WHERE p.publicacion_codigo = " + publicacion;
            dataGridViewAdentro.DataSource = DBConsulta.AbrirCerrarObtenerConsulta(query);
        }

        //SALIR
        private void button3_Click(object sender, EventArgs e)
        {
            //ACTUALIZAR 
            edit.Show();
            ventanaAnterior.cerrar();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //LIMPIAR DATOS
            cargarUbicaciones();
            cargarUbicacionesDePublicacion();

            ubicacionesQuitadas = new List<int>();
            textBoxPrecio.Text = "500";
            comboBox1.Text = "Tipo de ubicación";
            comboBox1.SelectedItem = null;
        }

        private void dataGridViewAdentro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AGREGAR NUEVA UBICACIÓN
            String fila = dataGridViewUbicacionesEnLugar.SelectedCells[0].Value.ToString();
            String asiento = dataGridViewUbicacionesEnLugar.SelectedCells[1].Value.ToString();

            //VERIFICAR SI YA FUE INGRESADO
            if (yafueingresado(fila, asiento))
            {
                MessageBox.Show("Esta ubicación ya fue ingresada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else { 
                //PROCEDE A INGRESAR NUEVO ASIENTO Y A PONER SU PRECIO Y TAMBIÉN SU TIPO DE UBICACION
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("No has seleccionado ningún tipo de ubicación aún", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBoxPrecio.Text == "") {
                    MessageBox.Show("No has ingresado el precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!AyudaExtra.esStringNumerico(textBoxPrecio.Text))
                {
                    MessageBox.Show("El precio ingresado no es un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                agregarUbicacionConPrecioYTipo(fila, asiento, textBoxPrecio.Text, comboBox1.SelectedItem.ToString());
            }
        }

        private bool yafueingresado(String fila, String asiento) {
            for (int i = 0; i < dataGridViewAdentro.RowCount; i++) {
                String aaaa  = dataGridViewAdentro.Rows[i].Cells[0].Value.ToString();
                if (aaaa == fila)
                {
                    String aComparar = dataGridViewAdentro.Rows[i].Cells[1].Value.ToString();
                    if (aComparar == asiento)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //QUITAR UBICACION
            String fila, ubicacion, tipoUbicacion;

            //ELIMINA 1 FILA SELECCIONADA
            foreach (DataGridViewRow item in this.dataGridViewAdentro.SelectedRows)
            {
                fila = dataGridViewAdentro.Rows[item.Index].Cells[0].Value.ToString();
                ubicacion = dataGridViewAdentro.Rows[item.Index].Cells[1].Value.ToString();
                tipoUbicacion = dataGridViewAdentro.Rows[item.Index].Cells[2].Value.ToString();
                dataGridViewAdentro.Rows.RemoveAt(item.Index);
                String ubicacionID = buscarUbicacionDeEstosSiExiste(fila, ubicacion, tipoUbicacion);
                if (ubicacionID != "nada") {
                    int id = Convert.ToInt32(ubicacionID);
                    if (!ubicacionesQuitadas.Contains(id))
                    {
                        if (verificarSiExisteEnLaOriginal(id)) {
                            ubicacionesQuitadas.Add(id);
                        }
                    }
                }
            }
        }

        private bool verificarSiExisteEnLaOriginal(int id) {
            String query = "SELECT DISTINCT ubicacion_id FROM SQLEADOS.Ubicacion u JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Ubicacion = u.ubicacion_id JOIN SQLEADOS.Publicacion p ON p.publicacion_codigo = ub.ubiXpubli_Publicacion WHERE p.publicacion_codigo = " + publicacion;
            DataTable paraComparar = DBConsulta.AbrirCerrarObtenerConsulta(query);
            for (int i = 0; i < paraComparar.Rows.Count; i++) {
                if (id == Convert.ToInt32(paraComparar.Rows[i][0].ToString())) {
                    return true;
                }
            }
            return false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //ACTUALIZAR

            //PRIMERO BORRO TODAS LAS UBICACIONES QUE ESTÁN PARA BORRAR
            eliminarUbicacionesQueFueronQuitadas();

            //PASO TODO A OTRO DATATABLE
            String fila, ubicacion, precio, tipoubicacion;
            for (int i = 0; i < dataGridViewAdentro.RowCount; i++) {
                fila = dataGridViewAdentro.Rows[i].Cells[0].Value.ToString();
                ubicacion = dataGridViewAdentro.Rows[i].Cells[1].Value.ToString();
                tipoubicacion = dataGridViewAdentro.Rows[i].Cells[2].Value.ToString();
                precio = dataGridViewAdentro.Rows[i].Cells[3].Value.ToString();
                if (!existeUbicacionParaPublicacion(fila, ubicacion, tipoubicacion, publicacion))
                {
                    //NO EXISTE, DEBO VERIFICAR SI EXISTE ESTE TIPO DE UBICACIÓN ANTES
                    if (!existeEsteTipoDeUbicacion(fila, ubicacion, tipoubicacion))
                    {
                        //NO EXISTE, ASI QUE DEBO CREARLA
                        crearNuevaUbicacion(fila, ubicacion, tipoubicacion);
                    }
                    //EXISTE, Y SI NO ERA ASÍ SE LE HA CREADO, POR LO TANTO CREO EL INSERT
                    crearNuevaUbicacionXPublicacion(fila, ubicacion, tipoubicacion, precio);
                }
            }
            MessageBox.Show("Se ha actualizado las ubicación de la publicación con ID: " + publicacion);
        }

        private void eliminarUbicacionesQueFueronQuitadas() {
            for (int i = 0; i < ubicacionesQuitadas.Count; i++) {
                int id = ubicacionesQuitadas[i];
                String eliminar = "DELETE FROM SQLEADOS.ubicacionXpublicacion WHERE ubiXpubli_Publicacion = " + publicacion + " AND ubiXpubli_Ubicacion = "+id;
                DBConsulta.AbrirCerrarModificarDB(eliminar);
            }
        }

        private void crearNuevaUbicacionXPublicacion(String fila, String ubicacion, String tipoUbicacion, String precio) {
            String obtenerUbicacionID = "SELECT ubicacion_id FROM SQLEADOS.Ubicacion WHERE ubicacion_fila LIKE '" + fila + "' AND ubicacion_asiento = " + ubicacion + " AND ubicacion_Tipo_Descripcion LIKE '" + tipoUbicacion + "'";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(obtenerUbicacionID);
            String ubicacionID = dt.Rows[0][0].ToString();

            String crearNuevaUbicacionXPublicacion = "INSERT INTO SQLEADOS.ubicacionXpublicacion(ubiXpubli_Publicacion, ubiXpubli_Ubicacion, ubiXpubli_precio) VALUES ("+publicacion+", "+ubicacionID+", "+precio+")";
            DBConsulta.AbrirCerrarModificarDB(crearNuevaUbicacionXPublicacion);
        }

        private String buscarUbicacionDeEstosSiExiste(String fila, String ubicacion, String tipoUbicacion) {
        //    if(existeEsteTipoDeUbicacion(fila, ubicacion, tipoUbicacion)) {
                String obtenerUbicacionID = "SELECT ubicacion_id FROM SQLEADOS.Ubicacion WHERE ubicacion_fila LIKE '" + fila + "' AND ubicacion_asiento = " + ubicacion + " AND ubicacion_Tipo_Descripcion LIKE '" + tipoUbicacion + "'";
                DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(obtenerUbicacionID);
                return dt.Rows[0][0].ToString();
       //     }
       //     return "nada";
        }

        private void crearNuevaUbicacion(String fila, String ubicacion, String tipoUbicacion) 
        { 
            String query = "INSERT INTO SQLEADOS.Ubicacion(ubicacion_asiento, ubicacion_fila, ubicacion_sin_numerar, ubicacion_Tipo_codigo, ubicacion_Tipo_Descripcion) VALUES ('"+fila+"', "+ubicacion+", 0, 0, '"+tipoUbicacion+"')";
            DBConsulta.AbrirCerrarModificarDB(query);
        }

        private bool existeEsteTipoDeUbicacion(String fila, String ubicacion, String tipoUbicacion) {
            String query = "SELECT COUNT(*) FROM SQLEADOS.Ubicacion WHERE ubicacion_fila LIKE '" + fila + "' AND ubicacion_asiento = " + ubicacion + " AND ubicacion_Tipo_Descripcion LIKE '" + tipoUbicacion + "'";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            return Convert.ToInt32(dt.Rows[0][0].ToString()) > 0;
        }

        private bool existeUbicacionParaPublicacion(String fila, String ubicacion, String tipoUbicacion, int idpublicacion) {
            String query = "SELECT COUNT(*) FROM SQLEADOS.ubicacionXpublicacion ub JOIN SQLEADOS.Ubicacion u ON u.ubicacion_id = ub.ubiXpubli_Ubicacion	WHERE UB.ubiXpubli_Publicacion = " + idpublicacion + " AND ubicacion_Tipo_Descripcion LIKE '" + tipoUbicacion + "' AND u.ubicacion_fila LIKE '" + fila + "' AND u.ubicacion_asiento =" + ubicacion;
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            return Convert.ToInt32(dt.Rows[0][0].ToString()) > 0;
            //dataGridViewAdentro.RowRem
        }
    }
}
