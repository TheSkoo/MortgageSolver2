using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; // Required namespace
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MortgageSolver2
{
    public partial class Form1 : Form
    {
        private decimal payoff;
        private decimal expenses;
        private decimal income;

        private Dictionary<int, decimal> termRates;

        private IndependentVariables independentVariable;

        private bool initialized = false;

        private List<IndependentPricePoint> pricePoints = new List<IndependentPricePoint>();

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

            cboIV.DataSource = Variables.ComboBoxItems;
            cboIV.DisplayMember = "DisplayText";
            cboIV.ValueMember = "ItemCode";
            cboIV.SelectedIndex = -1;

            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "X Axis";
            chartArea.AxisY.Title = "Y Axis";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas.Add(chartArea);

            initialized = true;
        }

        private void RefreshFromForm()
        {
            payoff = decimal.Parse(tbPayoff.Text, System.Globalization.NumberStyles.Currency);
            expenses = decimal.Parse(tbExpenses.Text, System.Globalization.NumberStyles.Currency);
            income = decimal.Parse(tbIncome.Text, System.Globalization.NumberStyles.Currency);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CreateSalesPriceChart();
            int[] xValues = { 1, 2, 3, 4, 5 };
            double[] yValues = { 15.5, 23.0, 18.2, 31.4, 25.0 };

            // Ensure the chart series is set to Line
            chart.Series["Series1"].ChartType = SeriesChartType.Line;

            // Bind both arrays simultaneously
            chart.Series["Series1"].Points
                .DataBindXY(
                    pricePoints
                        .Select(p => (double)p.IndependentPrice).ToArray(),
                    pricePoints
                        .Select(p => (double)p.Net[0]).ToArray());

        }

        private void CreateSalesPriceChart()
        {
            pricePoints.Clear();
            var independentPrices = new List<decimal>();
            switch (independentVariable)
            {
                case IndependentVariables.SalePrice:
                    independentPrices = Variables.SalePriceItems.Select(item => item.ItemCode).ToList();
                    break;
                case IndependentVariables.PurchasePrice:
                    independentPrices = Variables.PurchasePriceItems.Select(item => item.ItemCode).ToList();
                    break;
                case IndependentVariables.PropertyTax:
                    independentPrices = Variables.PropertyTaxItems.Select(item => item.ItemCode).ToList();
                    break;
            }

            foreach (var price in independentPrices)
            {
                pricePoints.Add(new IndependentPricePoint { IndependentPrice = price });
            }

            var insurance = 1000.0M / 12.0M;
            switch (independentVariable)
            {
                case IndependentVariables.SalePrice:
                    CalculateSalePricePoints(independentPrices, insurance);
                    break;
                case IndependentVariables.PurchasePrice:
                    CalculatePurchasePricePoints(independentPrices, insurance);
                    break;
                case IndependentVariables.PropertyTax:
                    CalculateTaxPricePoints(independentPrices, insurance);
                    break;
            }
        }

        private void CalculateSalePricePoints(List<decimal> salePrices, decimal insurance)
        {
            var nextHomePrice = Convert.ToDecimal(cboDV1.SelectedValue);
            var propertyTax = Convert.ToDecimal(cboDV2.SelectedValue) / 12.0M;
            foreach (IndependentPricePoint point in pricePoints)
            {
                int i = 0;
                foreach (KeyValuePair<int, decimal> termRate in termRates)
                {
                    var amountToFinance = nextHomePrice - (point.IndependentPrice - payoff);
                    var PI = CalculatePI(amountToFinance, termRate.Value, termRate.Key);
                    var monthlyPayment = PI + propertyTax + insurance;
                    point.Net[i++] = income - (monthlyPayment + expenses);
                }
            }
        }

        private void CalculatePurchasePricePoints(List<decimal> purchasePrices, decimal insurance)
        {
            var salePrice = Convert.ToDecimal(cboDV1.SelectedValue);
            var propertyTax = Convert.ToDecimal(cboDV2.SelectedValue) / 12.0M;
            foreach (IndependentPricePoint point in pricePoints)
            {
                int i = 0;
                foreach (KeyValuePair<int, decimal> termRate in termRates)
                {
                    var amountToFinance = point.IndependentPrice - (salePrice - payoff);
                    var PI = CalculatePI(amountToFinance, termRate.Value, termRate.Key);
                    var monthlyPayment = PI + propertyTax + insurance;
                    point.Net[i++] = income - (monthlyPayment + expenses);
                }
            }
        }

        private void CalculateTaxPricePoints(List<decimal> taxes, decimal insurance)
        {
            var salePrice = Convert.ToDecimal(cboDV1.SelectedValue);
            var purchasePrice = Convert.ToDecimal(cboDV2.SelectedValue);
            foreach (IndependentPricePoint point in pricePoints)
            {
                int i = 0;
                foreach (KeyValuePair<int, decimal> termRate in termRates)
                {
                    var amountToFinance = purchasePrice - (salePrice - payoff);
                    var PI = CalculatePI(amountToFinance, termRate.Value, termRate.Key);
                    var monthlyPayment = PI + (point.IndependentPrice / 12.0M) + insurance;
                    point.Net[i++] = income - (monthlyPayment + expenses);
                }
            }
        }

        private decimal CalculatePI(decimal principal, decimal annualRate, int termInYears)
        {
            int numberOfPayments = termInYears * 12;
            var r = annualRate / (12 * 100);
            var numerator = (decimal)(decimal.ToDouble(r) * Math.Pow(1.0 + decimal.ToDouble(r), numberOfPayments));
            var denominator = (decimal)(Math.Pow(1.0 + decimal.ToDouble(r), numberOfPayments) - 1.0);
            return principal * numerator / denominator;
        }

        private void cboIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!initialized) return;

            independentVariable = (IndependentVariables)cboIV.SelectedIndex;
            var dependentVariables =
                Enum.GetValues(typeof(IndependentVariables)).Cast<IndependentVariables>()
                .Where(v => v != independentVariable)
                .ToList();
            bool firstPass = true;
            foreach (var variable in dependentVariables)
            {
                switch (variable)
                {
                    case IndependentVariables.SalePrice:
                        if (firstPass)
                        {
                            cboDV1.DataSource = Variables.SalePriceItems;
                            cboDV1.DisplayMember = "DisplayText";
                            cboDV1.ValueMember = "ItemCode";
                            lblDV1.Text = IndependentVariables.SalePrice.ToFriendlyString();
                        }
                        else
                        {
                            cboDV2.DataSource = Variables.SalePriceItems;
                            cboDV2.DisplayMember = "DisplayText";
                            cboDV2.ValueMember = "ItemCode";
                            lblDV2.Text = IndependentVariables.SalePrice.ToFriendlyString();
                        }
                        break;
                    case IndependentVariables.PurchasePrice:
                        if (firstPass)
                        {
                            cboDV1.DataSource = Variables.PurchasePriceItems;
                            cboDV1.DisplayMember = "DisplayText";
                            cboDV1.ValueMember = "ItemCode";
                            lblDV1.Text = IndependentVariables.PurchasePrice.ToFriendlyString();
                        }
                        else
                        {
                            cboDV2.DataSource = Variables.PurchasePriceItems;
                            cboDV2.DisplayMember = "DisplayText";
                            cboDV2.ValueMember = "ItemCode";
                            lblDV2.Text = IndependentVariables.PurchasePrice.ToFriendlyString();
                        }
                        break;
                    case IndependentVariables.PropertyTax:
                        if (firstPass)
                        {
                            cboDV1.DataSource = Variables.PropertyTaxItems;
                            cboDV1.DisplayMember = "DisplayText";
                            cboDV1.ValueMember = "ItemCode";
                            lblDV1.Text = IndependentVariables.PropertyTax.ToFriendlyString();
                        }
                        else
                        {
                            cboDV2.DataSource = Variables.PropertyTaxItems;
                            cboDV2.DisplayMember = "DisplayText";
                            cboDV2.ValueMember = "ItemCode";
                            lblDV2.Text = IndependentVariables.PropertyTax.ToFriendlyString();
                        }
                        break;
                }
                firstPass = false;
            }
        }
    }
}
