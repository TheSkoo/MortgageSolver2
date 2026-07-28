using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MortgageSolver2
{
    public partial class Form1 : Form
    {
        private decimal payoff;
        private decimal expenses;
        private decimal income;
        private decimal salePriceMin;
        private decimal salePriceMax;
        private decimal salePriceInc;
        private decimal taxesMin;
        private decimal taxesMax;
        private decimal taxesInc;

        private Dictionary<int, decimal> termRates;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            termRates = new Dictionary<int, decimal>
            {
                { 15, decimal.Parse(ConfigurationManager.AppSettings["15"]) },
                { 20, decimal.Parse(ConfigurationManager.AppSettings["20"]) },
                { 30, decimal.Parse(ConfigurationManager.AppSettings["30"]) }
            };
            RefreshFromForm();
        }

        private void RefreshFromForm()
        {
            payoff = decimal.Parse(tbPayoff.Text);
            expenses = decimal.Parse(tbExpenses.Text);
            income = decimal.Parse(tbIncome.Text);
            salePriceMin = decimal.Parse(tbSalePriceMin.Text);
            salePriceMax = decimal.Parse(tbSalePriceMax.Text);
            salePriceInc = decimal.Parse(tbSalePriceInc.Text);
            taxesMin = decimal.Parse(tbTaxesMin.Text);
            taxesMax = decimal.Parse(tbTaxesMax.Text);
            taxesInc = decimal.Parse(tbTaxesInc.Text);
        }
    }
}
