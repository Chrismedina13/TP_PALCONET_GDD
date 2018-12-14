namespace PalcoNet.Generar_Publicacion
{
    partial class AltaPublicacion
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
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.Descripcion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerFechaEspectaculo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxRubro = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxGrado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewUbicaciones = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonGeneracionMAsiva = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePickerFechaPublicacion = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUbicaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Location = new System.Drawing.Point(135, 23);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.ReadOnly = true;
            this.textBoxCodigo.Size = new System.Drawing.Size(100, 20);
            this.textBoxCodigo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo Publicacion: ";
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(135, 68);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(429, 20);
            this.textBoxDescripcion.TabIndex = 2;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSize = true;
            this.Descripcion.Location = new System.Drawing.Point(25, 71);
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new System.Drawing.Size(66, 13);
            this.Descripcion.TabIndex = 3;
            this.Descripcion.Text = "Descripcion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha de publicacion:";
            // 
            // dateTimePickerFechaEspectaculo
            // 
            this.dateTimePickerFechaEspectaculo.Location = new System.Drawing.Point(147, 157);
            this.dateTimePickerFechaEspectaculo.Name = "dateTimePickerFechaEspectaculo";
            this.dateTimePickerFechaEspectaculo.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerFechaEspectaculo.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fecha de espectaculo:";
            // 
            // comboBoxRubro
            // 
            this.comboBoxRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRubro.FormattingEnabled = true;
            this.comboBoxRubro.Location = new System.Drawing.Point(143, 214);
            this.comboBoxRubro.Name = "comboBoxRubro";
            this.comboBoxRubro.Size = new System.Drawing.Size(142, 21);
            this.comboBoxRubro.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rubro:";
            // 
            // comboBoxGrado
            // 
            this.comboBoxGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrado.FormattingEnabled = true;
            this.comboBoxGrado.Location = new System.Drawing.Point(143, 259);
            this.comboBoxGrado.Name = "comboBoxGrado";
            this.comboBoxGrado.Size = new System.Drawing.Size(142, 21);
            this.comboBoxGrado.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Grado:";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(401, 23);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.ReadOnly = true;
            this.textBoxUsuario.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsuario.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Usuario responsable: ";
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "Borrador",
            "Activa",
            "Finalizada"});
            this.comboBoxEstado.Location = new System.Drawing.Point(143, 309);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(142, 21);
            this.comboBoxEstado.TabIndex = 14;
            this.comboBoxEstado.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstado_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Estado:";
            // 
            // dataGridViewUbicaciones
            // 
            this.dataGridViewUbicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUbicaciones.Location = new System.Drawing.Point(441, 121);
            this.dataGridViewUbicaciones.Name = "dataGridViewUbicaciones";
            this.dataGridViewUbicaciones.ReadOnly = true;
            this.dataGridViewUbicaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUbicaciones.Size = new System.Drawing.Size(504, 150);
            this.dataGridViewUbicaciones.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(457, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Seleccione ubicaciones disponibles:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 74);
            this.button1.TabIndex = 18;
            this.button1.Text = "Generar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonGeneracionMAsiva
            // 
            this.buttonGeneracionMAsiva.Location = new System.Drawing.Point(244, 386);
            this.buttonGeneracionMAsiva.Name = "buttonGeneracionMAsiva";
            this.buttonGeneracionMAsiva.Size = new System.Drawing.Size(174, 74);
            this.buttonGeneracionMAsiva.TabIndex = 19;
            this.buttonGeneracionMAsiva.Text = "Generacion Masiva";
            this.buttonGeneracionMAsiva.UseVisualStyleBackColor = true;
            this.buttonGeneracionMAsiva.Click += new System.EventHandler(this.buttonGeneracionMAsiva_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(441, 333);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(504, 150);
            this.dataGridView1.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(457, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Ubicaciones Seleccionadas:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(651, 286);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 37);
            this.button2.TabIndex = 22;
            this.button2.Text = "Confirmar asientos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePickerFechaPublicacion
            // 
            this.dateTimePickerFechaPublicacion.Enabled = false;
            this.dateTimePickerFechaPublicacion.Location = new System.Drawing.Point(147, 111);
            this.dateTimePickerFechaPublicacion.Name = "dateTimePickerFechaPublicacion";
            this.dateTimePickerFechaPublicacion.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerFechaPublicacion.TabIndex = 23;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 466);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 41);
            this.button3.TabIndex = 24;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AltaPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 519);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dateTimePickerFechaPublicacion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonGeneracionMAsiva);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridViewUbicaciones);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxEstado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxGrado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxRubro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerFechaEspectaculo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Descripcion);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCodigo);
            this.Name = "AltaPublicacion";
            this.Text = "Generar Publicacion";
            this.Load += new System.EventHandler(this.AltaPublicacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUbicaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Label Descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaEspectaculo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxRubro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxGrado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewUbicaciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonGeneracionMAsiva;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaPublicacion;
        private System.Windows.Forms.Button button3;
    }
}