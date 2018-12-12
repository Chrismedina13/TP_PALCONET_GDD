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

namespace PalcoNet.Generar_Publicacion
{
    public partial class AltaPublicacion : Form
    {
        public AltaPublicacion(int usuario)
        {
            InitializeComponent();
            textBoxUsuario.Text =  Convert.ToString(usuario);
            textBoxCodigo.Text = GenerarPublicacion.obtenerCodigoPublicacion();
            GenerarPublicacion.llenarComboRubro(comboBoxRubro);
            GenerarPublicacion.llenarComboGrado(comboBoxGrado);
            GenerarPublicacion.cargarGriddUbicaciones(dataGridViewUbicaciones);

            DataGridViewColumn columT = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            columT.CellTemplate = cell;
            columT.Name = "identidficador";
            dataGridView1.Columns.Add(columT);

            DataGridViewColumn colum2 = new DataGridViewColumn();
            DataGridViewCell cell2 = new DataGridViewTextBoxCell();
            colum2.CellTemplate = cell2;
            colum2.Name = "ubicacion_fila";
            dataGridView1.Columns.Add(colum2);

            DataGridViewColumn colum3 = new DataGridViewColumn();
            DataGridViewCell cell3 = new DataGridViewTextBoxCell();
            colum3.CellTemplate = cell3;
            colum3.Name = "ubicacion_asiento";
            dataGridView1.Columns.Add(colum3);

            DataGridViewColumn colum4 = new DataGridViewColumn();
            DataGridViewCell cell4 = new DataGridViewTextBoxCell();
            colum4.CellTemplate = cell4;
            colum4.Name = "ubicacion_sin_numerar";
            dataGridView1.Columns.Add(colum4);

            DataGridViewColumn colum5 = new DataGridViewColumn();
            DataGridViewCell cell5 = new DataGridViewTextBoxCell();
            colum5.CellTemplate = cell5;
            colum5.Name = "ubicacion_Tipo_codigo";
            dataGridView1.Columns.Add(colum5);

            DataGridViewColumn colum6 = new DataGridViewColumn();
            DataGridViewCell cell6 = new DataGridViewTextBoxCell();
            colum6.CellTemplate = cell6;
            colum6.Name = "ubicacion_Tipo_Descripcion";
            dataGridView1.Columns.Add(colum6);

        }

        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();


            foreach( DataGridViewRow  row in dataGridViewUbicaciones.SelectedRows){

                DataGridViewRow filaNueva = new DataGridViewRow();
                filaNueva.CreateCells(dataGridView1);
                filaNueva.Cells[0].Value = row.Cells[0].Value;
                filaNueva.Cells[1].Value = row.Cells[1].Value;
                filaNueva.Cells[2].Value = row.Cells[2].Value;
                filaNueva.Cells[3].Value = row.Cells[3].Value;
                filaNueva.Cells[4].Value = row.Cells[4].Value;
                filaNueva.Cells[5].Value = row.Cells[5].Value;
                dataGridView1.Rows.Add(filaNueva);
                
            }

        }

        private void AltaPublicacion_Load(object sender, EventArgs e)
        {

        }
    }
}
