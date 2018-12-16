using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using PalcoNet.Support;

namespace PalcoNet
{
    public partial class Explorador : Form
    {
        string rol;

        SqlConnection coneccion;
        SqlCommand cargarfun, cargaradmin;
        Inicio ini;
        public Explorador(Inicio i)
        {
            ini = i;
            rol = Usuario.Rol;
            InitializeComponent();
            coneccion = PalcoNet.Support.Conexion.conectar();
            coneccion.Open();
        }

        private bool esRolAdmin(String rol) {

            return true;
        }

    //CARGA DEL COMBOBOX
        private void Form2_Load(object sender, EventArgs e)
        {
            String obtenerFuncionalidadSegunRol = "SELECT funcionalidad_descripcion FROM SQLEADOS.Funcionalidad JOIN SQLEADOS.FuncionalidadXRol ON funcionalidad_Id = funcionalidadXRol_funcionalidad JOIN SQLEADOS.ROl ON rol_Id = funcionalidadXRol_rol WHERE rol_nombre LIKE '"+Usuario.Rol+"'";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(obtenerFuncionalidadSegunRol);

            for (int i = 0; i < dt.Rows.Count; i++) { 
                comboBoxVistas.Items.Add(dt.Rows[i][0].ToString());
            }
        }



        //ABMUSUARIO
        private void button2_Click(object sender, EventArgs e)
        {
            ABM_Usuario.ABMUSUARIO abmUser = new ABM_Usuario.ABMUSUARIO(this);
            abmUser.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
    //        ABM_Rol.ABMROL abmRol = new ABM_Rol.ABMROL();
    //        abmRol.Show();
    //        this.Hide();
        }

        private void realizarAccion(String nombre)
        {
            if (nombre.Equals("ABM de Rol"))
            {
                ABM_Rol.ABMROL formRol = new ABM_Rol.ABMROL(this);
                formRol.Show();
                this.Hide();
            }

            if (nombre.Equals("Registro de usuarios"))
            {
                ABM_Usuario.ABMUSUARIO formUser = new ABM_Usuario.ABMUSUARIO(this);
                formUser.Show();
                this.Hide();
            }
        }

        //VOLVER, SI ENTRO POR AQUI, SOLO CONTINUA AL EXPLORADOR
        private void button2_Click_1(object sender, EventArgs e)
        {
            PalcoNet.CambiarContra xxx = new PalcoNet.CambiarContra(Usuario.username, this, null, false);
            xxx.Show();
            this.Hide();
        }


        //CERRAR SECION
        private void button1_Click_1(object sender, EventArgs e)
        {
            Usuario.username = "";
            Usuario.Rol = "";
            ini.Show();
            this.Close();
        }

        //IR A LA VISTA SELECCIONADA
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBoxVistas.SelectedItem == null)
            {
                MessageBox.Show("No has seleccionado ninguna vista aún");
                return;
            }
            String vista = comboBoxVistas.SelectedItem.ToString();
            if (vista == "ABM de Rol") {
                PalcoNet.ABM_Rol.ABMROL abmrol = new PalcoNet.ABM_Rol.ABMROL(this);
                abmrol.Show();
                this.Hide();
            }
            if (vista == "ABM de Clientes")
            {
                PalcoNet.Abm_Cliente.ABMCliente cliente = new PalcoNet.Abm_Cliente.ABMCliente(this);
                cliente.Show();
                this.Hide();
            }
            if (vista == "Registro de usuarios")
            {
                PalcoNet.ABM_Usuario.ABMUSUARIO user = new PalcoNet.ABM_Usuario.ABMUSUARIO(this);
                user.Show();
                this.Hide();
            }
            if (vista == "ABM de Empresa de espectaculo")
            {
                PalcoNet.Abm_Empresa_Espectaculo.ABMEmpresa emp = new PalcoNet.Abm_Empresa_Espectaculo.ABMEmpresa(this);
                emp.Show();
                this.Hide();
            }
            if (vista == "ABM Grado de publicacion")
            {
                PalcoNet.Abm_Grado.GradoPublicacion gr = new PalcoNet.Abm_Grado.GradoPublicacion(this);
                gr.Show();
            }
            if (vista == "Generar Publicacion")
            {
                PalcoNet.Generar_Publicacion.AltaPublicacion altaPubl = new PalcoNet.Generar_Publicacion.AltaPublicacion(this);
                altaPubl.Show();
                this.Hide();
            }
            if (vista == "Historial de cliente")
            {
                PalcoNet.Historial_Cliente.Historial history = new PalcoNet.Historial_Cliente.Historial(Usuario.ID ,this);
                history.Show();
                this.Hide();
            }
            if (vista == "Canje y Administracion de puntos")
            {
                PalcoNet.Canje_Puntos.canjePuntos canjepu = new PalcoNet.Canje_Puntos.canjePuntos(Usuario.ID ,this);
                canjepu.Show();
                this.Hide();
            }
            if (vista == "Comprar")
            {
                PalcoNet.Comprar.ComprarPrincipal compra = new PalcoNet.Comprar.ComprarPrincipal(Usuario.ID, this);
                compra.Show();
                this.Hide();
            }
            if (vista == "Editar Publicacion")
            {
                PalcoNet.Editar_Publicacion.EditarPublicacion edit = new PalcoNet.Editar_Publicacion.EditarPublicacion(this);
                edit.Show();
                this.Hide();
            }

            if (vista == "Listado Estadistico")
            {
                PalcoNet.Listado_Estadistico.ListadoEstadistico lista = new PalcoNet.Listado_Estadistico.ListadoEstadistico(this);
                lista.Show();
                this.Hide();
            }

            if (vista == "Generar rendicion de comisiones")
            {
                PalcoNet.Generar_Rendicion_Comisiones.GenerarFacturaDeComisiones factura = new PalcoNet.Generar_Rendicion_Comisiones.GenerarFacturaDeComisiones(this);
                factura.entrar();
                factura.Show();
                this.Hide();
            }

        }
        


    }
}
