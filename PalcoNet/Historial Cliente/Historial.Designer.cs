namespace PalcoNet.Historial_Cliente
{
    partial class Historial
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
            this.SuspendLayout();
            // 
            // labelPaginas
            // 
            this.labelPaginas.Location = new System.Drawing.Point(509, 394);
            this.labelPaginas.MinimumSize = new System.Drawing.Size(84, 0);
            this.labelPaginas.Size = new System.Drawing.Size(84, 22);
            this.labelPaginas.Text = "1 de 1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 371);
            // 
            // botonsiguiente
            // 
            this.botonsiguiente.Click += new System.EventHandler(this.botonsiguiente_Click);
            // 
            // botonAnterior
            // 
            this.botonAnterior.Click += new System.EventHandler(this.botonAnterior_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(193, 9);
            this.label2.Size = new System.Drawing.Size(481, 55);
            this.label2.Text = "Historial de compras";
            // 
            // buttonPrimeraHoja
            // 
            this.buttonPrimeraHoja.Click += new System.EventHandler(this.buttonPrimeraHoja_Click);
            // 
            // buttonUltimaHoja
            // 
            this.buttonUltimaHoja.Click += new System.EventHandler(this.buttonUltimaHoja_Click);
            // 
            // Historial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 433);
            this.Name = "Historial";
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.Historial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}