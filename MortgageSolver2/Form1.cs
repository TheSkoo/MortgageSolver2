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
        private decimal profitsWithheld;

        private Dictionary<int, decimal> termRates;

        private IndependentVariables independentVariable;

        private bool initialized = false;

        private List<IndependentPricePoint> pricePoints = new List<IndependentPricePoint>();

        private StringBuilder sbPI;

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

            initialized = true;
        }

        private void RefreshFromForm()
        {
            payoff = decimal.Parse(tbPayoff.Text, System.Globalization.NumberStyles.Currency);
            expenses = decimal.Parse(tbExpenses.Text, System.Globalization.NumberStyles.Currency);
            income = decimal.Parse(tbIncome.Text, System.Globalization.NumberStyles.Currency);
            profitsWithheld = decimal.Parse(tbProfitsWithheld.Text, System.Globalization.NumberStyles.Currency);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            RefreshFromForm();
            CreateSalesPriceChart();

            chart.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "X Axis";
            chartArea.AxisY.Title = "Y Axis";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas.Add(chartArea);

            switch (independentVariable)
            {
                case IndependentVariables.SalePrice:
                    chart.ChartAreas[0].AxisX.Title = "Sale Price";
                    break;
                case IndependentVariables.PurchasePrice:
                    chart.ChartAreas[0].AxisX.Title = "Purchase Price";
                    break;
                case IndependentVariables.PropertyTax:
                    chart.ChartAreas[0].AxisX.Title = "Property Tax";
                    break;
            }
            chart.ChartAreas[0].AxisY.Title = "P/L $";

            chart.Series.Clear();

            Series series1 = new Series("Series1");
            series1.ChartArea = "MainArea";
            series1.LegendText = "15 Year Term";
            series1.BorderWidth = 3;
            chart.Series.Add(series1);
            chart.Series["Series1"].ChartType = SeriesChartType.Line;
            chart.Series["Series1"].Points
                .DataBindXY(
                    pricePoints
                        .Select(p => (double)p.IndependentPrice).ToArray(),
                    pricePoints
                        .Select(p => (double)p.Net[0]).ToArray());

            Series series2 = new Series("Series2");
            series2.ChartArea = "MainArea";
            series2.LegendText = "20 Year Term";
            series2.BorderWidth = 3;
            chart.Series.Add(series2);  
            chart.Series["Series2"].ChartType = SeriesChartType.Line;
            series2.ChartArea = "MainArea";
            // Bind both arrays simultaneously
            chart.Series["Series2"].Points
                .DataBindXY(
                    pricePoints
                        .Select(p => (double)p.IndependentPrice).ToArray(),
                    pricePoints
                        .Select(p => (double)p.Net[1]).ToArray());

            Series series3 = new Series("Series3");
            series3.ChartArea = "MainArea";
            series3.LegendText = "30 Year Term";
            series3.BorderWidth = 3;
            chart.Series.Add(series3);
            chart.Series["Series3"].ChartType = SeriesChartType.Line;
            chart.Series["Series3"].Points
                .DataBindXY(
                    pricePoints
                        .Select(p => (double)p.IndependentPrice).ToArray(),
                    pricePoints
                        .Select(p => (double)p.Net[2]).ToArray());

            chart.ChartAreas[0].AxisY.Minimum = double.NaN;
            chart.ChartAreas[0].AxisY.Maximum = double.NaN;
            chart.ChartAreas[0].AxisY.Interval = double.NaN;
            chart.ChartAreas[0].RecalculateAxesScale();
        }

        private void CreateSalesPriceChart()
        {
            sbPI = new StringBuilder();

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

            FileInfo fi = new FileInfo(@"c:\zzz\PI.csv");
            var sw = fi.CreateText();
            sw.Write(sbPI.ToString());
            sw.Close();
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
                    var amountToFinance = nextHomePrice - (point.IndependentPrice - payoff - profitsWithheld);
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
                    var amountToFinance = point.IndependentPrice - (salePrice - payoff - profitsWithheld);
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
                    var amountToFinance = purchasePrice - (salePrice - payoff - profitsWithheld);
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
            var PI = principal * numerator / denominator;

            sbPI.AppendLine(principal.ToString() + "," +  annualRate.ToString() + "," + termInYears.ToString() + "," + PI.ToString());
            return PI;
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
