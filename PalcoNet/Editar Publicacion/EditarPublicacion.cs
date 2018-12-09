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

namespace PalcoNet.Editar_Publicacion
{
    public partial class EditarPublicacion : Form
    {
        private int user;
        private bool esAdmin ;
        DataTable dt;
        public EditarPublicacion(int Usuario)
        {
            user = Usuario;
            dt = new DataTable();
            DBConsulta.conexionAbrir();
            String queryUserAdmin = "SELECT usuario_Id FROM SQLEADOS.Usuario where usuario_administrador = 1";
            if (AyudaExtra.intPerteneceADataTable(user, DBConsulta.obtenerConsultaEspecifica(queryUserAdmin)))
            {
                esAdmin = true;
            }
            else {
                esAdmin = false;
            }
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
            String queryBuscador = "";
            
            if (esAdmin)
            {
                //Encuentra todas los espectáculos
                queryBuscador = "SELECT publicacion_codigo as 'Codigo', publicacion_descripcion as 'Espectáculo', publicacion_fecha_venc as 'Fecha de estreno', publicacion_usuario_responsable as 'Empresa responsable', publicacion_estado as 'Estado', CASE WHEN publicacion_estado LIKE 'Borrador' then 'SI' ELSE 'NO' END AS 'Se puede modificar' FROM SQLEADOS.Publicacion";
                dt = DBConsulta.obtenerConsultaEspecifica(queryBuscador);
            }
            else { 
                //Solo sirven los que publicó la empresa
                queryBuscador = "SELECT publicacion_codigo as 'Codigo', publicacion_descripcion as 'Espectáculo', publicacion_fecha_venc as 'Fecha de estreno', publicacion_usuario_responsable as 'Empresa responsable', publicacion_estado as 'Estado', CASE WHEN publicacion_estado LIKE 'Borrador' then 'SI' ELSE 'NO' END AS 'Se puede modificar' FROM SQLEADOS.Publicacion WHERE publicacion_usuario_responsable ="+ user;
                dt = DBConsulta.obtenerConsultaEspecifica(queryBuscador);
            }
            configuracionGrilla(dt);
        }

        public void recargar() {
            String queryBuscador = "";

            if (esAdmin)
            {
                //Encuentra todas los espectáculos
                queryBuscador = "SELECT publicacion_codigo as 'Codigo', publicacion_descripcion as 'Espectáculo', publicacion_fecha_venc as 'Fecha de estreno', publicacion_usuario_responsable as 'Empresa responsable', publicacion_estado as 'Estado', CASE WHEN publicacion_estado LIKE 'Borrador' then 'SI' ELSE 'NO' END AS 'Se puede modificar' FROM SQLEADOS.Publicacion";
                dt = DBConsulta.obtenerConsultaEspecifica(queryBuscador);
            }
            else
            {
                //Solo sirven los que publicó la empresa
                queryBuscador = "SELECT publicacion_codigo as 'Codigo', publicacion_descripcion as 'Espectáculo', publicacion_fecha_venc as 'Fecha de estreno', publicacion_usuario_responsable as 'Empresa responsable', publicacion_estado as 'Estado', CASE WHEN publicacion_estado LIKE 'Borrador' then 'SI' ELSE 'NO' END AS 'Se puede modificar' FROM SQLEADOS.Publicacion WHERE publicacion_usuario_responsable =" + user;
                dt = DBConsulta.obtenerConsultaEspecifica(queryBuscador);
            }
            configuracionGrilla(dt);
        }

        //BOTON EDITAR
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells[5].Value.ToString() =="NO") {
                MessageBox.Show("Esta publicación no se puede editar\nporque no está en estado BORRADOR");
                return;
            }
            EditarCosasDePublicacion ex = new EditarCosasDePublicacion(Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()), this);
            ex.Show();
        }

        //BOTON VOLVER
        private void botonVolver_Click(object sender, EventArgs e)
        {
            DBConsulta.conexionCerrar();
            this.Close();
        }
    }
}