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

namespace PalcoNet.ABM_Usuario
{
    public partial class tipoUserAAgregar : Form
    {
        ABMUSUARIO u;
        public tipoUserAAgregar(ABMUSUARIO user)
        {
            u = user;
            InitializeComponent();
        }

        private void tipoUserAAgregar_Load(object sender, EventArgs e)
        {
            String tomarRolesMenosClienteYEmpresa = "SELECT rol_nombre FROM SQLEADOS.Rol where rol_Id != 2 AND rol_Id != 3";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(tomarRolesMenosClienteYEmpresa);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows.Add(dt.Rows[i][0].ToString());
            }
        }

        //BOTON SELECCIONAR
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("No has seleccionado ningún rol aún", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IngresarNuevoAdmin n;
            if (comboBox1.SelectedItem.ToString() == "Administrativo")
            {
                n = new IngresarNuevoAdmin(this, true, false, null, null);
            }
            else {
                n = new IngresarNuevoAdmin(this, false, true, null, comboBox1.SelectedItem.ToString());
            }
            n.Show();
            this.Hide();
        }

        //VOLVER
        private void button2_Click(object sender, EventArgs e)
        {
            u.Show();
            this.Close();
        }
    }
}
