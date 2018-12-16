namespace PalcoNet.Registro_de_Usuario
{
    partial class RegistroUser
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
            this.label3 = new System.Windows.Forms.Label();
            this.botonCliente = new System.Windows.Forms.Button();
            this.buttonEmpresa = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(124, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Elija el rol de usuario ";
            // 
            // botonCliente
            // 
            this.botonCliente.Location = new System.Drawing.Point(12, 70);
            this.botonCliente.Name = "botonCliente";
            this.botonCliente.Size = new System.Drawing.Size(236, 33);
            this.botonCliente.TabIndex = 10;
            this.botonCliente.Text = "CLIENTE";
            this.botonCliente.UseVisualStyleBackColor = true;
            this.botonCliente.Click += new System.EventHandler(this.botonRegistrar_Click);
            // 
            // buttonEmpresa
            // 
            this.buttonEmpresa.Location = new System.Drawing.Point(254, 70);
            this.buttonEmpresa.Name = "buttonEmpresa";
            this.buttonEmpresa.Size = new System.Drawing.Size(208, 33);
            this.buttonEmpresa.TabIndex = 11;
            this.buttonEmpresa.Text = "EMPRESA";
            this.buttonEmpresa.UseVisualStyleBackColor = true;
            this.buttonEmpresa.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(254, 119);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "Seleccione un rol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "Si no quiere elegir Cliente o Empresa\r\nSeleccione un rol de los siguientes\r\n";
            // 
            // buttonRol
            // 
            this.buttonRol.Location = new System.Drawing.Point(254, 166);
            this.buttonRol.Name = "buttonRol";
            this.buttonRol.Size = new System.Drawing.Size(208, 33);
            this.buttonRol.TabIndex = 14;
            this.buttonRol.Text = "Seleccionar rol";
            this.buttonRol.UseVisualStyleBackColor = true;
            this.buttonRol.Click += new System.EventHandler(this.buttonRol_Click);
            // 
            // RegistroUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 211);
            this.Controls.Add(this.buttonRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonEmpresa);
            this.Controls.Add(this.botonCliente);
            this.Controls.Add(this.label3);
            this.Name = "RegistroUser";
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.RegistroUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button botonCliente;
        private System.Windows.Forms.Button buttonEmpresa;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRol;
    }
}