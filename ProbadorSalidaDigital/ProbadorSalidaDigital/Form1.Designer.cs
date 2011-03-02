namespace ProbadorSalidaDigital
{
    partial class Probador
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
            this.components = new System.ComponentModel.Container();
            this.btnEscribir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDato = new System.Windows.Forms.TextBox();
            this.chkRep = new System.Windows.Forms.CheckBox();
            this.txtInterfaz = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInterfaz = new System.Windows.Forms.Button();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.lblRespuestaDato = new System.Windows.Forms.Label();
            this.txtRepTiempo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Reloj = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnEscribir
            // 
            this.btnEscribir.Location = new System.Drawing.Point(90, 197);
            this.btnEscribir.Name = "btnEscribir";
            this.btnEscribir.Size = new System.Drawing.Size(75, 23);
            this.btnEscribir.TabIndex = 0;
            this.btnEscribir.Text = "Escribir";
            this.btnEscribir.UseVisualStyleBackColor = true;
            this.btnEscribir.Click += new System.EventHandler(this.btnEscribir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dato";
            // 
            // txtDato
            // 
            this.txtDato.Location = new System.Drawing.Point(90, 171);
            this.txtDato.Name = "txtDato";
            this.txtDato.Size = new System.Drawing.Size(100, 20);
            this.txtDato.TabIndex = 2;
            // 
            // chkRep
            // 
            this.chkRep.AutoSize = true;
            this.chkRep.Location = new System.Drawing.Point(306, 174);
            this.chkRep.Name = "chkRep";
            this.chkRep.Size = new System.Drawing.Size(60, 17);
            this.chkRep.TabIndex = 3;
            this.chkRep.Text = "Repetir";
            this.chkRep.UseVisualStyleBackColor = true;
            // 
            // txtInterfaz
            // 
            this.txtInterfaz.Location = new System.Drawing.Point(106, 31);
            this.txtInterfaz.Name = "txtInterfaz";
            this.txtInterfaz.Size = new System.Drawing.Size(34, 20);
            this.txtInterfaz.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Interfaz";
            // 
            // btnInterfaz
            // 
            this.btnInterfaz.Location = new System.Drawing.Point(146, 31);
            this.btnInterfaz.Name = "btnInterfaz";
            this.btnInterfaz.Size = new System.Drawing.Size(75, 23);
            this.btnInterfaz.TabIndex = 0;
            this.btnInterfaz.Text = "Cambiar Interfaz";
            this.btnInterfaz.UseVisualStyleBackColor = true;
            this.btnInterfaz.Click += new System.EventHandler(this.btnInterfaz_Click);
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Location = new System.Drawing.Point(49, 284);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(45, 13);
            this.lblRespuesta.TabIndex = 1;
            this.lblRespuesta.Text = "Escrito?";
            // 
            // lblRespuestaDato
            // 
            this.lblRespuestaDato.AutoSize = true;
            this.lblRespuestaDato.Location = new System.Drawing.Point(66, 314);
            this.lblRespuestaDato.Name = "lblRespuestaDato";
            this.lblRespuestaDato.Size = new System.Drawing.Size(13, 13);
            this.lblRespuestaDato.TabIndex = 1;
            this.lblRespuestaDato.Text = "--";
            // 
            // txtRepTiempo
            // 
            this.txtRepTiempo.Location = new System.Drawing.Point(306, 148);
            this.txtRepTiempo.Name = "txtRepTiempo";
            this.txtRepTiempo.Size = new System.Drawing.Size(100, 20);
            this.txtRepTiempo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Velocidad Repeticion";
            // 
            // Reloj
            // 
            this.Reloj.Tick += new System.EventHandler(this.Reloj_Tick);
            // 
            // Probador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 548);
            this.Controls.Add(this.chkRep);
            this.Controls.Add(this.txtInterfaz);
            this.Controls.Add(this.txtRepTiempo);
            this.Controls.Add(this.txtDato);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRespuestaDato);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInterfaz);
            this.Controls.Add(this.btnEscribir);
            this.Name = "Probador";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEscribir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDato;
        private System.Windows.Forms.CheckBox chkRep;
        private System.Windows.Forms.TextBox txtInterfaz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInterfaz;
        private System.Windows.Forms.Label lblRespuesta;
        private System.Windows.Forms.Label lblRespuestaDato;
        private System.Windows.Forms.TextBox txtRepTiempo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer Reloj;
    }
}

