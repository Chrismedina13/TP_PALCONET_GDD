namespace PalcoNet.Abm_Empresa_Espectaculo
{
    partial class EliminarEmpresa
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
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dataGriddView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCuit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.textBoxRazonSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGriddView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(1040, 414);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(91, 36);
            this.btnModificar.TabIndex = 34;
            this.btnModificar.Text = "DAR DE BAJA";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(28, 415);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(91, 35);
            this.btnVolver.TabIndex = 33;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dataGriddView1
            // 
            this.dataGriddView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGriddView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGriddView1.Location = new System.Drawing.Point(28, 196);
            this.dataGriddView1.MultiSelect = false;
            this.dataGriddView1.Name = "dataGriddView1";
            this.dataGriddView1.ReadOnly = true;
            this.dataGriddView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGriddView1.Size = new System.Drawing.Size(1103, 213);
            this.dataGriddView1.TabIndex = 32;
            this.dataGriddView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGriddView1_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Seleccione empresa a dar de baja";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxCuit
            // 
            this.textBoxCuit.Location = new System.Drawing.Point(235, 119);
            this.textBoxCuit.Name = "textBoxCuit";
            this.textBoxCuit.Size = new System.Drawing.Size(209, 20);
            this.textBoxCuit.TabIndex = 29;
            this.textBoxCuit.TextChanged += new System.EventHandler(this.textBoxCuit_TextChanged);
            this.textBoxCuit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCuit_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "CUIT";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(235, 75);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(209, 20);
            this.textBoxMail.TabIndex = 27;
            this.textBoxMail.TextChanged += new System.EventHandler(this.textBoxMail_TextChanged);
            this.textBoxMail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMail_KeyUp);
            // 
            // textBoxRazonSocial
            // 
            this.textBoxRazonSocial.Location = new System.Drawing.Point(235, 35);
            this.textBoxRazonSocial.Name = "textBoxRazonSocial";
            this.textBoxRazonSocial.Size = new System.Drawing.Size(209, 20);
            this.textBoxRazonSocial.TabIndex = 26;
            this.textBoxRazonSocial.TextChanged += new System.EventHandler(this.textBoxRazonSocial_TextChanged);
            this.textBoxRazonSocial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRazonSocial_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Mail:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Razon social:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 20);
            this.button1.TabIndex = 35;
            this.button1.Text = "Limpiar criterios";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EliminarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 463);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dataGriddView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCuit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.textBoxRazonSocial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EliminarEmpresa";
            this.Text = "Eliminar Empresa";
            this.Load += new System.EventHandler(this.eliminar_empresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGriddView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dataGriddView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCuit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.TextBox textBoxRazonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
    }
}