namespace PalcoNet.Abm_Grado
{
    partial class GradoPublicacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelComisionAlta = new System.Windows.Forms.Label();
            this.labelComisionMedia = new System.Windows.Forms.Label();
            this.labelComisionBaja = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elija un grado de prioridad \r\npara tus publicaciones";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(16, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "Alta";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Yellow;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(16, 164);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 43);
            this.button3.TabIndex = 2;
            this.button3.Text = "Media";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lime;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(16, 227);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 43);
            this.button4.TabIndex = 3;
            this.button4.Text = "Baja";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(135, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Comisión en %";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelComisionAlta
            // 
            this.labelComisionAlta.AutoSize = true;
            this.labelComisionAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelComisionAlta.Location = new System.Drawing.Point(153, 119);
            this.labelComisionAlta.Name = "labelComisionAlta";
            this.labelComisionAlta.Size = new System.Drawing.Size(65, 17);
            this.labelComisionAlta.TabIndex = 5;
            this.labelComisionAlta.Text = "Comisión";
            // 
            // labelComisionMedia
            // 
            this.labelComisionMedia.AutoSize = true;
            this.labelComisionMedia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelComisionMedia.Location = new System.Drawing.Point(153, 178);
            this.labelComisionMedia.Name = "labelComisionMedia";
            this.labelComisionMedia.Size = new System.Drawing.Size(65, 17);
            this.labelComisionMedia.TabIndex = 6;
            this.labelComisionMedia.Text = "Comisión";
            // 
            // labelComisionBaja
            // 
            this.labelComisionBaja.AutoSize = true;
            this.labelComisionBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelComisionBaja.Location = new System.Drawing.Point(153, 241);
            this.labelComisionBaja.Name = "labelComisionBaja";
            this.labelComisionBaja.Size = new System.Drawing.Size(65, 17);
            this.labelComisionBaja.TabIndex = 7;
            this.labelComisionBaja.Text = "Comisión";
            // 
            // GradoPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 282);
            this.Controls.Add(this.labelComisionBaja);
            this.Controls.Add(this.labelComisionMedia);
            this.Controls.Add(this.labelComisionAlta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "GradoPublicacion";
            this.Text = "GradoPublicacion";
            this.Load += new System.EventHandler(this.GradoPublicacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelComisionAlta;
        private System.Windows.Forms.Label labelComisionMedia;
        private System.Windows.Forms.Label labelComisionBaja;
    }
}