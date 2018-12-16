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
            this.dataGridViewAdentro = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUbicacionesEnLugar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdentro)).BeginInit();
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
            this.dataGridViewUbicacionesEnLugar.Location = new System.Drawing.Point(578, 85);
            this.dataGridViewUbicacionesEnLugar.MultiSelect = false;
            this.dataGridViewUbicacionesEnLugar.Name = "dataGridViewUbicacionesEnLugar";
            this.dataGridViewUbicacionesEnLugar.ReadOnly = true;
            this.dataGridViewUbicacionesEnLugar.Size = new System.Drawing.Size(539, 384);
            this.dataGridViewUbicacionesEnLugar.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(993, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Editar ubicación";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(321, 475);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(251, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Agregar ubicación";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 475);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 35);
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
            // dataGridViewAdentro
            // 
            this.dataGridViewAdentro.AllowUserToAddRows = false;
            this.dataGridViewAdentro.AllowUserToDeleteRows = false;
            this.dataGridViewAdentro.AllowUserToResizeColumns = false;
            this.dataGridViewAdentro.AllowUserToResizeRows = false;
            this.dataGridViewAdentro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAdentro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdentro.Location = new System.Drawing.Point(18, 85);
            this.dataGridViewAdentro.MultiSelect = false;
            this.dataGridViewAdentro.Name = "dataGridViewAdentro";
            this.dataGridViewAdentro.ReadOnly = true;
            this.dataGridViewAdentro.Size = new System.Drawing.Size(554, 384);
            this.dataGridViewAdentro.TabIndex = 6;
            this.dataGridViewAdentro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAdentro_CellContentClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(578, 475);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(251, 35);
            this.button4.TabIndex = 7;
            this.button4.Text = "Quitar ubicación";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gold;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.MinimumSize = new System.Drawing.Size(550, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(550, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ubicaciones no ingresadas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gold;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.Location = new System.Drawing.Point(582, 54);
            this.label3.MinimumSize = new System.Drawing.Size(530, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(530, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ubicaciones ingresadas";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(895, 475);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 35);
            this.button5.TabIndex = 10;
            this.button5.Text = "Limpiar datos";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // EditarUbicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 516);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridViewAdentro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewUbicacionesEnLugar);
            this.Name = "EditarUbicaciones";
            this.Text = "EditarUbicaciones";
            this.Load += new System.EventHandler(this.EditarUbicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUbicacionesEnLugar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdentro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUbicacionesEnLugar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewAdentro;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
    }
}