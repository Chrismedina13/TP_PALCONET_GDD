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

namespace PalcoNet.Generar_Publicacion
{
    public partial class Generar_publicacion : TablaPaginadas
    {
        private int userEmpresa;
        public Generar_publicacion(int userID)
        {
            InitializeComponent();
            userEmpresa = userID;
        }

        private void Generar_publicacion_Load(object sender, EventArgs e)
        {
            DBConsulta.conexionAbrir();

        }


        //BOTON VOLVER
        private void button3_Click(object sender, EventArgs e)
        {
            DBConsulta.conexionCerrar();
            this.Close();
        }

    }
}
