namespace PalcoNet.ABM_Usuario
{
    partial class IngresarNuevoAdmin
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
            this.label9 = new System.Windows.Forms.Label();
            this.botonsalir = new System.Windows.Forms.Button();
            this.botoncrear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxcontra = new System.Windows.Forms.TextBox();
            this.textBoxrepecontra = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(102, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(250, 33);
            this.label9.TabIndex = 43;
            this.label9.Text = "Crear nuevo ADMIN";
            // 
            // botonsalir
            // 
            this.botonsalir.BackColor = System.Drawing.Color.MintCream;
            this.botonsalir.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonsalir.Location = new System.Drawing.Point(29, 260);
            this.botonsalir.Margin = new System.Windows.Forms.Padding(2);
            this.botonsalir.Name = "botonsalir";
            this.botonsalir.Size = new System.Drawing.Size(111, 32);
            this.botonsalir.TabIndex = 57;
            this.botonsalir.Text = "SALIR";
            this.botonsalir.UseVisualStyleBackColor = false;
            this.botonsalir.Click += new System.EventHandler(this.buttonEmpresa_Click);
            // 
            // botoncrear
            // 
            this.botoncrear.BackColor = System.Drawing.Color.MintCream;
            this.botoncrear.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botoncrear.Location = new System.Drawing.Point(307, 260);
            this.botoncrear.Margin = new System.Windows.Forms.Padding(2);
            this.botoncrear.Name = "botoncrear";
            this.botoncrear.Size = new System.Drawing.Size(111, 32);
            this.botoncrear.TabIndex = 58;
            this.botoncrear.Text = "Crear ADMIN";
            this.botoncrear.UseVisualStyleBackColor = false;
            this.botoncrear.Click += new System.EventHandler(this.botoncrear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(26, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 59;
            this.label1.Text = "Nombre usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(26, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 60;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(26, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 61;
            this.label3.Text = "Repetir contraseña";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(178, 67);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(240, 20);
            this.textBoxNombre.TabIndex = 62;
            // 
            // textBoxcontra
            // 
            this.textBoxcontra.Location = new System.Drawing.Point(178, 109);
            this.textBoxcontra.Name = "textBoxcontra";
            this.textBoxcontra.PasswordChar = '*';
            this.textBoxcontra.Size = new System.Drawing.Size(240, 20);
            this.textBoxcontra.TabIndex = 63;
            // 
            // textBoxrepecontra
            // 
            this.textBoxrepecontra.Location = new System.Drawing.Point(178, 157);
            this.textBoxrepecontra.Name = "textBoxrepecontra";
            this.textBoxrepecontra.PasswordChar = '*';
            this.textBoxrepecontra.Size = new System.Drawing.Size(240, 20);
            this.textBoxrepecontra.TabIndex = 64;
            // 
            // IngresarNuevoAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(454, 303);
            this.Controls.Add(this.textBoxrepecontra);
            this.Controls.Add(this.textBoxcontra);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botoncrear);
            this.Controls.Add(this.botonsalir);
            this.Controls.Add(this.label9);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "IngresarNuevoAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar usuario";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button botonsalir;
        private System.Windows.Forms.Button botoncrear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxcontra;
        private System.Windows.Forms.TextBox textBoxrepecontra;
    }
}