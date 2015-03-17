namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public abstract class Meal : Recipe, IMeal
    {
        private bool isVegan = false;
        private const string Vegan = "[VEGAN] ";

        public Meal(string name, decimal price, int calories, int quantity, int timeToPrepare, bool isVegan)
            : base(name, price, calories, quantity, MetricUnit.Grams, timeToPrepare)
        {
            this.IsVegan = isVegan;
        }

        public bool IsVegan
        {
            get
            {
                return this.isVegan;
            }

            protected set
            {
                this.isVegan = value;
            }
        }

        public void ToggleVegan()
        {
            if (this.IsVegan)
            {
                this.IsVegan = false;
            }
            else
            {
                this.IsVegan = true;
            }
        }

        public override string ToString()
        {
            var printMeal = new StringBuilder();

            if (this.IsVegan)
            {
                printMeal.Append(Vegan);
            }

            printMeal.Append(base.ToString());

            return printMeal.ToString();
        }
    }
}
