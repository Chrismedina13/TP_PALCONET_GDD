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

        public ListadoEstadistico()
        {
            InitializeComponent();
            trimestres = new List<Trimestre>();
            trimestres.Add(new Trimestre(1, 1, 31, 3, "1° Trimestre (Enero - Marzo)"));
            trimestres.Add(new Trimestre(1, 4, 30, 6, "2° Trimestre (Abril - Junio)"));
            trimestres.Add(new Trimestre(1, 7, 30, 9, "3° Trimestre (Julio - Septiembre)"));
            trimestres.Add(new Trimestre(1, 10, 31, 12, "4° Trimestre (Octubre - Diciembre)"));
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
            this.Close();

        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
            cmbTrimestre.DataSource = trimestres;
            cmbTrimestre.DisplayMember = "nombre";
        }




    }
}
