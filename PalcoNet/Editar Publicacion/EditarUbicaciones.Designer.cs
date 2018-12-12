namespace PalcoNet.Editar_Publicacion
{
    partial class EditarUbicaciones
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
            this.dataGridViewUbicacionesEnLugar = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUbicacionesEnLugar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUbicacionesEnLugar
            // 
            this.dataGridViewUbicacionesEnLugar.AllowUserToAddRows = false;
            this.dataGridViewUbicacionesEnLugar.AllowUserToDeleteRows = false;
            this.dataGridViewUbicacionesEnLugar.AllowUserToResizeColumns = false;
            this.dataGridViewUbicacionesEnLugar.AllowUserToResizeRows = false;
            this.dataGridViewUbicacionesEnLugar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUbicacionesEnLugar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUbicacionesEnLugar.Location = new System.Drawing.Point(12, 53);
            this.dataGridViewUbicacionesEnLugar.Name = "dataGridViewUbicacionesEnLugar";
            this.dataGridViewUbicacionesEnLugar.Size = new System.Drawing.Size(416, 416);
            this.dataGridViewUbicacionesEnLugar.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Editar ubicación";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(160, 475);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Agregar ubicación";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 475);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Salir y actualizar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Editar las ubicaciones";
            // 
            // EditarUbicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 516);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewUbicacionesEnLugar);
            this.Name = "EditarUbicaciones";
            this.Text = "EditarUbicaciones";
            this.Load += new System.EventHandler(this.EditarUbicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUbicacionesEnLugar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUbicacionesEnLugar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
    }
}