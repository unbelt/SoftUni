namespace CompanyHierarchy
{
    using System;
    using System.Text;

    public class Customer : Person, Interfaces.ICostumer
    {
        private double expenses;

        public Customer(string firstName, string lastName, int id, double expenses)
            : base(firstName, lastName, id)
        {
            this.Expenses = expenses;
        }

        public double Expenses
        {
            get
            {
                return this.expenses;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The Customer expenses must be above zero!");
                }

                this.expenses = value;
            }
        }

        public void AddExpense(double amount)
        {
            this.Expenses += amount;
        }

        public override string ToString()
        {
            var print = new StringBuilder(base.ToString());

            print.AppendFormat("Expenses: {0}", this.expenses.ToString("C"));

            return print.ToString();
        }
    }
}