namespace PalcoNet.Generar_Rendicion_Comisiones
{
    partial class GenerarFacturaDeComisiones
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.botonvolver = new System.Windows.Forms.Button();
            this.buttonGenerarFactura = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTotalACobrar = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelNroFactura = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelNroPublicacion = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelGradoPublicacion = new System.Windows.Forms.Label();
            this.labelComision = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelNombrePublicacion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelEmpresa = new System.Windows.Forms.Label();
            this.labelCUIT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 215);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(648, 355);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.Location = new System.Drawing.Point(143, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generar Factura de comisiones";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button1.Location = new System.Drawing.Point(393, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Buscar Empresa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(22, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(365, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Generar Factura por publicaciones no cobradas";
            // 
            // botonvolver
            // 
            this.botonvolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonvolver.Location = new System.Drawing.Point(13, 620);
            this.botonvolver.Name = "botonvolver";
            this.botonvolver.Size = new System.Drawing.Size(147, 47);
            this.botonvolver.TabIndex = 4;
            this.botonvolver.Text = "VOLVER";
            this.botonvolver.UseVisualStyleBackColor = true;
            this.botonvolver.Click += new System.EventHandler(this.botonvolver_Click);
            // 
            // buttonGenerarFactura
            // 
            this.buttonGenerarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerarFactura.Location = new System.Drawing.Point(361, 620);
            this.buttonGenerarFactura.Name = "buttonGenerarFactura";
            this.buttonGenerarFactura.Size = new System.Drawing.Size(300, 47);
            this.buttonGenerarFactura.TabIndex = 5;
            this.buttonGenerarFactura.Text = "GENERAR NUEVA FACTURA";
            this.buttonGenerarFactura.UseVisualStyleBackColor = true;
            this.buttonGenerarFactura.Click += new System.EventHandler(this.buttonGenerarFactura_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(183, 588);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "TOTAL A COBRAR:";
            // 
            // labelTotalACobrar
            // 
            this.labelTotalACobrar.AutoSize = true;
            this.labelTotalACobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelTotalACobrar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTotalACobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalACobrar.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTotalACobrar.Location = new System.Drawing.Point(361, 582);
            this.labelTotalACobrar.MinimumSize = new System.Drawing.Size(300, 35);
            this.labelTotalACobrar.Name = "labelTotalACobrar";
            this.labelTotalACobrar.Size = new System.Drawing.Size(300, 35);
            this.labelTotalACobrar.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nro Factura:";
            // 
            // labelNroFactura
            // 
            this.labelNroFactura.AutoSize = true;
            this.labelNroFactura.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelNroFactura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelNroFactura.Location = new System.Drawing.Point(105, 161);
            this.labelNroFactura.MinimumSize = new System.Drawing.Size(150, 20);
            this.labelNroFactura.Name = "labelNroFactura";
            this.labelNroFactura.Size = new System.Drawing.Size(150, 20);
            this.labelNroFactura.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nro Publicación:";
            // 
            // labelNroPublicacion
            // 
            this.labelNroPublicacion.AutoSize = true;
            this.labelNroPublicacion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelNroPublicacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelNroPublicacion.Location = new System.Drawing.Point(105, 131);
            this.labelNroPublicacion.MinimumSize = new System.Drawing.Size(150, 20);
            this.labelNroPublicacion.Name = "labelNroPublicacion";
            this.labelNroPublicacion.Size = new System.Drawing.Size(150, 20);
            this.labelNroPublicacion.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(390, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Grado de publicacón:";
            // 
            // labelGradoPublicacion
            // 
            this.labelGradoPublicacion.AutoSize = true;
            this.labelGradoPublicacion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelGradoPublicacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGradoPublicacion.Location = new System.Drawing.Point(510, 131);
            this.labelGradoPublicacion.MinimumSize = new System.Drawing.Size(150, 20);
            this.labelGradoPublicacion.Name = "labelGradoPublicacion";
            this.labelGradoPublicacion.Size = new System.Drawing.Size(150, 20);
            this.labelGradoPublicacion.TabIndex = 13;
            // 
            // labelComision
            // 
            this.labelComision.AutoSize = true;
            this.labelComision.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelComision.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelComision.Location = new System.Drawing.Point(510, 161);
            this.labelComision.MinimumSize = new System.Drawing.Size(150, 20);
            this.labelComision.Name = "labelComision";
            this.labelComision.Size = new System.Drawing.Size(150, 20);
            this.labelComision.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(390, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "% Comisión:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label7.Location = new System.Drawing.Point(11, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nombre de publicación:";
            // 
            // labelNombrePublicacion
            // 
            this.labelNombrePublicacion.AutoSize = true;
            this.labelNombrePublicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelNombrePublicacion.Location = new System.Drawing.Point(212, 101);
            this.labelNombrePublicacion.Name = "labelNombrePublicacion";
            this.labelNombrePublicacion.Size = new System.Drawing.Size(0, 20);
            this.labelNombrePublicacion.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "CUIT Empresa:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Nombre empresa:";
            // 
            // labelEmpresa
            // 
            this.labelEmpresa.AutoSize = true;
            this.labelEmpresa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelEmpresa.Location = new System.Drawing.Point(105, 192);
            this.labelEmpresa.MinimumSize = new System.Drawing.Size(150, 20);
            this.labelEmpresa.Name = "labelEmpresa";
            this.labelEmpresa.Size = new System.Drawing.Size(150, 20);
            this.labelEmpresa.TabIndex = 20;
            // 
            // labelCUIT
            // 
            this.labelCUIT.AutoSize = true;
            this.labelCUIT.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelCUIT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCUIT.Location = new System.Drawing.Point(510, 192);
            this.labelCUIT.MinimumSize = new System.Drawing.Size(150, 20);
            this.labelCUIT.Name = "labelCUIT";
            this.labelCUIT.Size = new System.Drawing.Size(150, 20);
            this.labelCUIT.TabIndex = 21;
            // 
            // GenerarFacturaDeComisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 674);
            this.Controls.Add(this.labelCUIT);
            this.Controls.Add(this.labelEmpresa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelNombrePublicacion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelComision);
            this.Controls.Add(this.labelGradoPublicacion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelNroPublicacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelNroFactura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelTotalACobrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonGenerarFactura);
            this.Controls.Add(this.botonvolver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GenerarFacturaDeComisiones";
            this.Text = "GenerarFacturaDeComisiones";
            this.Load += new System.EventHandler(this.GenerarFacturaDeComisiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botonvolver;
        private System.Windows.Forms.Button buttonGenerarFactura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTotalACobrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelNroFactura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelNroPublicacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelGradoPublicacion;
        private System.Windows.Forms.Label labelComision;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelNombrePublicacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelEmpresa;
        private System.Windows.Forms.Label labelCUIT;
    }
}