using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageSolver2
{
    public enum IndependentVariables
    {
        SalePrice = 0,
        PurchasePrice = 1,
        PropertyTax = 2
    }

    public class Variables
    {
        public static List<ComboBoxItem> ComboBoxItems = new List<ComboBoxItem>
        {
            new ComboBoxItem(IndependentVariables.SalePrice.ToFriendlyString(), (int)IndependentVariables.SalePrice),
            new ComboBoxItem(IndependentVariables.PurchasePrice.ToFriendlyString(), (int)IndependentVariables.PurchasePrice),
            new ComboBoxItem(IndependentVariables.PropertyTax.ToFriendlyString(), (int)IndependentVariables.PropertyTax)
        };

        public static List<ComboBoxItem1> SalePriceItems = new List<ComboBoxItem1>
        {
            new ComboBoxItem1("$650,000", 650000.0M),
            new ComboBoxItem1("$655,000", 655000.0M),
            new ComboBoxItem1("$660,000", 660000.0M),
            new ComboBoxItem1("$665,000", 665000.0M),
            new ComboBoxItem1("$670,000", 670000.0M),
            new ComboBoxItem1("$675,000", 675000.0M),
            new ComboBoxItem1("$680,000", 680000.0M),
            new ComboBoxItem1("$685,000", 685000.0M),
            new ComboBoxItem1("$690,000", 690000.0M),
            new ComboBoxItem1("$695,000", 695000.0M),
            new ComboBoxItem1("$700,000", 700000.0M),
            new ComboBoxItem1("$705,000", 705000.0M),
            new ComboBoxItem1("$710,000", 710000.0M),
            new ComboBoxItem1("$715,000", 715000.0M),
            new ComboBoxItem1("$720,000", 720000.0M),
            new ComboBoxItem1("$725,000", 725000.0M),
            new ComboBoxItem1("$730,000", 730000.0M),
            new ComboBoxItem1("$735,000", 735000.0M),
            new ComboBoxItem1("$740,000", 740000.0M),
        };

        public static List<ComboBoxItem1> PurchasePriceItems = new List<ComboBoxItem1>
        {
            new ComboBoxItem1("$340,000", 340000.0M),
            new ComboBoxItem1("$345,000", 345000.0M),
            new ComboBoxItem1("$350,000", 350000.0M),
            new ComboBoxItem1("$355,000", 355000.0M),
            new ComboBoxItem1("$360,000", 360000.0M),
            new ComboBoxItem1("$365,000", 365000.0M),
            new ComboBoxItem1("$370,000", 370000.0M),
            new ComboBoxItem1("$375,000", 375000.0M),
            new ComboBoxItem1("$380,000", 380000.0M),
            new ComboBoxItem1("$385,000", 385000.0M),
            new ComboBoxItem1("$390,000", 390000.0M),
            new ComboBoxItem1("$395,000", 395000.0M),
            new ComboBoxItem1("$400,000", 400000.0M),
            new ComboBoxItem1("$405,000", 405000.0M),
            new ComboBoxItem1("$410,000", 410000.0M),
            new ComboBoxItem1("$415,000", 415000.0M),
            new ComboBoxItem1("$420,000", 420000.0M),
            new ComboBoxItem1("$425,000", 425000.0M),
            new ComboBoxItem1("$430,000", 430000.0M),
            new ComboBoxItem1("$435,000", 435000.0M),
            new ComboBoxItem1("$440,000", 440000.0M),
            new ComboBoxItem1("$445,000", 445000.0M),
            new ComboBoxItem1("$450,000", 450000.0M),
        };
        public static List<ComboBoxItem1> PropertyTaxItems = new List<ComboBoxItem1>
        {
            new ComboBoxItem1("$3,000", 3000.0M),
            new ComboBoxItem1("$3,500", 3500.0M),
            new ComboBoxItem1("$4,000", 4000.0M),
            new ComboBoxItem1("$4,500", 4500.0M),
            new ComboBoxItem1("$5,000", 5000.0M),
            new ComboBoxItem1("$5,500", 5500.0M),
            new ComboBoxItem1("$6,000", 6000.0M),
            new ComboBoxItem1("$6,500", 6500.0M),
            new ComboBoxItem1("$7,000", 7000.0M),
            new ComboBoxItem1("$7,500", 7500.0M),
            new ComboBoxItem1("$8,000", 8000.0M),
            new ComboBoxItem1("$8,500", 8500.0M),
            new ComboBoxItem1("$9,000", 9000.0M),
            new ComboBoxItem1("$9,500", 9500.0M),
            new ComboBoxItem1("$10,000", 10000.0M),
            new ComboBoxItem1("$10,500", 10500.0M),
            new ComboBoxItem1("$11,000", 11000.0M),
            new ComboBoxItem1("$11,500", 11500.0M),
            new ComboBoxItem1("$12,000", 12000.0M),
        };
    }

    public static class IndependentVariablesExtensions
    {
        public static string ToFriendlyString(this IndependentVariables variable) => variable switch
        {
            IndependentVariables.SalePrice => "Sale Price",
            IndependentVariables.PurchasePrice => "Purchase Price",
            IndependentVariables.PropertyTax => "Property Tax",
        };
    }
    public class ComboBoxItem
    {
        public string DisplayText { get; set; }
        public int ItemCode { get; set; }

        public ComboBoxItem(string text, int code)
        {
            DisplayText = text;
            ItemCode = code;
        }
    }
    public class ComboBoxItem1
    {
        public string DisplayText { get; set; }
        public decimal ItemCode { get; set; }

        public ComboBoxItem1(string text, decimal code)
        {
            DisplayText = text;
            ItemCode = code;
        }
    }
}

