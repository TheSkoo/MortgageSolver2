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
            this.lblPayoff = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPayoff = new System.Windows.Forms.TextBox();
            this.tbExpenses = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbIncome = new System.Windows.Forms.TextBox();
            this.tbSalePriceMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSalePriceMax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSalePriceInc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTaxesInc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTaxesMax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTaxesMin = new System.Windows.Forms.TextBox();
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
            this.tbExpenses.Text = "$5,000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sale Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Taxes";
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
            // tbSalePriceMin
            // 
            this.tbSalePriceMin.Location = new System.Drawing.Point(159, 99);
            this.tbSalePriceMin.Name = "tbSalePriceMin";
            this.tbSalePriceMin.Size = new System.Drawing.Size(73, 20);
            this.tbSalePriceMin.TabIndex = 8;
            this.tbSalePriceMin.Text = "$650,000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Min";
            // 
            // tbSalePriceMax
            // 
            this.tbSalePriceMax.Location = new System.Drawing.Point(278, 99);
            this.tbSalePriceMax.Name = "tbSalePriceMax";
            this.tbSalePriceMax.Size = new System.Drawing.Size(73, 20);
            this.tbSalePriceMax.TabIndex = 10;
            this.tbSalePriceMax.Text = "$725,000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(367, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Max";
            // 
            // tbSalePriceInc
            // 
            this.tbSalePriceInc.Location = new System.Drawing.Point(400, 99);
            this.tbSalePriceInc.Name = "tbSalePriceInc";
            this.tbSalePriceInc.Size = new System.Drawing.Size(73, 20);
            this.tbSalePriceInc.TabIndex = 12;
            this.tbSalePriceInc.Text = "$5,000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(489, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Inc";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(489, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Inc";
            // 
            // tbTaxesInc
            // 
            this.tbTaxesInc.Location = new System.Drawing.Point(400, 129);
            this.tbTaxesInc.Name = "tbTaxesInc";
            this.tbTaxesInc.Size = new System.Drawing.Size(73, 20);
            this.tbTaxesInc.TabIndex = 18;
            this.tbTaxesInc.Text = "$500";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(367, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Max";
            // 
            // tbTaxesMax
            // 
            this.tbTaxesMax.Location = new System.Drawing.Point(278, 129);
            this.tbTaxesMax.Name = "tbTaxesMax";
            this.tbTaxesMax.Size = new System.Drawing.Size(73, 20);
            this.tbTaxesMax.TabIndex = 16;
            this.tbTaxesMax.Text = "$12,000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(248, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Min";
            // 
            // tbTaxesMin
            // 
            this.tbTaxesMin.Location = new System.Drawing.Point(159, 129);
            this.tbTaxesMin.Name = "tbTaxesMin";
            this.tbTaxesMin.Size = new System.Drawing.Size(73, 20);
            this.tbTaxesMin.TabIndex = 14;
            this.tbTaxesMin.Text = "$3,500";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbTaxesInc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbTaxesMax);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbTaxesMin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbSalePriceInc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSalePriceMax);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSalePriceMin);
            this.Controls.Add(this.tbIncome);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbExpenses);
            this.Controls.Add(this.tbPayoff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPayoff);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPayoff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPayoff;
        private System.Windows.Forms.TextBox tbExpenses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIncome;
        private System.Windows.Forms.TextBox tbSalePriceMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSalePriceMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSalePriceInc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTaxesInc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbTaxesMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbTaxesMin;
    }
}

