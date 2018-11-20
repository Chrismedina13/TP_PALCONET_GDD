namespace PalcoNet.Login_y_seguridad
{
    partial class LOGIN
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
            this.botonIngresar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txUser = new System.Windows.Forms.TextBox();
            this.txContra = new System.Windows.Forms.TextBox();
            this.botonRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonIngresar
            // 
            this.botonIngresar.Location = new System.Drawing.Point(62, 147);
            this.botonIngresar.Name = "botonIngresar";
            this.botonIngresar.Size = new System.Drawing.Size(164, 36);
            this.botonIngresar.TabIndex = 0;
            this.botonIngresar.Text = "Ingresar";
            this.botonIngresar.UseVisualStyleBackColor = true;
            this.botonIngresar.Click += new System.EventHandler(this.botonIngresar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "PALCONET";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuario";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Contraseña";
            // 
            // txUser
            // 
            this.txUser.Location = new System.Drawing.Point(78, 60);
            this.txUser.Name = "txUser";
            this.txUser.Size = new System.Drawing.Size(148, 20);
            this.txUser.TabIndex = 4;
            this.txUser.TextChanged += new System.EventHandler(this.txUser_TextChanged);
            // 
            // txContra
            // 
            this.txContra.Location = new System.Drawing.Point(79, 106);
            this.txContra.Name = "txContra";
            this.txContra.PasswordChar = '*';
            this.txContra.Size = new System.Drawing.Size(147, 20);
            this.txContra.TabIndex = 5;
            // 
            // botonRegistrar
            // 
            this.botonRegistrar.Location = new System.Drawing.Point(104, 198);
            this.botonRegistrar.Name = "botonRegistrar";
            this.botonRegistrar.Size = new System.Drawing.Size(86, 22);
            this.botonRegistrar.TabIndex = 6;
            this.botonRegistrar.Text = "Registrarse";
            this.botonRegistrar.UseVisualStyleBackColor = true;
            // 
            // LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 232);
            this.Controls.Add(this.botonRegistrar);
            this.Controls.Add(this.txContra);
            this.Controls.Add(this.txUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonIngresar);
            this.Name = "LOGIN";
            this.Text = "LOGIN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonIngresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txUser;
        private System.Windows.Forms.TextBox txContra;
        private System.Windows.Forms.Button botonRegistrar;
    }
}