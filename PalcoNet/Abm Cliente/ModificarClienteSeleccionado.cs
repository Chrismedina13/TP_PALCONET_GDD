using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data;
using PalcoNet.Support;

namespace PalcoNet.Abm_Cliente
{
    
    public partial class ModificarClienteSeleccionado : volver
    {
        int usuarioSeleccionado;

        public ModificarClienteSeleccionado(int user)
        {
            usuarioSeleccionado = user;
            ObtenerDatos_load();
            InitializeComponent();
        }

        private void ModificarClienteSeleccionado_Load(object sender, EventArgs e)
        {
            
            this.ObtenerDatos_load();
        }

        private void completarDatosDeVista(DataTable dt) 
        {
           
        }

        private void ObtenerDatos_load() {
            DataTable dt = DBConsulta.obtenerTodosLosDatosRelevantesDe1Cliente(usuarioSeleccionado);
            dataGridView1.DataSource = dt;
        }

        private void ModificarClienteSeleccionado_Load_1(object sender, EventArgs e)
        {

        }

        // BOTON MODIFICAR LOS DATOS DEL CLIENTE
        private void button1_Click(object sender, EventArgs e)
        {

        }

     
        

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
