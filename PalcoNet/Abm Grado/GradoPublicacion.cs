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

namespace PalcoNet.Abm_Grado
{
    public partial class GradoPublicacion : Form
    {
        private int usuario;
        public GradoPublicacion(int user)
        {
            usuario = user;
            InitializeComponent();
            DBConsulta.conexionAbrir();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GradoPublicacion_Load(object sender, EventArgs e)
        {
            String query = "SELECT grado_comision as 'GRADO' FROM SQLEADOS.GradoPrioridad";
            DataTable dt = DBConsulta.obtenerConsultaEspecifica(query);
            labelComisionAlta.Text = "% " + dt.Rows[0][0].ToString();
            labelComisionMedia.Text = "% " + dt.Rows[1][0].ToString();
            labelComisionBaja.Text = "% " + dt.Rows[2][0].ToString();
        }

        //BOTON ALTA PRIORIDAD
        private void button1_Click(object sender, EventArgs e)
        {
            String quertyy = "UPDATE SQLEADOS.Publicacion SET publicacion_grado = 1 FROM SQLEADOS.Publicacion WHERE publicacion_usuario_responsable = "+ usuario;
            DBConsulta.ConectarConsulta(quertyy);
            mensajeExito("Alta");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String quertyy = "UPDATE SQLEADOS.Publicacion SET publicacion_grado = 2 FROM SQLEADOS.Publicacion WHERE publicacion_usuario_responsable = " + usuario;
            DBConsulta.ConectarConsulta(quertyy);
            mensajeExito("Media");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String quertyy = "UPDATE SQLEADOS.Publicacion SET publicacion_grado = 3 FROM SQLEADOS.Publicacion WHERE publicacion_usuario_responsable = " + usuario;
            DBConsulta.ConectarConsulta(quertyy);
            mensajeExito("Baja");
        }

        private void mensajeExito(String tipo) {
            MessageBox.Show("Se han puesto todas las publicaciones en: "+ tipo);
            DBConsulta.conexionCerrar();
            this.Close();
        }
    }
}