using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PalcoNet.ABM_Rol
{
    public partial class ABMROL : Form
    {
        Explorador exx;
        ABM_Rol.FormCrearNuevoRol crearRol;
        ABM_Rol.FormModificarRol modificarRol;
        ABM_Rol.deshabilitarRol eliminarRol;
        public ABMROL(Explorador ex)
        {
            exx = ex;
            InitializeComponent();
        }

        //MODIFICAR ROL
        private void button3_Click(object sender, EventArgs e)
        {
            modificarRol.Show();
            this.Hide();          
        }

        //DAR DE BAJA ROL
        private void button2_Click_1(object sender, EventArgs e)
        {
            eliminarRol.cargar();
            eliminarRol.Show();
            this.Hide();
        }

        //CREAR NUEVO ROL
        private void button1_Click_1(object sender, EventArgs e)
        {
            crearRol.Show();
            this.Hide();
        }
        //VOLVER
        private void button4_Click(object sender, EventArgs e)
        {
            exx.Show();
            this.Close();
        }

        private void ABMROL_Load(object sender, EventArgs e)
        {
            crearRol = new ABM_Rol.FormCrearNuevoRol(this);
            modificarRol = new ABM_Rol.FormModificarRol(this);
            eliminarRol = new ABM_Rol.deshabilitarRol(this);
        }

        //VOLVER
        private void button5_Click(object sender, EventArgs e)
        {
            exx.Show();
            this.Close();
        }
    }
}
