namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class Dessert : Meal, IDessert
    {
        private bool withSugar = true;
        private const string VeganDessert = "[NO SUGAR] ";

        public Dessert(string name, decimal price, int calories, int quantity, int timeToPrepare, bool isVegan, bool withSugar = true)
            : base(name, price, calories, quantity, timeToPrepare, isVegan)
        {
            this.WithSugar = withSugar;
        }

        public bool WithSugar
        {
            get
            {
                return this.withSugar;
            }

            private set
            {
                this.withSugar = value;
            }
        }

        public void ToggleSugar()
        {
            if (this.WithSugar)
            {
                this.WithSugar = false;
            }
            else
            {
                this.WithSugar = true;
            }
        }

        public override string ToString()
        {
            var printDessert = new StringBuilder();

            if (this.IsVegan && !this.WithSugar)
            {
                printDessert.Append(VeganDessert);
            }

            printDessert.Append(base.ToString());

            return printDessert.ToString();
        }
    }
}