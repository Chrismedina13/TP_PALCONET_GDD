namespace PalcoNet.Comprar
{
    partial class Comprar
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
            this.labelPaginas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.botonsiguiente = new System.Windows.Forms.Button();
            this.botonAnterior = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonUltimaHoja = new System.Windows.Forms.Button();
            this.buttonPrimeraHoja = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPaginas
            // 
            this.labelPaginas.AutoSize = true;
            this.labelPaginas.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelPaginas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPaginas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaginas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelPaginas.Location = new System.Drawing.Point(396, 516);
            this.labelPaginas.Name = "labelPaginas";
            this.labelPaginas.Size = new System.Drawing.Size(36, 22);
            this.labelPaginas.TabIndex = 15;
            this.labelPaginas.Text = "1/1";
            this.labelPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(367, 492);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "PÁGINA";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(17, 495);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 48);
            this.button3.TabIndex = 13;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // botonsiguiente
            // 
            this.botonsiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonsiguiente.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonsiguiente.Location = new System.Drawing.Point(491, 498);
            this.botonsiguiente.Name = "botonsiguiente";
            this.botonsiguiente.Size = new System.Drawing.Size(45, 45);
            this.botonsiguiente.TabIndex = 12;
            this.botonsiguiente.Text = ">";
            this.botonsiguiente.UseVisualStyleBackColor = true;
            this.botonsiguiente.Click += new System.EventHandler(this.botonsiguiente_Click);
            // 
            // botonAnterior
            // 
            this.botonAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAnterior.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonAnterior.Location = new System.Drawing.Point(289, 498);
            this.botonAnterior.Name = "botonAnterior";
            this.botonAnterior.Size = new System.Drawing.Size(45, 45);
            this.botonAnterior.TabIndex = 11;
            this.botonAnterior.Text = "<";
            this.botonAnterior.UseVisualStyleBackColor = true;
            this.botonAnterior.Click += new System.EventHandler(this.botonAnterior_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(797, 286);
            this.dataGridView1.TabIndex = 16;
            // 
            // buttonUltimaHoja
            // 
            this.buttonUltimaHoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUltimaHoja.Location = new System.Drawing.Point(542, 498);
            this.buttonUltimaHoja.Name = "buttonUltimaHoja";
            this.buttonUltimaHoja.Size = new System.Drawing.Size(127, 45);
            this.buttonUltimaHoja.TabIndex = 18;
            this.buttonUltimaHoja.Text = "Última hoja";
            this.buttonUltimaHoja.UseVisualStyleBackColor = true;
            this.buttonUltimaHoja.Click += new System.EventHandler(this.buttonUltimaHoja_Click);
            // 
            // buttonPrimeraHoja
            // 
            this.buttonPrimeraHoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrimeraHoja.Location = new System.Drawing.Point(154, 498);
            this.buttonPrimeraHoja.Name = "buttonPrimeraHoja";
            this.buttonPrimeraHoja.Size = new System.Drawing.Size(127, 45);
            this.buttonPrimeraHoja.TabIndex = 17;
            this.buttonPrimeraHoja.Text = "Primera hoja";
            this.buttonPrimeraHoja.UseVisualStyleBackColor = true;
            this.buttonPrimeraHoja.Click += new System.EventHandler(this.buttonPrimeraHoja_Click);
            // 
            // Comprar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 555);
            this.Controls.Add(this.buttonUltimaHoja);
            this.Controls.Add(this.buttonPrimeraHoja);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelPaginas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.botonsiguiente);
            this.Controls.Add(this.botonAnterior);
            this.Name = "Comprar";
            this.Text = "Comprar";
            this.Load += new System.EventHandler(this.Comprar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelPaginas;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button botonsiguiente;
        public System.Windows.Forms.Button botonAnterior;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Button buttonUltimaHoja;
        public System.Windows.Forms.Button buttonPrimeraHoja;
    }
}