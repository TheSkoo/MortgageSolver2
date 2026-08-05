namespace MortgageSolver2
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblPayoff = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPayoff = new System.Windows.Forms.TextBox();
            this.tbExpenses = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbIncome = new System.Windows.Forms.TextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboIV = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDV2 = new System.Windows.Forms.Label();
            this.lblDV1 = new System.Windows.Forms.Label();
            this.cboDV2 = new System.Windows.Forms.ComboBox();
            this.cboDV1 = new System.Windows.Forms.ComboBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rbAmountFinanced = new System.Windows.Forms.RadioButton();
            this.rbPITI = new System.Windows.Forms.RadioButton();
            this.tbProfitsWithheld = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPayoff
            // 
            this.lblPayoff.AutoSize = true;
            this.lblPayoff.Location = new System.Drawing.Point(102, 13);
            this.lblPayoff.Name = "lblPayoff";
            this.lblPayoff.Size = new System.Drawing.Size(37, 13);
            this.lblPayoff.TabIndex = 0;
            this.lblPayoff.Text = "Payoff";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Expenses sans Mortgage";
            // 
            // tbPayoff
            // 
            this.tbPayoff.Location = new System.Drawing.Point(159, 9);
            this.tbPayoff.Name = "tbPayoff";
            this.tbPayoff.Size = new System.Drawing.Size(73, 20);
            this.tbPayoff.TabIndex = 2;
            this.tbPayoff.Text = "$370,000";
            // 
            // tbExpenses
            // 
            this.tbExpenses.Location = new System.Drawing.Point(159, 39);
            this.tbExpenses.Name = "tbExpenses";
            this.tbExpenses.Size = new System.Drawing.Size(73, 20);
            this.tbExpenses.TabIndex = 3;
            this.tbExpenses.Text = "$4,500";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Income";
            // 
            // tbIncome
            // 
            this.tbIncome.Location = new System.Drawing.Point(159, 69);
            this.tbIncome.Name = "tbIncome";
            this.tbIncome.Size = new System.Drawing.Size(73, 20);
            this.tbIncome.TabIndex = 7;
            this.tbIncome.Text = "$7,070";
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(12, 132);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(1057, 378);
            this.chart.TabIndex = 20;
            this.chart.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboIV);
            this.groupBox1.Location = new System.Drawing.Point(290, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 77);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Independent Variable";
            // 
            // cboIV
            // 
            this.cboIV.FormattingEnabled = true;
            this.cboIV.Location = new System.Drawing.Point(17, 25);
            this.cboIV.Name = "cboIV";
            this.cboIV.Size = new System.Drawing.Size(121, 21);
            this.cboIV.TabIndex = 0;
            this.cboIV.SelectedIndexChanged += new System.EventHandler(this.cboIV_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDV2);
            this.groupBox2.Controls.Add(this.lblDV1);
            this.groupBox2.Controls.Add(this.cboDV2);
            this.groupBox2.Controls.Add(this.cboDV1);
            this.groupBox2.Location = new System.Drawing.Point(450, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 100);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dependent Variables";
            // 
            // lblDV2
            // 
            this.lblDV2.AutoSize = true;
            this.lblDV2.Location = new System.Drawing.Point(172, 29);
            this.lblDV2.Name = "lblDV2";
            this.lblDV2.Size = new System.Drawing.Size(0, 13);
            this.lblDV2.TabIndex = 3;
            // 
            // lblDV1
            // 
            this.lblDV1.AutoSize = true;
            this.lblDV1.Location = new System.Drawing.Point(18, 29);
            this.lblDV1.Name = "lblDV1";
            this.lblDV1.Size = new System.Drawing.Size(0, 13);
            this.lblDV1.TabIndex = 2;
            // 
            // cboDV2
            // 
            this.cboDV2.FormattingEnabled = true;
            this.cboDV2.Location = new System.Drawing.Point(165, 52);
            this.cboDV2.Name = "cboDV2";
            this.cboDV2.Size = new System.Drawing.Size(121, 21);
            this.cboDV2.TabIndex = 1;
            // 
            // cboDV1
            // 
            this.cboDV1.FormattingEnabled = true;
            this.cboDV1.Location = new System.Drawing.Point(18, 52);
            this.cboDV1.Name = "cboDV1";
            this.cboDV1.Size = new System.Drawing.Size(121, 21);
            this.cboDV1.TabIndex = 0;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(857, 43);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(106, 23);
            this.btnCalculate.TabIndex = 27;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Profits withheld from next purchase";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(3, 539);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1057, 165);
            this.chart1.TabIndex = 30;
            this.chart1.Text = "chart1";
            // 
            // rbAmountFinanced
            // 
            this.rbAmountFinanced.AutoSize = true;
            this.rbAmountFinanced.Checked = true;
            this.rbAmountFinanced.Location = new System.Drawing.Point(3, 516);
            this.rbAmountFinanced.Name = "rbAmountFinanced";
            this.rbAmountFinanced.Size = new System.Drawing.Size(108, 17);
            this.rbAmountFinanced.TabIndex = 31;
            this.rbAmountFinanced.TabStop = true;
            this.rbAmountFinanced.Text = "Amount Financed";
            this.rbAmountFinanced.UseVisualStyleBackColor = true;
            this.rbAmountFinanced.CheckedChanged += new System.EventHandler(this.LowerChart_CheckedChanged);
            // 
            // rbPITI
            // 
            this.rbPITI.AutoSize = true;
            this.rbPITI.Location = new System.Drawing.Point(126, 516);
            this.rbPITI.Name = "rbPITI";
            this.rbPITI.Size = new System.Drawing.Size(106, 17);
            this.rbPITI.TabIndex = 32;
            this.rbPITI.Text = "Monthly Payment";
            this.rbPITI.UseVisualStyleBackColor = true;
            this.rbPITI.CheckedChanged += new System.EventHandler(this.LowerChart_CheckedChanged);
            // 
            // tbProfitsWithheld
            // 
            this.tbProfitsWithheld.Location = new System.Drawing.Point(189, 102);
            this.tbProfitsWithheld.Name = "tbProfitsWithheld";
            this.tbProfitsWithheld.Size = new System.Drawing.Size(73, 20);
            this.tbProfitsWithheld.TabIndex = 29;
            this.tbProfitsWithheld.Text = "$0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 714);
            this.Controls.Add(this.rbPITI);
            this.Controls.Add(this.rbAmountFinanced);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.tbProfitsWithheld);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.tbIncome);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbExpenses);
            this.Controls.Add(this.tbPayoff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPayoff);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPayoff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPayoff;
        private System.Windows.Forms.TextBox tbExpenses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIncome;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboIV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboDV2;
        private System.Windows.Forms.ComboBox cboDV1;
        private System.Windows.Forms.Label lblDV2;
        private System.Windows.Forms.Label lblDV1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.RadioButton rbAmountFinanced;
        private System.Windows.Forms.RadioButton rbPITI;
        private System.Windows.Forms.TextBox tbProfitsWithheld;
    }
}

