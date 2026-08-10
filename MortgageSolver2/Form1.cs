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

        private string xAxisTitle = string.Empty;

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
                    xAxisTitle = "Sale Price";
                    break;
                case IndependentVariables.PurchasePrice:
                    xAxisTitle = "Purchase Price";
                    break;
                case IndependentVariables.PropertyTax:
                    xAxisTitle = "Property Tax";
                    break;
            }
            chart.ChartAreas[0].AxisX.Title = xAxisTitle;
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
            chart.Series[0].ToolTip = "#VALY{C0}";

            Series series2 = new Series("Series2");
            series2.ChartArea = "MainArea";
            series2.LegendText = "20 Year Term";
            series2.BorderWidth = 3;
            chart.Series.Add(series2);  
            chart.Series["Series2"].ChartType = SeriesChartType.Line;
            chart.Series["Series2"].Points
                .DataBindXY(
                    pricePoints
                        .Select(p => (double)p.IndependentPrice).ToArray(),
                    pricePoints
                        .Select(p => (double)p.Net[1]).ToArray());
            chart.Series[1].ToolTip = "#VALY{C0}";

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
            chart.Series[2].ToolTip = "#VALY{C0}";

            List<double> allNetValues = pricePoints.SelectMany(p => p.Net).Select(n => (double)n).ToList();
            var maxNet = allNetValues.Max();
            var minNet = allNetValues.Min();
            minNet = (Math.Floor(minNet / 100.0) * 100.0) - 100.0;
            if (minNet < 0.0)
                minNet = 0.0;
            chart.ChartAreas[0].AxisY.Minimum = minNet;
            chart.ChartAreas[0].AxisY.Maximum = double.NaN;
            chart.ChartAreas[0].AxisY.Interval = double.NaN;

            //double yMax = mySeries.Points.FindMaxByValue("Y").YValues[0];
            //double yMin = mySeries.Points.FindMinByValue("Y").YValues[0];

            //// Add a clean 5% padding manually instead of trusting the built-in auto-scale
            //double padding = (yMax - yMin) * 0.05;

            //chart1.ChartAreas[0].AxisY.Maximum = yMax + padding;
            //chart1.ChartAreas[0].AxisY.Minimum = yMin - padding;
            chart.ChartAreas[0].RecalculateAxesScale();

            PopulateLowerChart();
        }

        private void PopulateLowerChart()
        {
            chart1.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("MainArea");
            chartArea1.AxisX.Title = "X Axis";
            chartArea1.AxisY.Title = "Y Axis";
            chartArea1.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas.Add(chartArea1);
            chart1.Series.Clear();

            List<double> allValues = new List<double>();
            var yAxisTitle = string.Empty;
            if (rbAmountFinanced.Checked)
            {
                Series series4 = new Series("Series4");
                series4.ChartArea = "MainArea";
                series4.LegendText = "Amount Financed";
                series4.BorderWidth = 3;
                chart1.Series.Add(series4);
                chart1.Series["Series4"].ChartType = SeriesChartType.Line;
                chart1.Series["Series4"].Points
                    .DataBindXY(
                        pricePoints
                            .Select(p => (double)p.IndependentPrice).ToArray(),
                        pricePoints
                            .Select(p => (double)p.AmountFinanced).ToArray());
                allValues.AddRange(pricePoints.Select(p => (double)p.AmountFinanced));
                yAxisTitle = "Amount Financed";
                series4.IsValueShownAsLabel = true;
                series4.MarkerStyle = MarkerStyle.Circle;
                series4.MarkerSize = 8;
                series4.MarkerColor = Color.Green;
                series4.BorderWidth = 3; // Make the line thicker
            }
            else
            {
                Series series7 = new Series("Series7");
                series7.ChartArea = "MainArea";
                series7.LegendText = "15 Year Term";
                series7.BorderWidth = 3;
                chart1.Series.Add(series7);
                chart1.Series["Series7"].ChartType = SeriesChartType.Line;
                chart1.Series["Series7"].Points
                    .DataBindXY(
                        pricePoints
                            .Select(p => (double)p.IndependentPrice).ToArray(),
                        pricePoints
                            .Select(p => (double)p.PITI[0]).ToArray());

                Series series8 = new Series("Series8");
                series8.ChartArea = "MainArea";
                series8.LegendText = "20 Year Term";
                series8.BorderWidth = 3;
                chart1.Series.Add(series8);
                chart1.Series["Series8"].ChartType = SeriesChartType.Line;
                series8.ChartArea = "MainArea";
                // Bind both arrays simultaneously
                chart1.Series["Series8"].Points
                    .DataBindXY(
                        pricePoints
                            .Select(p => (double)p.IndependentPrice).ToArray(),
                        pricePoints
                            .Select(p => (double)p.PITI[1]).ToArray());

                Series series9 = new Series("Series9");
                series9.ChartArea = "MainArea";
                series9.LegendText = "30 Year Term";
                series9.BorderWidth = 3;
                chart1.Series.Add(series9);
                chart1.Series["Series9"].ChartType = SeriesChartType.Line;
                chart1.Series["Series9"].Points
                    .DataBindXY(
                        pricePoints
                            .Select(p => (double)p.IndependentPrice).ToArray(),
                        pricePoints
                            .Select(p => (double)p.PITI[2]).ToArray());
                yAxisTitle = "PITI $";
                allValues.AddRange(pricePoints.SelectMany(p => p.PITI).Select(n => (double)n));
                chart1.Series[0].ToolTip = "#VALY{C0}";
                chart1.Series[1].ToolTip = "#VALY{C0}";
                chart1.Series[2].ToolTip = "#VALY{C0}";

            }
            chart1.ChartAreas[0].AxisX.Title = xAxisTitle;
            chart1.ChartAreas[0].AxisY.Title = yAxisTitle;
            var minY = pricePoints.Min(p => (double)p.IndependentPrice);
            var maxY = pricePoints.Max(p => (double)p.IndependentPrice);
            //chart1.ChartAreas[0].AxisY.Minimum = minY;
            //chart1.ChartAreas[0].AxisY.Maximum = maxY;
            chart1.ChartAreas[0].AxisY.Minimum = 0.0;
            chart1.ChartAreas[0].AxisY.Maximum = double.NaN;
            chart1.ChartAreas[0].AxisY.Interval = double.NaN;
            chart1.ChartAreas[0].RecalculateAxesScale();
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

            //FileInfo fi = new FileInfo(@"c:\zzz\PI.csv");
            //var sw = fi.CreateText();
            //sw.Write(sbPI.ToString());
            //sw.Close();
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
                    if (amountToFinance < 0)
                    {
                        amountToFinance = 0;
                    }
                    point.AmountFinanced = amountToFinance;
                    var PI = CalculatePI(amountToFinance, termRate.Value, termRate.Key);
                    var monthlyPayment = PI + propertyTax + insurance;
                    point.Net[i] = income - (monthlyPayment + expenses);
                    point.PITI[i++] = monthlyPayment;
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
                    if (amountToFinance < 0)
                    {
                        amountToFinance = 0;
                    }
                    point.AmountFinanced = amountToFinance;
                    var PI = CalculatePI(amountToFinance, termRate.Value, termRate.Key);
                    var monthlyPayment = PI + propertyTax + insurance;
                    point.Net[i] = income - (monthlyPayment + expenses);
                    point.PITI[i++] = monthlyPayment;
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
                    if (amountToFinance < 0)
                    {
                        amountToFinance = 0;
                    }
                    point.AmountFinanced = amountToFinance;
                    var PI = CalculatePI(amountToFinance, termRate.Value, termRate.Key);
                    var monthlyPayment = PI + (point.IndependentPrice / 12.0M) + insurance;
                    point.Net[i] = income - (monthlyPayment + expenses);
                    point.PITI[i++] = monthlyPayment;
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

        private void LowerChart_CheckedChanged(object sender, EventArgs e)
        {
            PopulateLowerChart();
        }
    }
}
