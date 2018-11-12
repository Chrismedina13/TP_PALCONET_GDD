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

namespace PalcoNet.Abm_Cliente
{
    public partial class EliminarCliente : Form
    {
        public EliminarCliente()
        {
            InitializeComponent();
        }
        
        private void EliminarCliente_Load(object sender, EventArgs e)
        {
            /* ESTO LO REVISO MAS TARDE
            consultasSQLCliente.cargarGriddCliente(dataGridCliente, "", "", "","");
            dataGridCliente.SelectionChanged += new EventHandler(dataGridCliente_SelectionChanged);
             * 
             * */
        }

      

        private void eliminar_empresa_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* BOTON BUSCAR */
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridCliente.Rows.Count == 0)
            {
                return;
            }
            else {
                DialogResult = DialogResult.OK;
                return;
            }
        }

    }
}
