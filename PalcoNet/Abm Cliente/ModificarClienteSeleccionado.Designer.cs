namespace PalcoNet.Abm_Cliente
{
    partial class ModificarClienteSeleccionado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label15 = new System.Windows.Forms.Label();
            this.txNroTarjeta = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.Label();
            this.txEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxCuit
            // 
            this.textBoxCuit.Location = new System.Drawing.Point(124, 239);
            // 
            // textBoxCiudad
            // 
            this.textBoxCiudad.Location = new System.Drawing.Point(124, 209);
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(124, 173);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(32, 242);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 209);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 173);
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.Text = "Nombre";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Nro Tarjeta";
            // 
            // txNroTarjeta
            // 
            this.txNroTarjeta.Location = new System.Drawing.Point(124, 114);
            this.txNroTarjeta.Name = "txNroTarjeta";
            this.txNroTarjeta.Size = new System.Drawing.Size(209, 20);
            this.txNroTarjeta.TabIndex = 39;
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Location = new System.Drawing.Point(32, 148);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(32, 13);
            this.Email.TabIndex = 40;
            this.Email.Text = "Email";
            // 
            // txEmail
            // 
            this.txEmail.Location = new System.Drawing.Point(124, 145);
            this.txEmail.Name = "txEmail";
            this.txEmail.Size = new System.Drawing.Size(209, 20);
            this.txEmail.TabIndex = 41;
            // 
            // ModificarClienteSeleccionado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 487);
            this.Controls.Add(this.txEmail);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.txNroTarjeta);
            this.Controls.Add(this.label15);
            this.Name = "ModificarClienteSeleccionado";
            this.Text = "ModificarClienteSeleccionado";
            this.Load += new System.EventHandler(this.ModificarClienteSeleccionado_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.textBoxRazonSocial, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.textBoxTelefono, 0);
            this.Controls.SetChildIndex(this.textBoxCiudad, 0);
            this.Controls.SetChildIndex(this.textBoxCuit, 0);
            this.Controls.SetChildIndex(this.volver_boton, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txNroTarjeta, 0);
            this.Controls.SetChildIndex(this.Email, 0);
            this.Controls.SetChildIndex(this.txEmail, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txNroTarjeta;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.TextBox txEmail;
    }
}