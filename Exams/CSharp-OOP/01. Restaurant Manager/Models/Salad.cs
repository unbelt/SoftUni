namespace RestaurantManager.Models
{
    using System;
    using RestaurantManager.Interfaces;
    using System.Text;

    public class Salad : Meal, ISalad
    {
        private bool containsPasta = false;

        public Salad(string name, decimal price, int calories, int quantity, int timeToPrepare, bool containsPasta)
            : base(name, price, calories, quantity, timeToPrepare, true)
        {
            this.ContainsPasta = containsPasta;
        }

        public bool ContainsPasta
        {
            get
            {
                return this.containsPasta;
            }

            private set
            {
                this.containsPasta = value;
            }
        }

        public override string ToString()
        {
            var printSalad = new StringBuilder(base.ToString());

            printSalad.AppendFormat("\r\nContains pasta: {0}", this.ContainsPasta ? "yes" : "no");

            return printSalad.ToString();
        }
    }
}
