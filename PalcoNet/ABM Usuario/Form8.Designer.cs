namespace PalcoNet.ABM_Usuario
{
    partial class Form8
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
            this.buttonCliente = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonEmpresa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCliente
            // 
            this.buttonCliente.BackColor = System.Drawing.Color.MintCream;
            this.buttonCliente.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCliente.Location = new System.Drawing.Point(97, 71);
            this.buttonCliente.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCliente.Name = "buttonCliente";
            this.buttonCliente.Size = new System.Drawing.Size(111, 32);
            this.buttonCliente.TabIndex = 56;
            this.buttonCliente.Text = "CLIENTE";
            this.buttonCliente.UseVisualStyleBackColor = false;
            this.buttonCliente.Click += new System.EventHandler(this.buttonCliente_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(118, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 33);
            this.label9.TabIndex = 43;
            this.label9.Text = "Eliminar Usuario";
            // 
            // buttonEmpresa
            // 
            this.buttonEmpresa.BackColor = System.Drawing.Color.MintCream;
            this.buttonEmpresa.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEmpresa.Location = new System.Drawing.Point(245, 71);
            this.buttonEmpresa.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEmpresa.Name = "buttonEmpresa";
            this.buttonEmpresa.Size = new System.Drawing.Size(111, 32);
            this.buttonEmpresa.TabIndex = 57;
            this.buttonEmpresa.Text = "EMPRESA";
            this.buttonEmpresa.UseVisualStyleBackColor = false;
            this.buttonEmpresa.Click += new System.EventHandler(this.buttonEmpresa_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(454, 125);
            this.Controls.Add(this.buttonEmpresa);
            this.Controls.Add(this.buttonCliente);
            this.Controls.Add(this.label9);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonEmpresa;
    }
}