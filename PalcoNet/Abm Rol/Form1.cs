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
    public partial class Form1 : Form
    {
        ABM_Rol.Form2 crearRol = new ABM_Rol.Form2();
        ABM_Rol.Form3 modificarRol = new ABM_Rol.Form3();
        ABM_Rol.Form4 eliminarRol = new ABM_Rol.Form4();

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            modificarRol.Show();
            this.Close();        
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            
            eliminarRol.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            crearRol.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PalcoNet.Form2 home = new PalcoNet.Form2();
            this.Close();
            home.Show();
        }
    }
}
