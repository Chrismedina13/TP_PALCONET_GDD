using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Support
{
    public partial class volver : Form
    {
        public volver()
        {
            InitializeComponent();
        }

        public void volver_boton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
