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
    public partial class ModificarRolDeUser : Form
    {
        ABMUSUARIO user;
        public ModificarRolDeUser(ABMUSUARIO abm)
        {
            user = abm;
            InitializeComponent();
        }

        private void ModificarRolDeUser_Load(object sender, EventArgs e)
        {
            String query = "SELECT usuario_Id, usuario_nombre FROM SQLEADOS.Usuario where usuario_administrador = 0";
            dataGridView1.DataSource = DBConsulta.AbrirCerrarObtenerConsulta(query);
        }

        //BOTON BUSCAR
        private void button3_Click(object sender, EventArgs e)
        {
            String query = "SELECT usuario_Id, usuario_nombre FROM SQLEADOS.Usuario where usuario_administrador = 0 AND usuario_nombre LIKE '%"+textBox1.Text+"%'";
            dataGridView1.DataSource = DBConsulta.AbrirCerrarObtenerConsulta(query);
        }

        //IR A MODIFICAR EL ROL DEL USER SELECCIONADO
        private void button1_Click(object sender, EventArgs e)
        {
            String idUser = dataGridView1.SelectedCells[0].Value.ToString();
            String nombreUser = dataGridView1.SelectedCells[1].Value.ToString();
            rolesDeUserr rol = new rolesDeUserr(this, idUser, nombreUser);
            rol.Show();
            this.Hide();
        }

        //VOLVER
        private void button2_Click(object sender, EventArgs e)
        {
            user.Show();
            this.Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            //LIMPIAR
            textBox1.Text = "";
            dataGridView1.DataSource = new DataTable();
        }
    }
}
