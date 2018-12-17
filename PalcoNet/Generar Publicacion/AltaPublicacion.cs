﻿using System;
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
        Explorador exx;
        public AltaPublicacion(Explorador ex)
        {
            exx = ex;
            InitializeComponent();

            checkBox1.Checked = false;
            buttonGeneracionMAsiva.Enabled = false;
            button1.Enabled = true;
            dateTimePickerFechaEspectaculo.Enabled = true;
            dataGridView2.Enabled = false;
            dateTimePickerGeneracionMasiva.Enabled = false;
            buttonHorario.Enabled = false;

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

            textBoxUsuario.Text = Convert.ToString(Usuario.ID);
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

            DataGridViewColumn colum7 = new DataGridViewColumn();
            DataGridViewCell cell7 = new DataGridViewTextBoxCell();
            colum7.CellTemplate = cell7;
            colum7.Name = "Precio";
            dataGridView1.Columns.Add(colum7);

            columT.ReadOnly = true;

            colum2.ReadOnly = true;
            colum3.ReadOnly = true;
            colum4.ReadOnly = true;
            colum5.ReadOnly = true;
            colum6.ReadOnly = true;
            colum7.ReadOnly = false;


            textBoxCodigo.Enabled = false;
            textBoxUsuario.Enabled = false;



            dateTimePickerFechaEspectaculo.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaEspectaculo.CustomFormat = "dd/MM/yyyy h: mm:ss tt";
            dateTimePickerFechaEspectaculo.ShowUpDown = true;


            dateTimePickerFechaPublicacion.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaPublicacion.CustomFormat = "dd/MM/yyyy";


            dateTimePickerGeneracionMasiva.Format = DateTimePickerFormat.Custom;
            dateTimePickerGeneracionMasiva.CustomFormat = "dd/MM/yyyy h: mm:ss tt";

            dataGridView1.AllowUserToAddRows = false;
            dataGridViewUbicaciones.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            validarAlta();


            string rubroElegido = GenerarPublicacion.idRubro(comboBoxRubro.SelectedItem.ToString());

            string gradoPublicacion = GenerarPublicacion.idGrado(comboBoxGrado.SelectedItem.ToString());

            int cantidadDeUbicaciones = dataGridView1.Rows.Count;

            string estadoPublicacion = comboBoxEstado.SelectedItem.ToString();


            DateTime fechaPublicacion = dateTimePickerFechaPublicacion.Value;

            DateTime fechaEspectaculo = dateTimePickerFechaEspectaculo.Value;
        
           
            GenerarPublicacion.insertarPublicacion(textBoxCodigo.Text,textBoxUsuario.Text,rubroElegido,gradoPublicacion,textBoxDescripcion.Text
                ,cantidadDeUbicaciones,estadoPublicacion,fechaPublicacion,fechaEspectaculo,textBoxDireccion.Text);



            string idUbicacion;
            string precioUbi;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {

                idUbicacion = fila.Cells[0].Value.ToString();
                precioUbi = fila.Cells[6].Value.ToString();

                GenerarPublicacion.ubixPubli(idUbicacion,textBoxCodigo.Text,precioUbi);
            
            }

            limpiar();

        }

        private void buttonGeneracionMAsiva_Click(object sender, EventArgs e)
        {
           
        }

        //VOLVER
        private void button3_Click(object sender, EventArgs e)
        {
            exx.Show();
            this.Close();
        }

        public void validarAlta() {


            if (textBoxDescripcion.Text.Trim() == "" | dateTimePickerFechaEspectaculo.Text.Trim() == "" | dateTimePickerFechaPublicacion.Text.Trim() == "" | comboBoxEstado.Text.Trim() == ""
               | comboBoxRubro.Text.Trim() == "" | comboBoxGrado.Text.Trim() == "")
            {

                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (dataGridView1.Rows.Count <= 1)
            {

                MessageBox.Show("Tiene que seleccionar ubicaciones de la publicacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (dateTimePickerFechaPublicacion.Value.Date >= dateTimePickerFechaEspectaculo.Value.Date)
            {

                MessageBox.Show("La fecha de espectaculo tiene que ser mayor a la fecha de Publicacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {

                if (fila.Cells[6].Value == null)
                {
                    MessageBox.Show("Falta completar el precio de asientos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (!System.Text.RegularExpressions.Regex.IsMatch(fila.Cells[6].Value.ToString(), @"^\d+$"))
                {
                    MessageBox.Show("Sólo se permiten numeros en el precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


        
        }

        public void limpiar() {

            textBoxDescripcion.Text = "";
            textBoxDireccion.Text = "";
            dateTimePickerFechaEspectaculo.Value = DateTime.Today;
  
            comboBoxEstado.SelectedIndex = -1;
            comboBoxGrado.SelectedIndex = -1;
            comboBoxRubro.SelectedIndex = -1;
            dataGridView1.Rows.Clear();
            textBoxCodigo.Text = GenerarPublicacion.obtenerCodigoPublicacion();



            dataGridViewUbicaciones.ClearSelection();

        
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                button1.Enabled = false;
                buttonGeneracionMAsiva.Enabled = true;
                dateTimePickerFechaEspectaculo.Enabled = false;
                dataGridView2.Enabled = true;
                dateTimePickerGeneracionMasiva.Enabled = true;
                buttonHorario.Enabled = true;


            }
            else {

                buttonGeneracionMAsiva.Enabled = false;
                button1.Enabled = true;
                dateTimePickerFechaEspectaculo.Enabled = true;
                dataGridView2.Enabled = false;
                dateTimePickerGeneracionMasiva.Enabled = false;
                buttonHorario.Enabled = false;

            
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewUbicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
