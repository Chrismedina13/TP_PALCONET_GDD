namespace PalcoNet.Abm_Cliente
{
    partial class ABMCliente
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
            this.buttonVolver = new System.Windows.Forms.Button();
            this.buttonBAJACLIENTE = new System.Windows.Forms.Button();
            this.buttonMODIFICARCLIENTE = new System.Windows.Forms.Button();
            this.buttonALTACLIENTE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(112, 267);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(75, 23);
            this.buttonVolver.TabIndex = 7;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // buttonBAJACLIENTE
            // 
            this.buttonBAJACLIENTE.Location = new System.Drawing.Point(81, 182);
            this.buttonBAJACLIENTE.Name = "buttonBAJACLIENTE";
            this.buttonBAJACLIENTE.Size = new System.Drawing.Size(131, 45);
            this.buttonBAJACLIENTE.TabIndex = 6;
            this.buttonBAJACLIENTE.Text = "BAJA CLIENTE";
            this.buttonBAJACLIENTE.UseVisualStyleBackColor = true;
            this.buttonBAJACLIENTE.Click += new System.EventHandler(this.buttonBAJA_Click);
            // 
            // buttonMODIFICARCLIENTE
            // 
            this.buttonMODIFICARCLIENTE.Location = new System.Drawing.Point(81, 98);
            this.buttonMODIFICARCLIENTE.Name = "buttonMODIFICARCLIENTE";
            this.buttonMODIFICARCLIENTE.Size = new System.Drawing.Size(131, 45);
            this.buttonMODIFICARCLIENTE.TabIndex = 5;
            this.buttonMODIFICARCLIENTE.Text = "MODIFICAR CLIENTE";
            this.buttonMODIFICARCLIENTE.UseVisualStyleBackColor = true;
            this.buttonMODIFICARCLIENTE.Click += new System.EventHandler(this.buttonMODIFICAR_Click);
            // 
            // buttonALTACLIENTE
            // 
            this.buttonALTACLIENTE.Location = new System.Drawing.Point(81, 12);
            this.buttonALTACLIENTE.Name = "buttonALTACLIENTE";
            this.buttonALTACLIENTE.Size = new System.Drawing.Size(131, 45);
            this.buttonALTACLIENTE.TabIndex = 4;
            this.buttonALTACLIENTE.Text = "ALTA CLIENTE";
            this.buttonALTACLIENTE.UseVisualStyleBackColor = true;
            this.buttonALTACLIENTE.Click += new System.EventHandler(this.buttonALTA_Click);
            // 
            // ABMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 318);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonBAJACLIENTE);
            this.Controls.Add(this.buttonMODIFICARCLIENTE);
            this.Controls.Add(this.buttonALTACLIENTE);
            this.Name = "ABMCliente";
            this.Text = "ABMCliente";
            this.Load += new System.EventHandler(this.ABMCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Button buttonBAJACLIENTE;
        private System.Windows.Forms.Button buttonMODIFICARCLIENTE;
        private System.Windows.Forms.Button buttonALTACLIENTE;
    }
}