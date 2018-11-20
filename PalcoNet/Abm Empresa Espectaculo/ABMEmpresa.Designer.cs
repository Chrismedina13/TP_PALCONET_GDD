namespace PalcoNet.Abm_Empresa_Espectaculo
{
    partial class ABMEmpresa
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
            this.buttonALTA = new System.Windows.Forms.Button();
            this.buttonMODIFICAR = new System.Windows.Forms.Button();
            this.buttonBAJA = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonALTA
            // 
            this.buttonALTA.Location = new System.Drawing.Point(89, 36);
            this.buttonALTA.Name = "buttonALTA";
            this.buttonALTA.Size = new System.Drawing.Size(131, 45);
            this.buttonALTA.TabIndex = 0;
            this.buttonALTA.Text = "ALTA EMPRESA";
            this.buttonALTA.UseVisualStyleBackColor = true;
            this.buttonALTA.Click += new System.EventHandler(this.buttonALTA_Click);
            // 
            // buttonMODIFICAR
            // 
            this.buttonMODIFICAR.Location = new System.Drawing.Point(89, 122);
            this.buttonMODIFICAR.Name = "buttonMODIFICAR";
            this.buttonMODIFICAR.Size = new System.Drawing.Size(131, 45);
            this.buttonMODIFICAR.TabIndex = 1;
            this.buttonMODIFICAR.Text = "MODIFICAR EMPRESA";
            this.buttonMODIFICAR.UseVisualStyleBackColor = true;
            this.buttonMODIFICAR.Click += new System.EventHandler(this.buttonMODIFICAR_Click);
            // 
            // buttonBAJA
            // 
            this.buttonBAJA.Location = new System.Drawing.Point(89, 206);
            this.buttonBAJA.Name = "buttonBAJA";
            this.buttonBAJA.Size = new System.Drawing.Size(131, 45);
            this.buttonBAJA.TabIndex = 2;
            this.buttonBAJA.Text = "BAJA EMPRESA";
            this.buttonBAJA.UseVisualStyleBackColor = true;
            this.buttonBAJA.Click += new System.EventHandler(this.buttonBAJA_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(120, 291);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(75, 23);
            this.buttonVolver.TabIndex = 3;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // ABMEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 338);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonBAJA);
            this.Controls.Add(this.buttonMODIFICAR);
            this.Controls.Add(this.buttonALTA);
            this.Name = "ABMEmpresa";
            this.Text = "ABMEmpresa";
            this.Load += new System.EventHandler(this.ABMEmpresa_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonALTA;
        private System.Windows.Forms.Button buttonMODIFICAR;
        private System.Windows.Forms.Button buttonBAJA;
        private System.Windows.Forms.Button buttonVolver;
    }
}