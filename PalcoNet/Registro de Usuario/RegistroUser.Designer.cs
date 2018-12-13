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
            this.botonRegistrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Elija el tipo de usuario que sos";
            // 
            // botonRegistrar
            // 
            this.botonRegistrar.Location = new System.Drawing.Point(12, 70);
            this.botonRegistrar.Name = "botonRegistrar";
            this.botonRegistrar.Size = new System.Drawing.Size(161, 33);
            this.botonRegistrar.TabIndex = 10;
            this.botonRegistrar.Text = "CLIENTE";
            this.botonRegistrar.UseVisualStyleBackColor = true;
            this.botonRegistrar.Click += new System.EventHandler(this.botonRegistrar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "EMPRESA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // RegistroUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 118);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.botonRegistrar);
            this.Controls.Add(this.label3);
            this.Name = "RegistroUser";
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.RegistroUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button botonRegistrar;
        private System.Windows.Forms.Button button1;
    }
}