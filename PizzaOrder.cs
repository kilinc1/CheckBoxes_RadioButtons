public class PizzaOrder
    {
        public string CustomerName { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public List<Topping> Toppings { get; set; }
        public DrinkSize DrinkSize { get; set; }

        public PizzaOrder(string customerName, PizzaSize pizzaSize, List<Topping> toppings, DrinkSize drinkSize)
        {
            CustomerName = customerName;
            PizzaSize = pizzaSize;
            Toppings = toppings;
            DrinkSize = drinkSize;
        }

        public decimal CalculateTotal()
        {
            decimal pizzaPrice = GetPizzaPrice();
            decimal toppingsPrice = GetToppingsPrice();
            decimal drinkPrice = GetDrinkPrice();

            return pizzaPrice + toppingsPrice + drinkPrice;
        }

        private decimal GetPizzaPrice()
        {
            switch (PizzaSize)
            {
                case PizzaSize.Small:
                    return 7.00m;
                case PizzaSize.Medium:
                    return 9.00m;
                case PizzaSize.Large:
                    return 11.00m;
                case PizzaSize.ExtraLarge:
                    return 14.00m;
                default:
                    throw new ArgumentException("Invalid pizza size");
            }
        }

        private decimal GetToppingsPrice()
        {
            decimal toppingsPrice = 0.0m;
            foreach (Topping topping in Toppings)
            {
                toppingsPrice += topping.Price;
            }
            return toppingsPrice;
        }

        private decimal GetDrinkPrice()
        {
            switch (DrinkSize)
            {
                case DrinkSize.Small:
                    return 1.50m;
                case DrinkSize.Medium:
                    return 2.00m;
                case DrinkSize.Large:
                    return 2.50m;
                case DrinkSize.ExtraLarge:
                    return 3.00m;
                default:
                    throw new ArgumentException("Invalid drink size");
            }
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