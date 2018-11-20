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

namespace PalcoNet.Login_y_seguridad
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {
            if (txContra.Text.Trim() == "" || txUser.Text.Trim() == "") {
                MessageBox.Show("RELLENE AMBOS CAMPOS PARA INGRESAR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int resultado = PalcoNet.Support.LoginSQL.corroborarDatos(txUser.Text.Trim(), txContra.Text.Trim());
            if (resultado == 1){
                //AVANZA A LA SIGUEINTE VENTANA
                this.Hide();

            }
            if (resultado == 2) { 
                //AVANZA A LA SELECCION DE ROL
                this.Hide();
                SeleccionarROL sl = new SeleccionarROL(txUser.Text.Trim());
                sl.Show();
            }
            // SE QUEDA EN LA MISMA VENTANA
            return;
        }
    }
}
