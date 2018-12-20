namespace PalcoNet.Comprar
{
    partial class AgregarTarjeta
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelUSERID = new System.Windows.Forms.Label();
            this.labelNombreUser = new System.Windows.Forms.Label();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número de tarjeta";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(125, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(211, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(125, 136);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(211, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Confirmar número";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "USER ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombre usuario:";
            // 
            // labelUSERID
            // 
            this.labelUSERID.AutoSize = true;
            this.labelUSERID.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelUSERID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelUSERID.Location = new System.Drawing.Point(125, 18);
            this.labelUSERID.MaximumSize = new System.Drawing.Size(885, 23);
            this.labelUSERID.MinimumSize = new System.Drawing.Size(211, 23);
            this.labelUSERID.Name = "labelUSERID";
            this.labelUSERID.Size = new System.Drawing.Size(211, 23);
            this.labelUSERID.TabIndex = 30;
            this.labelUSERID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNombreUser
            // 
            this.labelNombreUser.AutoSize = true;
            this.labelNombreUser.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelNombreUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelNombreUser.Location = new System.Drawing.Point(125, 53);
            this.labelNombreUser.MaximumSize = new System.Drawing.Size(885, 23);
            this.labelNombreUser.MinimumSize = new System.Drawing.Size(211, 23);
            this.labelNombreUser.Name = "labelNombreUser";
            this.labelNombreUser.Size = new System.Drawing.Size(211, 23);
            this.labelNombreUser.TabIndex = 31;
            this.labelNombreUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(17, 181);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(86, 34);
            this.buttonLimpiar.TabIndex = 32;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // AgregarTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 227);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.labelNombreUser);
            this.Controls.Add(this.labelUSERID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "AgregarTarjeta";
            this.Text = "AgregarTarjeta";
            this.Load += new System.EventHandler(this.AgregarTarjeta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label labelUSERID;
        public System.Windows.Forms.Label labelNombreUser;
        private System.Windows.Forms.Button buttonLimpiar;
    }
}