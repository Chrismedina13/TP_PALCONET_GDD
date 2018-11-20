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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ABM_Usuario.Form1 form1 = new Form1();
            //form1.Show();
            //this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            PalcoNet.Form2 home = new PalcoNet.Form2();
                
            home.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ABM_Usuario.Form3 form3 = new Form3();
            //form3.Show();
            //this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ABM_Usuario.Form8 form8 = new ABM_Usuario.Form8();
            form8.Show();
            this.Close();
        }
    }
}
