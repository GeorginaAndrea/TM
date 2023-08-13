namespace LedPP2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtOFF_Click = new System.Windows.Forms.Button();
            this.BtON_Click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtOFF_Click
            // 
            this.BtOFF_Click.Location = new System.Drawing.Point(108, 69);
            this.BtOFF_Click.Name = "BtOFF_Click";
            this.BtOFF_Click.Size = new System.Drawing.Size(75, 23);
            this.BtOFF_Click.TabIndex = 0;
            this.BtOFF_Click.Text = "ON";
            this.BtOFF_Click.UseVisualStyleBackColor = true;
            this.BtOFF_Click.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtON_Click
            // 
            this.BtON_Click.Location = new System.Drawing.Point(108, 144);
            this.BtON_Click.Name = "BtON_Click";
            this.BtON_Click.Size = new System.Drawing.Size(75, 23);
            this.BtON_Click.TabIndex = 1;
            this.BtON_Click.Text = "OFF";
            this.BtON_Click.UseVisualStyleBackColor = true;
            this.BtON_Click.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtON_Click);
            this.Controls.Add(this.BtOFF_Click);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtOFF_Click;
        private System.Windows.Forms.Button BtON_Click;
    }
}

