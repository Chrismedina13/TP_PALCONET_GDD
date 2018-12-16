using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.ABM_Usuario
{
    public partial class ABMUSUARIO : Form
    {
        Explorador ex;
        public ABMUSUARIO(Explorador exp)
        {
            ex = exp;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            darDeBajaOtroAdmin baja = new darDeBajaOtroAdmin(this);
            baja.Show();
            this.Hide();
            //ABM_Usuario.Form1 form1 = new Form1();
            //form1.Show();
            //this.Close();
        }

        //VOLVER
        private void button4_Click(object sender, EventArgs e)
        {
            ex.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ABM_Usuario.Form3 form3 = new Form3();
            //form3.Show();
            //this.Close();
        }

        //INGRESAR NUEVO ADMIN
        private void button3_Click(object sender, EventArgs e)
        {
            ABM_Usuario.tipoUserAAgregar form8 = new ABM_Usuario.tipoUserAAgregar(this);
            form8.Show();
            this.Hide();
        }

        private void ABMUSUARIO_Load(object sender, EventArgs e)
        {

        }

        //VOLVER
        private void button2_Click_1(object sender, EventArgs e)
        {
            ex.Show();
            this.Close();
        }

        private void buttonModificarRoles_Click(object sender, EventArgs e)
        {
            ModificarRolDeUser roluser = new ModificarRolDeUser(this);
            roluser.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MODIFICAR ROL DE UN USUARIO
            ModificarRolDeUser mod = new ModificarRolDeUser(this);
            mod.Show();
            this.Hide();
        }
    }
}
