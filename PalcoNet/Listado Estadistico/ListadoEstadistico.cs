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

namespace PalcoNet.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        List<Trimestre> trimestres;
        Explorador exx;
        public ListadoEstadistico(Explorador ex)
        {
            exx = ex;
            InitializeComponent();
            trimestres = new List<Trimestre>();
            trimestres.Add(new Trimestre(1, 1, 30, 4, "1° Trimestre (Enero - Abril)"));
            trimestres.Add(new Trimestre(1, 5, 31, 8, "2° Trimestre (Mayo - Agosto)"));
            trimestres.Add(new Trimestre(1, 9, 31, 12, "3° Trimestre (Septiembre - Diciembre)"));
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            if (cmbTipo.SelectedIndex <= -1 | cmbTrimestre.SelectedIndex <= -1) MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                switch (cmbTipo.Text)
                {
                    case "Empresas con mayor cantidad de localidades no vendidas":
                        Estadisticas.cargarGriddLocalidadesNoVendidas(dataGridView1, cmbTrimestre.SelectedItem as Trimestre, añoNUD.Value);
                        break;
                    case "Clientes con mayores puntos vencidos":
                        Estadisticas.cargarGriddClientesMasPuntosVencidos(dataGridView1, cmbTrimestre.SelectedItem as Trimestre, añoNUD.Value);
                        break;
                    case "Clientes con mayor cantidad de compras":
                        Estadisticas.cargarGriddClientesMeyorCompras(dataGridView1, cmbTrimestre.SelectedItem as Trimestre, añoNUD.Value);
                        break;
                  
                    default:
                        MessageBox.Show("Problemas al cargar la grilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            exx.Show();
            this.Close();
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
            cmbTrimestre.DataSource = trimestres;
            cmbTrimestre.DisplayMember = "nombre";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }




    }
}
