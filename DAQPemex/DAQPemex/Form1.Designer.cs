using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

using MccDaq;

namespace DAQPemex
{
    partial class DAQPemex
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
       /// private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cmbPlanta = new System.Windows.Forms.ComboBox();
            this.tmrConvert = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbValvula = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnWebCamStart = new System.Windows.Forms.Button();
            this.btnWebCamStop = new System.Windows.Forms.Button();
            this.graficaPresion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmdStartConvert = new System.Windows.Forms.Button();
            this.cmdStopConvert = new System.Windows.Forms.Button();
            this.lblShowData = new System.Windows.Forms.Label();
            this.lblMaximo = new System.Windows.Forms.Label();
            this.rdBtn5000Psi = new System.Windows.Forms.RadioButton();
            this.rdBtn300Psi = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTransductor = new System.Windows.Forms.Label();
            this.btnWebCamCnfig = new System.Windows.Forms.Button();
            this.lblStable = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStpWatch = new System.Windows.Forms.Label();
            this.lblPntCount = new System.Windows.Forms.Label();
            this.Serie_Actual = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graficaPresion)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPlanta
            // 
            this.cmbPlanta.FormattingEnabled = true;
            this.cmbPlanta.Location = new System.Drawing.Point(12, 375);
            this.cmbPlanta.Name = "cmbPlanta";
            this.cmbPlanta.Size = new System.Drawing.Size(121, 21);
            this.cmbPlanta.TabIndex = 0;
            this.cmbPlanta.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tmrConvert
            // 
            this.tmrConvert.Tick += new System.EventHandler(this.tmrConvert_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Planta";
            // 
            // cmbValvula
            // 
            this.cmbValvula.FormattingEnabled = true;
            this.cmbValvula.Location = new System.Drawing.Point(12, 415);
            this.cmbValvula.Name = "cmbValvula";
            this.cmbValvula.Size = new System.Drawing.Size(121, 21);
            this.cmbValvula.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valvula";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(18, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 266);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnWebCamStart
            // 
            this.btnWebCamStart.Location = new System.Drawing.Point(317, 13);
            this.btnWebCamStart.Name = "btnWebCamStart";
            this.btnWebCamStart.Size = new System.Drawing.Size(75, 23);
            this.btnWebCamStart.TabIndex = 5;
            this.btnWebCamStart.Text = "Iniciar";
            this.btnWebCamStart.UseVisualStyleBackColor = true;
            this.btnWebCamStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnWebCamStop
            // 
            this.btnWebCamStop.Location = new System.Drawing.Point(317, 43);
            this.btnWebCamStop.Name = "btnWebCamStop";
            this.btnWebCamStop.Size = new System.Drawing.Size(75, 23);
            this.btnWebCamStop.TabIndex = 6;
            this.btnWebCamStop.Text = "Detener";
            this.btnWebCamStop.UseVisualStyleBackColor = true;
            this.btnWebCamStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // graficaPresion
            // 
            chartArea1.Name = "ChartArea1";
            this.graficaPresion.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Title = "Presion";
            this.graficaPresion.Legends.Add(legend1);
            this.graficaPresion.Location = new System.Drawing.Point(317, 279);
            this.graficaPresion.Name = "graficaPresion";
            this.graficaPresion.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BackImageTransparentColor = System.Drawing.Color.White;
            series1.BackSecondaryColor = System.Drawing.Color.Red;
            series1.BorderColor = System.Drawing.Color.Red;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.LegendText = "Presion";
            series1.Name = "Presion_Inicio";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Presion_Abierto";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Presion_Cerrado";
            series4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Blue;
            series4.Legend = "Legend1";
            series4.LegendText = "Regresion Lineal";
            series4.Name = "RL_Inicial";
            series5.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Blue;
            series5.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.Name = "RL_Abierto";
            series6.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Blue;
            series6.IsVisibleInLegend = false;
            series6.Legend = "Legend1";
            series6.Name = "RL_Cerrado";
            this.graficaPresion.Series.Add(series1);
            this.graficaPresion.Series.Add(series2);
            this.graficaPresion.Series.Add(series3);
            this.graficaPresion.Series.Add(series4);
            this.graficaPresion.Series.Add(series5);
            this.graficaPresion.Series.Add(series6);
            this.graficaPresion.Size = new System.Drawing.Size(362, 300);
            this.graficaPresion.TabIndex = 7;
            this.graficaPresion.Text = "chart1";
            // 
            // cmdStartConvert
            // 
            this.cmdStartConvert.Location = new System.Drawing.Point(287, 3);
            this.cmdStartConvert.Name = "cmdStartConvert";
            this.cmdStartConvert.Size = new System.Drawing.Size(75, 23);
            this.cmdStartConvert.TabIndex = 8;
            this.cmdStartConvert.Text = "Iniciar";
            this.cmdStartConvert.UseVisualStyleBackColor = true;
            this.cmdStartConvert.Click += new System.EventHandler(this.cmdStartConvert_Click);
            // 
            // cmdStopConvert
            // 
            this.cmdStopConvert.Location = new System.Drawing.Point(287, 32);
            this.cmdStopConvert.Name = "cmdStopConvert";
            this.cmdStopConvert.Size = new System.Drawing.Size(75, 23);
            this.cmdStopConvert.TabIndex = 9;
            this.cmdStopConvert.Text = "Detener";
            this.cmdStopConvert.UseVisualStyleBackColor = true;
            this.cmdStopConvert.Visible = false;
            this.cmdStopConvert.Click += new System.EventHandler(this.cmdStopConvert_Click);
            // 
            // lblShowData
            // 
            this.lblShowData.AutoSize = true;
            this.lblShowData.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowData.Location = new System.Drawing.Point(408, 27);
            this.lblShowData.Name = "lblShowData";
            this.lblShowData.Size = new System.Drawing.Size(103, 39);
            this.lblShowData.TabIndex = 10;
            this.lblShowData.Text = "0.000";
            // 
            // lblMaximo
            // 
            this.lblMaximo.AutoSize = true;
            this.lblMaximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.lblMaximo.Location = new System.Drawing.Point(528, 27);
            this.lblMaximo.Name = "lblMaximo";
            this.lblMaximo.Size = new System.Drawing.Size(51, 39);
            this.lblMaximo.TabIndex = 11;
            this.lblMaximo.Text = "-.-";
            // 
            // rdBtn5000Psi
            // 
            this.rdBtn5000Psi.AutoSize = true;
            this.rdBtn5000Psi.Location = new System.Drawing.Point(7, 70);
            this.rdBtn5000Psi.Name = "rdBtn5000Psi";
            this.rdBtn5000Psi.Size = new System.Drawing.Size(69, 17);
            this.rdBtn5000Psi.TabIndex = 12;
            this.rdBtn5000Psi.TabStop = true;
            this.rdBtn5000Psi.Text = "5000 PSI";
            this.rdBtn5000Psi.UseVisualStyleBackColor = true;
            this.rdBtn5000Psi.CheckedChanged += new System.EventHandler(this.rdBtn5000Psi_CheckedChanged);
            // 
            // rdBtn300Psi
            // 
            this.rdBtn300Psi.AutoSize = true;
            this.rdBtn300Psi.Location = new System.Drawing.Point(7, 93);
            this.rdBtn300Psi.Name = "rdBtn300Psi";
            this.rdBtn300Psi.Size = new System.Drawing.Size(63, 17);
            this.rdBtn300Psi.TabIndex = 13;
            this.rdBtn300Psi.TabStop = true;
            this.rdBtn300Psi.Text = "300 PSI";
            this.rdBtn300Psi.UseVisualStyleBackColor = true;
            this.rdBtn300Psi.CheckedChanged += new System.EventHandler(this.rdBtn300Psi_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTransductor);
            this.panel1.Controls.Add(this.rdBtn300Psi);
            this.panel1.Controls.Add(this.rdBtn5000Psi);
            this.panel1.Controls.Add(this.cmdStopConvert);
            this.panel1.Controls.Add(this.cmdStartConvert);
            this.panel1.Location = new System.Drawing.Point(317, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 123);
            this.panel1.TabIndex = 14;
            // 
            // lblTransductor
            // 
            this.lblTransductor.AutoSize = true;
            this.lblTransductor.Location = new System.Drawing.Point(4, 41);
            this.lblTransductor.Name = "lblTransductor";
            this.lblTransductor.Size = new System.Drawing.Size(64, 13);
            this.lblTransductor.TabIndex = 14;
            this.lblTransductor.Text = "Transductor";
            // 
            // btnWebCamCnfig
            // 
            this.btnWebCamCnfig.Location = new System.Drawing.Point(316, 72);
            this.btnWebCamCnfig.Name = "btnWebCamCnfig";
            this.btnWebCamCnfig.Size = new System.Drawing.Size(75, 23);
            this.btnWebCamCnfig.TabIndex = 15;
            this.btnWebCamCnfig.Text = "Configurar";
            this.btnWebCamCnfig.UseVisualStyleBackColor = true;
            this.btnWebCamCnfig.Click += new System.EventHandler(this.btnWebCamCnfig_Click);
            // 
            // lblStable
            // 
            this.lblStable.AutoSize = true;
            this.lblStable.Location = new System.Drawing.Point(409, 115);
            this.lblStable.Name = "lblStable";
            this.lblStable.Size = new System.Drawing.Size(47, 13);
            this.lblStable.TabIndex = 16;
            this.lblStable.Text = "Ninguno";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(412, 140);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(29, 13);
            this.lblData.TabIndex = 17;
            this.lblData.Text = "Multi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(412, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Presion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(522, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Maximo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(532, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Tiempo por ciclo";
            this.label5.Visible = false;
            // 
            // lblStpWatch
            // 
            this.lblStpWatch.AutoSize = true;
            this.lblStpWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStpWatch.Location = new System.Drawing.Point(531, 127);
            this.lblStpWatch.Name = "lblStpWatch";
            this.lblStpWatch.Size = new System.Drawing.Size(38, 24);
            this.lblStpWatch.TabIndex = 21;
            this.lblStpWatch.Text = "0.0";
            this.lblStpWatch.Visible = false;
            // 
            // lblPntCount
            // 
            this.lblPntCount.AutoSize = true;
            this.lblPntCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPntCount.Location = new System.Drawing.Point(600, 127);
            this.lblPntCount.Name = "lblPntCount";
            this.lblPntCount.Size = new System.Drawing.Size(90, 24);
            this.lblPntCount.TabIndex = 22;
            this.lblPntCount.Text = "Ninguno";
            this.lblPntCount.Visible = false;
            // 
            // Serie_Actual
            // 
            this.Serie_Actual.AutoSize = true;
            this.Serie_Actual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.Serie_Actual.Location = new System.Drawing.Point(734, 22);
            this.Serie_Actual.Name = "Serie_Actual";
            this.Serie_Actual.Size = new System.Drawing.Size(66, 24);
            this.Serie_Actual.TabIndex = 23;
            this.Serie_Actual.Text = "label6";
            // 
            // DAQPemex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 862);
            this.Controls.Add(this.Serie_Actual);
            this.Controls.Add(this.lblPntCount);
            this.Controls.Add(this.lblStpWatch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblStable);
            this.Controls.Add(this.btnWebCamCnfig);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMaximo);
            this.Controls.Add(this.lblShowData);
            this.Controls.Add(this.graficaPresion);
            this.Controls.Add(this.btnWebCamStop);
            this.Controls.Add(this.btnWebCamStart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbValvula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPlanta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DAQPemex";
            this.Text = "Probador de Valvulas";
            this.Load += new System.EventHandler(this.frmDataDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graficaPresion)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ComboBox cmbPlanta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbValvula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnWebCamStart;
        private System.Windows.Forms.Button btnWebCamStop;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficaPresion;

        private Timer tmrConvert;
        private RadioButton rdBtn5000Psi;
        private RadioButton rdBtn300Psi;
        private Panel panel1;
        private Label lblTransductor;
        private Button btnWebCamCnfig;
        private Label lblStable;
        private Label lblData;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblStpWatch;
        private Label lblPntCount;
        private Label Serie_Actual; 

        
    }
}

