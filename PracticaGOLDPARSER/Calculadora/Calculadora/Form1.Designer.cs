namespace Calculadora
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(168, 153);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(122, 81);
            this.txtEntrada.Multiline = true;
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(261, 51);
            this.txtEntrada.TabIndex = 1;
            this.txtEntrada.TextChanged += new System.EventHandler(this.txtEntrada_TextChanged);
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(122, 225);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(261, 51);
            this.txtResultado.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.txtEntrada);
            this.Controls.Add(this.btnCalcular);
            this.Name = "Form1";
            this.Text = "Calculadora Suma Resta Multiplicacion y Division";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCalcular;
        private TextBox txtEntrada;
        private TextBox txtResultado;
    }
}