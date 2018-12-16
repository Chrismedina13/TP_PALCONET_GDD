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
        EditarCosasDePublicacion edit;
        public EditarUbicaciones(EditarCosasDePublicacion cosas ,int idPublicacion)
        {
            edit = cosas;
            publicacion = idPublicacion;
            InitializeComponent();
        }

        private void EditarUbicaciones_Load(object sender, EventArgs e)
        {
            //CARGAR UBICACIONES Y UBICACIONES QUE YA ESTÁN EN LA PUBLICACION
            cargarUbicaciones();
            cargarUbicacionesDePublicacion();
        }

        public void agregarUbicacionConPrecioYTipo(String fila, String ubicacion, String precio, String tipoUbicacion) {
            this.dataGridViewAdentro.Rows.Add(fila, ubicacion, tipoUbicacion, precio);
        }

        

        private void cargarUbicaciones() {
            String query = "SELECT DISTINCT ubicacion_fila as 'FILA', ubicacion_asiento as 'Asiento' as 'Sector' FROM SQLEADOS.Ubicacion";

            dataGridViewUbicacionesEnLugar.DataSource = DBConsulta.AbrirCerrarObtenerConsulta(query);
        }

        private void cargarUbicacionesDePublicacion() {
            String query = "SELECT DISTINCT ubicacion_fila as 'FILA', ubicacion_asiento as 'Asiento', ubicacion_Tipo_Descripcion as 'Sector', ub.ubiXpubli_precio as 'Precio' FROM SQLEADOS.Ubicacion u JOIN SQLEADOS.ubicacionXpublicacion ub ON ub.ubiXpubli_Ubicacion = u.ubicacion_id JOIN SQLEADOS.Publicacion p ON p.publicacion_codigo = ub.ubiXpubli_Publicacion WHERE p.publicacion_codigo = " + publicacion;
            dataGridViewAdentro.DataSource = DBConsulta.AbrirCerrarObtenerConsulta(query);
        }

        //SALIR
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //LIMPIAR DATOS
            cargarUbicaciones();
            cargarUbicacionesDePublicacion();
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
                MessageBox.Show("Esta ubicación ya fue ingresada");
            }
            else { 
                //PROCEDE A INGRESAR NUEVO ASIENTO Y A PONER SU PRECIO Y TAMBIÉN SU TIPO DE UBICACION

            }
        }

        private bool yafueingresado(String fila, String asiento) {
            for (int i = 0; i < dataGridViewAdentro.RowCount; i++) {
                if (dataGridViewAdentro.Rows[i].Cells[0].ToString() == fila) {
                    if (dataGridViewAdentro.Rows[i].Cells[1].ToString() == asiento) {
                        return true;
                    }
                }
            }
            return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //QUITAR UBICACION
            dataGridViewAdentro.RowRem
        }
    }
}
