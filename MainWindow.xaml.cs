using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PizzaOrderingForm
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, decimal> pizzaPriceDict = new Dictionary<string, decimal>
        {
            {"Small", 8.00M},
            {"Medium", 10.00M},
            {"Large", 12.00M},
            {"Extra Large", 14.00M}
        };

        private Dictionary<string, decimal> toppingPriceDict = new Dictionary<string, decimal>
        {
            {"Pepperoni", 2.00M},
            {"Mushrooms", 1.50M},
            {"Onions", 1.00M},
            {"Sausage", 2.50M},
            {"Olives", 1.00M}
        };

        private Dictionary<string, decimal> drinkPriceDict = new Dictionary<string, decimal>
        {
            {"Small", 1.50M},
            {"Medium", 2.00M},
            {"Large", 2.50M},
            {"Extra Large", 3.00M}
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            GenerateReceipt();
        }

        private string GetSelectedRadioButtonText(IEnumerable<RadioButton> radioButtons)
        {
            return radioButtons.FirstOrDefault(rb => rb.IsChecked == true)?.Content.ToString();
        }

        private List<string> GetSelectedCheckBoxText(IEnumerable<CheckBox> checkBoxes)
        {
            return checkBoxes.Where(cb => cb.IsChecked == true).Select(cb => cb.Content.ToString()).ToList();
        }

        private decimal CalculateTotalPrice(string pizzaSize, List<string> toppings, string drinkSize)
        {
            decimal pizzaPrice = pizzaPriceDict[pizzaSize];
            decimal toppingsPrice = toppings.Sum(t => toppingPriceDict[t]);
            decimal drinkPrice = drinkPriceDict[drinkSize];
            decimal totalPrice = pizzaPrice + toppingsPrice + drinkPrice;

            return totalPrice;
        }

        private void GenerateReceipt()
        {
            string customerName = txtName.Text;
            string pizzaSize = GetSelectedRadioButtonText(pizzaSizeButtons);
            List<string> toppings = GetSelectedCheckBoxText(toppingsCheckboxes);
            string drinkSize = GetSelectedRadioButtonText(drinkSizeButtons);
            decimal totalPrice = CalculateTotalPrice(pizzaSize, toppings, drinkSize);

            string receipt = $"Customer Name: {customerName}\n\n" +
                             $"Pizza Size: {pizzaSize} - ${pizzaPriceDict[pizzaSize]:F2}\n\n" +
                             $"Toppings:\n{string.Join("\n", toppings.Select(t => $"{t} - ${toppingPriceDict[t]:F2}"))}\n\n" +
                             $"Drink Size: {drinkSize} - ${drinkPriceDict[drinkSize]:F2}\n\n" +
                             $"Total: ${totalPrice:F2}";

            rtbReceipt.Text = receipt;
        }
    }
}
