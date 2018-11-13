namespace PalcoNet.Support
{
    partial class volver
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
            this.volver_boton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // volver_boton
            // 
            this.volver_boton.Location = new System.Drawing.Point(95, 201);
            this.volver_boton.Name = "volver_boton";
            this.volver_boton.Size = new System.Drawing.Size(75, 23);
            this.volver_boton.TabIndex = 0;
            this.volver_boton.Text = "Volver";
            this.volver_boton.UseVisualStyleBackColor = true;
            this.volver_boton.Click += new System.EventHandler(this.volver_boton_Click);
            // 
            // volver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.volver_boton);
            this.Name = "volver";
            this.Text = "Volver";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button volver_boton;
    }
}