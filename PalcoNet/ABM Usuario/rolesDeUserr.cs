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
    public partial class rolesDeUserr : Form
    {
        List<String> roles = new List<String>();
        ModificarRolDeUser atras;
        String nombreUser, idUser;
        public rolesDeUserr(ModificarRolDeUser r, String id, String nombre)
        {
            atras = r;
            nombreUser = nombre;
            idUser = id;
            InitializeComponent();
        }

        //QUITAR ROL
        private void button4_Click(object sender, EventArgs e)
        {
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);

            roles.Remove(text);
        }

        //AÑADIR ROL
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("No has seleccionado un rol aún");
                return;
            }
            
            int i = comboBox1.SelectedIndex;
            string text = comboBox1.Items[i].ToString();
            if (roles.Contains(text))
            {

                String mensaje = "Este rol ya ha sido ingresado";
                String caption = "Rol duplicado";
                MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);

            }
            else
            {

                listBox1.DisplayMember = "funcionalidad_descripcion";
                listBox1.Items.Add(text);

                roles.Add(text);

            }
        }

        //VOLVER
        private void button2_Click(object sender, EventArgs e)
        {
            atras.Show();
            this.Close();
        }

        private void cargarComboBox() {
            String query = "SELECT rol_nombre FROM SQLEADOS.Rol WHERE rol_estado = 1 AND rol_Id > 1";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());
            }
            
        }

        private void cargarListaBox() {
            String query = "SELECT rol_nombre FROM SQLEADOS.Rol JOIN SQLEADOS.UsuarioXRol r ON r.usuarioXRol_rol = rol_Id JOIN SQLEADOS.Usuario u ON u.usuario_Id = r.usuarioXRol_usuario WHERE u.usuario_Id = "+idUser;
            
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            for (int i = 0; i < dt.Rows.Count; i++) {
                String text = dt.Rows[i][0].ToString();
                listBox1.Items.Add(dt.Rows[i][0].ToString());
                roles.Add(text);
            }
        }

        private void rolesDeUserr_Load(object sender, EventArgs e)
        {
            labelUSER.Text = nombreUser;
            cargarComboBox();
            cargarListaBox();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            vaciarRolesAnteriores();
            String query = "INSERT INTO SQLEADOS.UsuarioXRol(usuarioXRol_rol, usuarioXRol_usuario) SELECT rol_Id, " + idUser + " FROM SQLEADOS.Rol  ";
            for (int i = 0; i < roles.Count(); i++)
            {
                String elemento = roles.ElementAt(i).ToString();
                if(i == 0) {
                    query += "WHERE rol_nombre LIKE '" + elemento + "'";
                }
                else {
                    query += " AND rol_nombre LIKE '"+elemento+"'";
                }
            }

            DBConsulta.AbrirCerrarModificarDB(query);
            MessageBox.Show("Se han modificado los roles de " + nombreUser);
        }

        private void vaciarRolesAnteriores() {
            String query = "DELETE FROM SQLEADOS.UsuarioXRol WHERE usuarioXRol_usuario = " + idUser;
            DBConsulta.AbrirCerrarModificarDB(query);
        }
    }
}
