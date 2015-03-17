namespace RestaurantManager.Models
{
    using System;
    using RestaurantManager.Interfaces;
    using System.Text;
    using System.Globalization;

    public abstract class Recipe : IRecipe
    {
        private string name;
        private decimal price;
        private int calories;
        private int quantity;
        private MetricUnit unit;
        private int timeToPrepare;

        public Recipe(string name, decimal price, int calories, int quantity, MetricUnit unit, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantity;
            this.Unit = unit;
            this.TimeToPrepare = timeToPrepare;
        }

        #region Properties

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                ValidateRecipeProperty(value, "Name");

                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                ValidateRecipeProperty(value, "Price");

                this.price = value;
            }
        }

        public int Calories
        {
            get
            {
                return this.calories;
            }

            private set
            {
                ValidateRecipeProperty(value, "Calories");

                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quantity;
            }

            private set
            {
                ValidateRecipeProperty(value, "Quantity per Serving");

                this.quantity = value;
            }
        }

        public MetricUnit Unit
        {
            get
            {
                return this.unit;
            }

            private set
            {
                this.unit = value;
            }
        }

        public int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }

            private set
            {
                ValidateRecipeProperty(value, "Time to Prepare");

                this.timeToPrepare = value;
            }
        }
        #endregion

        public override string ToString()
        {
            var recipe = new StringBuilder();
            var unit = string.Empty;

            switch (this.Unit)
            {
                case MetricUnit.Grams: unit = "g";
                    break;
                case MetricUnit.Milliliters: unit = "ml";
                    break;
            }

            recipe.AppendFormat("==  {0} == {1}\r\n", this.Name, this.Price.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
            recipe.AppendFormat("Per serving: {0} {1}, {2} kcal\r\n", this.QuantityPerServing, unit, this.Calories);
            recipe.AppendFormat("Ready in {0} minutes", this.TimeToPrepare);

            return recipe.ToString();
        }

        private void ValidateRecipeProperty(object value, string name, string message = "")
        {
            if (value is string)
            {
                if (string.IsNullOrEmpty(value as string))
                {
                    throw new ArgumentException("The " + name + " is required");
                }
            }
            else if (value is int)
            {
                if (((int)value) <= 0)
                {
                    throw new InvalidOperationException("The " + name + " must be positive");
                }
            }
            else if (value is decimal)
            {
                if (((decimal)value) <= 0)
                {
                    throw new InvalidOperationException("The " + name + " must be positive");
                }
            }
        }
    }
}