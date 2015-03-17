namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class Drink : Recipe, IDrink // oh rly
    {
        private bool isCarbonated = false;
        private const int maxDrinkCalories = 100;

        public Drink(string name, decimal price, int calories, int quantity, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantity, MetricUnit.Milliliters, timeToPrepare)
        {

            if (calories > 100)
            {
                throw new InvalidOperationException("Drink calories cannot be greater than 100!");
            }

            if (timeToPrepare > 20)
            {
                throw new InvalidOperationException("The time to prepare a drink must not be greater than 20.");
            }

            this.isCarbonated = isCarbonated;
        }

        public bool IsCarbonated
        {
            get
            {
                return this.isCarbonated;
            }

            private set
            {
                this.isCarbonated = value;
            }
        }

        public override string ToString()
        {
            var printDrink = new StringBuilder(base.ToString());

            printDrink.AppendFormat("\r\nCarbonated: {0}", this.IsCarbonated ? "yes" : "no");

            return printDrink.ToString();
        }
    }
}