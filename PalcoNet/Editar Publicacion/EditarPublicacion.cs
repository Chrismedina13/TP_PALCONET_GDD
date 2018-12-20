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
    public partial class EditarPublicacion : Form
    {
        private int user;
        private bool esAdmin ;
        DataTable dt;
        Explorador exx;

        public EditarPublicacion(Explorador exs)
        {
            exx = exs;
            user = Usuario.ID;
           
 
            String queryUserAdmin = "SELECT usuario_Id FROM SQLEADOS.Usuario where usuario_administrador = 1";
            String queryUserEsUnAdmin = "SELECT usuario_administrador FROM SQLEADOS.Usuario WHERE usuario_Id = " + Usuario.ID;
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(queryUserEsUnAdmin);
   //         int numero = 
            if (Usuario.esAdmin == 1)
            {
                esAdmin = true;
            }
            else {
                esAdmin = false;
            }

            /*if (AyudaExtra.intPerteneceADataTable(user, DBConsulta.obtenerConsultaEspecifica(queryUserAdmin)))
            {
                esAdmin = true;
            }
            else {
                esAdmin = false;
            }*/
            InitializeComponent();
        }

        private void configuracionGrilla(DataTable dt)
        {
            dataGridView1.DataSource = dt;

            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 80;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 230;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 150;
            return;
        }

        private void botonEditar_Load(object sender, EventArgs e)
        {
            carga();
        }

        public void carga() {
            String queryBuscador = "";

            if (esAdmin)
            {
                //Encuentra todos los espectáculos en estado BORRADOR y PUBLICADO
                queryBuscador = "SELECT publicacion_codigo as 'Codigo', publicacion_descripcion as 'Espectáculo', publicacion_fecha_venc as 'Fecha de estreno', publicacion_usuario_responsable as 'Empresa responsable', publicacion_estado as 'Estado', CASE WHEN publicacion_estado LIKE 'Borrador' then 'SI' ELSE 'NO' END AS 'Se puede modificar' FROM SQLEADOS.Publicacion WHERE (publicacion_estado LIKE 'Borrador' OR publicacion_estado LIKE 'Publicada') ORDER BY YEAR(publicacion_fecha_venc) DESC, MONTH(publicacion_fecha_venc) DESC, DAY(publicacion_fecha_venc) DESC";
                dt = DBConsulta.AbrirCerrarObtenerConsulta(queryBuscador);
            }
            else
            {
                //Solo sirven los que publicó la empresa
                queryBuscador = "SELECT publicacion_codigo as 'Codigo', publicacion_descripcion as 'Espectáculo', publicacion_fecha_venc as 'Fecha de estreno', publicacion_usuario_responsable as 'Empresa responsable', publicacion_estado as 'Estado', CASE WHEN publicacion_estado LIKE 'Borrador' then 'SI' ELSE 'NO' END AS 'Se puede modificar' FROM SQLEADOS.Publicacion WHERE (publicacion_estado LIKE 'Borrador' OR publicacion_estado LIKE 'Publicada') AND publicacion_usuario_responsable =" + user + " ORDER BY YEAR(publicacion_fecha_venc) DESC, MONTH(publicacion_fecha_venc) DESC, DAY(publicacion_fecha_venc) DESC";
                dt = DBConsulta.AbrirCerrarObtenerConsulta(queryBuscador);
            }
            configuracionGrilla(dt);
        }

        public void recargar() {
            String queryBuscador = "";

            if (esAdmin)
            {
                //Encuentra todas los espectáculos
                queryBuscador = "SELECT publicacion_codigo as 'Codigo', publicacion_descripcion as 'Espectáculo', publicacion_fecha_venc as 'Fecha de estreno', publicacion_usuario_responsable as 'Empresa responsable', publicacion_estado as 'Estado', CASE WHEN publicacion_estado LIKE 'Borrador' then 'SI' ELSE 'NO' END AS 'Se puede modificar' FROM SQLEADOS.Publicacion WHERE (publicacion_estado LIKE 'Borrador' OR publicacion_estado LIKE 'Publicada') ORDER BY YEAR(publicacion_fecha_venc) DESC, MONTH(publicacion_fecha_venc) DESC, DAY(publicacion_fecha_venc) DESC";
                dt = DBConsulta.AbrirCerrarObtenerConsulta(queryBuscador);
            }
            else
            {
                //Solo sirven los que publicó la empresa
                queryBuscador = "SELECT publicacion_codigo as 'Codigo', publicacion_descripcion as 'Espectáculo', publicacion_fecha_venc as 'Fecha de estreno', publicacion_usuario_responsable as 'Empresa responsable', publicacion_estado as 'Estado', CASE WHEN publicacion_estado LIKE 'Borrador' then 'SI' ELSE 'NO' END AS 'Se puede modificar' FROM SQLEADOS.Publicacion WHERE (publicacion_estado LIKE 'Borrador' OR publicacion_estado LIKE 'Publicada') AND publicacion_usuario_responsable =" + user + " ORDER BY YEAR(publicacion_fecha_venc) DESC, MONTH(publicacion_fecha_venc) DESC, DAY(publicacion_fecha_venc) DESC";
                dt = DBConsulta.AbrirCerrarObtenerConsulta(queryBuscador);
            }
            configuracionGrilla(dt);
        }

        //BOTON EDITAR
        private void button1_Click(object sender, EventArgs e)
        {
            String valor = dataGridView1.SelectedCells[5].Value.ToString();
            if (valor == "NO")
            {
                MessageBox.Show("Esta publicación no se puede editar\nporque no está en estado BORRADOR");
                FINALIZARUNAPUBLICACION info = new FINALIZARUNAPUBLICACION(this, dataGridView1.SelectedCells[0].Value.ToString());
     //           EditarCosasDePublicacion info = new EditarCosasDePublicacion(Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()), this);
                info.Show();
            }
            else {
                editarInfoOUbicaciones info = new editarInfoOUbicaciones(Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()), this);
                info.Show();
            }
            this.Hide();
        }

        //BOTON VOLVER
        private void botonVolver_Click(object sender, EventArgs e)
        {
            exx.Show();
            this.Close();
        }
    }
}
