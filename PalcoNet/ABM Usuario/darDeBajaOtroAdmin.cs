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
    public partial class darDeBajaOtroAdmin : Form
    {
        ABMUSUARIO user;
        public darDeBajaOtroAdmin(ABMUSUARIO abm)
        {
            user = abm;
            InitializeComponent();
        }

        private void darDeBajaOtroAdmin_Load(object sender, EventArgs e)
        {
            llenarGrilla();
        }

        //VOLVER
        private void buttonVolver_Click(object sender, EventArgs e)
        {
            user.Show();
            this.Close();
        }

        private void llenarGrilla() {
            String comando = "SELECT usuario_Id as 'ID' ,usuario_nombre as 'Nombre usuario', rol.rol_nombre as 'ROL', CASE WHEN usuario_estado = 1 THEN 'SI' ELSE 'NO' END as 'Habilitado' FROM SQLEADOS.Usuario JOIN SQLEADOS.UsuarioXRol ON usuario_Id = usuarioXRol_usuario JOIN SQLEADOS.Rol ON rol_Id = usuarioXRol_rol WHERE (rol_Id = 1 OR rol_Id > 3) AND usuario_nombre NOT LIKE  '" + Usuario.username + "'";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(comando);
            dataGridView1.DataSource = dt;
        }

        //DAR DE BAJA
        private void button1_Click(object sender, EventArgs e)
        {
            String id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            String comando = "UPDATE SQLEADOS.Usuario SET usuario_estado = 0 where usuario_Id = " + id;
            DBConsulta.AbrirCerrarModificarDB(comando);
            llenarGrilla();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            String comando = "UPDATE SQLEADOS.Usuario SET usuario_estado = 1 where usuario_Id = " + id;
            DBConsulta.AbrirCerrarModificarDB(comando);
            llenarGrilla();
        }
    }
}
