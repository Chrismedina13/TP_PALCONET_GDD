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
    public partial class AltaPublicacion : Form
    {
        public AltaPublicacion(int usuario)
        {
            InitializeComponent();
            textBoxUsuario.Text =  Convert.ToString(usuario);
            textBoxCodigo.Text = GenerarPublicacion.obtenerCodigoPublicacion();
            GenerarPublicacion.llenarComboRubro(comboBoxRubro);
            GenerarPublicacion.llenarComboGrado(comboBoxGrado);
            GenerarPublicacion.cargarGriddUbicaciones(dataGridViewUbicaciones);

        }

        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
